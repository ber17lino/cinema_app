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
                            MessageBox.Show("Данные сохранены успешно!", "Успех");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
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

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHallName.Text))
            {
                MessageBox.Show("Введите название зала!", "Ошибка");
                txtHallName.Focus();
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

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void HallForm_Load(object sender, EventArgs e)
        {
            txtHallName.Focus();
        }
    }
}