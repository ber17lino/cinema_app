using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Cinema_APP
{
    public partial class SeatCategoryForm : Form
    {
        private int? _seatCategoryId;

        public SeatCategoryForm(int? seatCategoryId = null)
        {
            _seatCategoryId = seatCategoryId;
            InitializeComponent();
            if (seatCategoryId.HasValue)
                LoadSeatCategoryData();
            else
                this.Text = "Добавление категории места";
        }

        private void LoadSeatCategoryData()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT * FROM Seat_categories WHERE ID_seat_category = @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _seatCategoryId.Value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtCategoryName.Text = reader["Category_name"].ToString();
                                numRowStart.Value = Convert.ToInt32(reader["Row_start"]);
                                numRowEnd.Value = Convert.ToInt32(reader["Row_end"]);
                                numBasePrice.Value = Convert.ToDecimal(reader["Base_price"]);

                                this.Text = "Редактирование категории места: " + reader["Category_name"];
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
                    string query = _seatCategoryId.HasValue ?
                        @"UPDATE Seat_categories SET Category_name=@name, Row_start=@start, 
                          Row_end=@end, Base_price=@price WHERE ID_seat_category=@id" :
                        @"INSERT INTO Seat_categories (Category_name, Row_start, Row_end, Base_price) 
                          VALUES (@name, @start, @end, @price)";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtCategoryName.Text.Trim());
                        cmd.Parameters.AddWithValue("@start", (int)numRowStart.Value);
                        cmd.Parameters.AddWithValue("@end", (int)numRowEnd.Value);
                        cmd.Parameters.AddWithValue("@price", numBasePrice.Value);

                        if (_seatCategoryId.HasValue)
                            cmd.Parameters.AddWithValue("@id", _seatCategoryId.Value);

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
                    MessageBox.Show("Категория места с таким названием уже существует!", "Ошибка");
                    txtCategoryName.Focus();
                    txtCategoryName.SelectAll();
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
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Введите название категории!", "Ошибка");
                txtCategoryName.Focus();
                return false;
            }

            if (txtCategoryName.Text.Trim().Length < 2)
            {
                MessageBox.Show("Название категории должно содержать не менее 2 символов!", "Ошибка");
                txtCategoryName.Focus();
                txtCategoryName.SelectAll();
                return false;
            }

            if (numRowStart.Value > numRowEnd.Value)
            {
                MessageBox.Show("Начальный ряд не может быть больше конечного!", "Ошибка");
                numRowStart.Focus();
                return false;
            }

            if (numBasePrice.Value <= 0)
            {
                MessageBox.Show("Базовая цена должна быть положительной!", "Ошибка");
                numBasePrice.Focus();
                return false;
            }

            // Проверка на пересечение диапазонов с существующими категориями
            if (!ValidateRangeOverlap())
            {
                return false;
            }

            return true;
        }

        private bool ValidateRangeOverlap()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) FROM Seat_categories 
                                   WHERE (@start BETWEEN Row_start AND Row_end 
                                   OR @end BETWEEN Row_start AND Row_end 
                                   OR Row_start BETWEEN @start AND @end)
                                   AND ID_seat_category != @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@start", (int)numRowStart.Value);
                        cmd.Parameters.AddWithValue("@end", (int)numRowEnd.Value);
                        cmd.Parameters.AddWithValue("@id", _seatCategoryId ?? -1);

                        int overlappingCount = Convert.ToInt32(cmd.ExecuteScalar());
                        if (overlappingCount > 0)
                        {
                            MessageBox.Show("Диапазон рядов пересекается с существующей категорией мест!\n\n" +
                                          "Пожалуйста, выберите другой диапазон рядов.",
                                          "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            numRowStart.Focus();
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке диапазонов: {ex.Message}", "Ошибка");
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SeatCategoryForm_Load(object sender, EventArgs e)
        {
            txtCategoryName.Focus();
        }

        private void numRowStart_ValueChanged(object sender, EventArgs e)
        {
            // Автоматически подстраиваем конечный ряд, если он стал меньше начального
            if (numRowStart.Value > numRowEnd.Value)
            {
                numRowEnd.Value = numRowStart.Value;
            }
        }

        private void numRowEnd_ValueChanged(object sender, EventArgs e)
        {
            // Автоматически подстраиваем начальный ряд, если он стал больше конечного
            if (numRowEnd.Value < numRowStart.Value)
            {
                numRowStart.Value = numRowEnd.Value;
            }
        }

        private void txtCategoryName_KeyDown(object sender, KeyEventArgs e)
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