using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Cinema_APP
{
    public partial class ScreenTypeForm : Form
    {
        private int? _screenTypeId;

        public ScreenTypeForm(int? screenTypeId = null)
        {
            _screenTypeId = screenTypeId;
            InitializeComponent();
            if (screenTypeId.HasValue)
                LoadScreenTypeData();
            else
                this.Text = "Добавление типа экрана";
        }

        private void LoadScreenTypeData()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT * FROM Screen_types WHERE ID_screen_type = @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _screenTypeId.Value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTypeName.Text = reader["Type_name"].ToString();
                                numMarkup.Value = Convert.ToDecimal(reader["Markup"]);

                                this.Text = "Редактирование типа экрана: " + reader["Type_name"];
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
                    string query = _screenTypeId.HasValue ?
                        @"UPDATE Screen_types SET Type_name=@name, Markup=@markup 
                          WHERE ID_screen_type=@id" :
                        @"INSERT INTO Screen_types (Type_name, Markup) VALUES (@name, @markup)";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtTypeName.Text.Trim());
                        cmd.Parameters.AddWithValue("@markup", numMarkup.Value);

                        if (_screenTypeId.HasValue)
                            cmd.Parameters.AddWithValue("@id", _screenTypeId.Value);

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
                    MessageBox.Show("Тип экрана с таким названием уже существует!", "Ошибка");
                    txtTypeName.Focus();
                    txtTypeName.SelectAll();
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
            if (string.IsNullOrWhiteSpace(txtTypeName.Text))
            {
                MessageBox.Show("Введите название типа экрана!", "Ошибка");
                txtTypeName.Focus();
                return false;
            }

            if (numMarkup.Value < 0)
            {
                MessageBox.Show("Наценка не может быть отрицательной!", "Ошибка");
                numMarkup.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ScreenTypeForm_Load(object sender, EventArgs e)
        {
            txtTypeName.Focus();
        }
    }
}