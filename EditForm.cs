using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Cinema_APP
{
    public partial class EditForm : Form
    {
        private string _tableName;
        private int? _recordId;
        private string _fieldName;
        private string _idColumnName;

        public EditForm(string tableName, string fieldName, int? recordId = null)
        {
            InitializeComponent();
            _tableName = tableName;
            _recordId = recordId;
            _fieldName = fieldName;

            // Определяем имя ID колонки на основе названия таблицы
            _idColumnName = GetIdColumnName(tableName);

            InitializeForm();
        }

        private string GetIdColumnName(string tableName)
        {
            switch (tableName.ToLower())
            {
                case "genres":
                    return "ID_genre";
                case "age_restrictions":
                    return "ID_age_rest";
                case "screen_types":
                    return "ID_screen_type";
                case "seat_categories":
                    return "ID_seat_category";
                case "price_categories":
                    return "ID_price_category";
                default:
                    return $"ID_{tableName.ToLower()}";
            }
        }

        private void InitializeForm()
        {
            this.Text = _recordId.HasValue ?
                $"Редактирование {GetTableDisplayName()}" :
                $"Добавление {GetTableDisplayName()}";

            lblFieldName.Text = GetFieldDisplayName() + ":";

            if (_recordId.HasValue)
            {
                LoadRecord();
            }
        }

        private string GetTableDisplayName()
        {
            switch (_tableName.ToLower())
            {
                case "genres":
                    return "жанра";
                case "age_restrictions":
                    return "возрастного ограничения";
                case "screen_types":
                    return "типа экрана";
                case "seat_categories":
                    return "категории места";
                case "price_categories":
                    return "ценовой категории";
                default:
                    return _tableName;
            }
        }

        private string GetFieldDisplayName()
        {
            switch (_fieldName.ToLower())
            {
                case "genre_name":
                    return "Название жанра";
                case "restriction_name":
                    return "Возрастное ограничение";
                case "type_name":
                    return "Тип экрана";
                case "category_name":
                    return "Категория места";
                case "markup":
                    return "Наценка (%)";
                default:
                    return _fieldName;
            }
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            txtValue.Focus();
            if (_recordId.HasValue)
            {
                txtValue.SelectAll();
            }
        }

        private void LoadRecord()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = $"SELECT * FROM {_tableName} WHERE {_idColumnName} = @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _recordId.Value);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtValue.Text = reader[1].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Запись не найдена!", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValue.Text))
            {
                MessageBox.Show("Поле не может быть пустым!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValue.Focus();
                return;
            }

            if (txtValue.Text.Trim().Length < 2)
            {
                MessageBox.Show("Значение должно содержать не менее 2 символов!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValue.Focus();
                txtValue.SelectAll();
                return;
            }

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query;

                    if (_recordId.HasValue)
                    {
                        query = $"UPDATE {_tableName} SET {_fieldName} = @value WHERE {_idColumnName} = @id";
                    }
                    else
                    {
                        query = $"INSERT INTO {_tableName} ({_fieldName}) VALUES (@value)";
                    }

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@value", txtValue.Text.Trim());

                        if (_recordId.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@id", _recordId.Value);
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные успешно сохранены!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось сохранить данные!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                if (ex.ResultCode == SQLiteErrorCode.Constraint_Unique)
                {
                    MessageBox.Show("Запись с таким значением уже существует!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtValue.Focus();
                    txtValue.SelectAll();
                }
                else
                {
                    MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public string EnteredValue
        {
            get { return txtValue.Text.Trim(); }
        }

        public void SetValue(string value)
        {
            txtValue.Text = value;
        }

        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(sender, e);
            }
        }
    }
}