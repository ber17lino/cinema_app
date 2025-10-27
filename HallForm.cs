using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Cinema_APP
{
    public partial class HallForm : Form
    {
        private int? _hallId;
        private DataTable _screenTypesTable;

        public HallForm(int? hallId = null)
        {
            _hallId = hallId;
            InitializeComponent();
            LoadScreenTypes();
            if (hallId.HasValue)
                LoadHallData();
            else
                this.Text = "Добавление зала";
        }

        private void LoadScreenTypes()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    var adapter = new SQLiteDataAdapter(
                        "SELECT ID_screen_type, Type_name FROM Screen_types ORDER BY Type_name", conn);
                    _screenTypesTable = new DataTable();
                    adapter.Fill(_screenTypesTable);

                    cmbScreenType.DataSource = _screenTypesTable;
                    cmbScreenType.DisplayMember = "Type_name";
                    cmbScreenType.ValueMember = "ID_screen_type";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки типов экранов: {ex.Message}", "Ошибка");
            }
        }

        private void LoadHallData()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT h.*, st.Type_name 
                                   FROM Halls h 
                                   LEFT JOIN Screen_types st ON h.ID_screen_type = st.ID_screen_type 
                                   WHERE h.ID_hall = @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _hallId.Value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtHallName.Text = reader["Hall_name"].ToString();
                                numTotalRows.Value = Convert.ToInt32(reader["Total_rows"]);
                                numSeatsPerRow.Value = Convert.ToInt32(reader["Seats_per_row"]);

                                if (!reader.IsDBNull(reader.GetOrdinal("ID_screen_type")))
                                    cmbScreenType.SelectedValue = reader["ID_screen_type"];

                                this.Text = "Редактирование зала: " + reader["Hall_name"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка");
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    // Начинаем транзакцию
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string query = _hallId.HasValue ?
                                @"UPDATE Halls SET Hall_name=@name, Total_rows=@rows, 
                                  Seats_per_row=@seats, ID_screen_type=@screenType 
                                  WHERE ID_hall=@id" :
                                @"INSERT INTO Halls (Hall_name, Total_rows, Seats_per_row, ID_screen_type) 
                                  VALUES (@name, @rows, @seats, @screenType)";

                            using (var cmd = new SQLiteCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@name", txtHallName.Text.Trim());
                                cmd.Parameters.AddWithValue("@rows", (int)numTotalRows.Value);
                                cmd.Parameters.AddWithValue("@seats", (int)numSeatsPerRow.Value);
                                cmd.Parameters.AddWithValue("@screenType",
                                    cmbScreenType.SelectedValue != null ? cmbScreenType.SelectedValue : DBNull.Value);

                                if (_hallId.HasValue)
                                    cmd.Parameters.AddWithValue("@id", _hallId.Value);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    int hallId;
                                    if (!_hallId.HasValue)
                                    {
                                        // Получаем ID нового зала
                                        hallId = (int)conn.LastInsertRowId;
                                    }
                                    else
                                    {
                                        hallId = _hallId.Value;
                                    }

                                    // Генерируем места для зала
                                    GenerateSeatsForHall(conn, hallId, (int)numTotalRows.Value, (int)numSeatsPerRow.Value);

                                    transaction.Commit();

                                    MessageBox.Show("Данные сохранены успешно! Места сгенерированы автоматически.", "Успех");
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("Не удалось сохранить данные!", "Ошибка");
                                }
                            }
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                if (ex.ResultCode == SQLiteErrorCode.Constraint_Unique)
                {
                    MessageBox.Show("Зал с таким названием уже существует!", "Ошибка");
                    txtHallName.Focus();
                    txtHallName.SelectAll();
                }
                else
                {
                    MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка");
            }
        }

        private void GenerateSeatsForHall(SQLiteConnection conn, int hallId, int totalRows, int seatsPerRow)
        {
            // Удаляем старые места (если редактируем зал)
            string deleteQuery = "DELETE FROM Seats WHERE ID_hall = @hallId";
            using (var deleteCmd = new SQLiteCommand(deleteQuery, conn))
            {
                deleteCmd.Parameters.AddWithValue("@hallId", hallId);
                deleteCmd.ExecuteNonQuery();
            }

            // Получаем все категории мест для определения категории по номеру ряда
            string categoriesQuery = "SELECT ID_seat_category, Row_start, Row_end FROM Seat_categories ORDER BY Row_start";
            var categories = new System.Collections.Generic.List<(int id, int start, int end)>();

            using (var categoriesCmd = new SQLiteCommand(categoriesQuery, conn))
            using (var reader = categoriesCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    categories.Add((
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetInt32(2)
                    ));
                }
            }

            // Генерируем новые места
            string insertQuery = @"INSERT INTO Seats (Row_number, Seat_number, ID_hall, ID_seat_category) 
                                 VALUES (@row, @seat, @hallId, @categoryId)";

            bool warningShown = false;

            for (int row = 1; row <= totalRows; row++)
            {
                // Определяем категорию места для текущего ряда
                int? categoryId = null;
                foreach (var category in categories)
                {
                    if (row >= category.start && row <= category.end)
                    {
                        categoryId = category.id;
                        break;
                    }
                }

                // Если ряд не попадает ни в одну категорию, выводим предупреждение (только один раз)
                if (!categoryId.HasValue && !warningShown)
                {
                    MessageBox.Show($"Внимание: Ряд {row} не попадает ни в одну из существующих категорий мест.\n" +
                                  "Места в этом ряду будут созданы без категории.",
                                  "Информация",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    warningShown = true;
                }

                for (int seat = 1; seat <= seatsPerRow; seat++)
                {
                    using (var insertCmd = new SQLiteCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@row", row);
                        insertCmd.Parameters.AddWithValue("@seat", seat);
                        insertCmd.Parameters.AddWithValue("@hallId", hallId);
                        insertCmd.Parameters.AddWithValue("@categoryId",
                            categoryId.HasValue ? (object)categoryId.Value : DBNull.Value);

                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHallName.Text))
            {
                MessageBox.Show("Введите название зала!", "Ошибка");
                txtHallName.Focus();
                return false;
            }

            if (txtHallName.Text.Trim().Length < 2)
            {
                MessageBox.Show("Название зала должно содержать не менее 2 символов!", "Ошибка");
                txtHallName.Focus();
                txtHallName.SelectAll();
                return false;
            }

            if (numTotalRows.Value <= 0 || numTotalRows.Value > 50)
            {
                MessageBox.Show("Количество рядов должно быть от 1 до 50!", "Ошибка");
                numTotalRows.Focus();
                return false;
            }

            if (numSeatsPerRow.Value <= 0 || numSeatsPerRow.Value > 30)
            {
                MessageBox.Show("Количество мест в ряду должно быть от 1 до 30!", "Ошибка");
                numSeatsPerRow.Focus();
                return false;
            }

            // Новая проверка: количество рядов в зале не должно превышать максимальный ряд в категориях мест
            if (!ValidateRowsAgainstCategories())
            {
                return false;
            }

            return true;
        }

        private bool ValidateRowsAgainstCategories()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    // Получаем максимальный номер ряда из всех категорий мест
                    string query = "SELECT MAX(Row_end) FROM Seat_categories";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        var result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            int maxCategoryRow = Convert.ToInt32(result);
                            int hallTotalRows = (int)numTotalRows.Value;

                            if (hallTotalRows > maxCategoryRow)
                            {
                                MessageBox.Show($"Количество рядов в зале ({hallTotalRows}) превышает максимальный ряд " +
                                              $"в категориях мест ({maxCategoryRow}).\n\n" +
                                              "Пожалуйста, сначала добавьте категории мест с большим диапазоном рядов " +
                                              "или уменьшите количество рядов в зале.",
                                              "Ошибка валидации",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Error);
                                numTotalRows.Focus();
                                return false;
                            }
                        }
                        else
                        {
                            // Если категорий мест нет вообще
                            MessageBox.Show("В системе нет категорий мест!\n\n" +
                                          "Пожалуйста, сначала добавьте категории мест в справочнике.",
                                          "Ошибка валидации",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке категорий мест: {ex.Message}", "Ошибка");
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void HallForm_Load(object sender, EventArgs e)
        {
            txtHallName.Focus();

            // Проверяем наличие категорий мест при загрузке формы
            CheckSeatCategoriesExistence();
        }

        private void CheckSeatCategoriesExistence()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Seat_categories";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        int categoriesCount = Convert.ToInt32(cmd.ExecuteScalar());

                        if (categoriesCount == 0)
                        {
                            MessageBox.Show("Внимание! В системе нет категорий мест.\n\n" +
                                          "Перед созданием залов рекомендуется добавить категории мест " +
                                          "в разделе 'Справочники → Категории мест'.",
                                          "Предупреждение",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Не блокируем работу формы при ошибке проверки
                Console.WriteLine($"Ошибка при проверке категорий мест: {ex.Message}");
            }
        }

        private void txtHallName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(sender, e);
            }
        }

        private void numTotalRows_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(sender, e);
            }
        }

        private void numSeatsPerRow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(sender, e);
            }
        }
    }
}