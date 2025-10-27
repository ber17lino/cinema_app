using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace Cinema_APP
{
    public partial class TableForm : Form
    {
        public string TableName { get; private set; }
        private string _query;
        private DataTable _dataTable;
        private SQLiteDataAdapter _adapter;
        private MainForm _mainForm;

        public TableForm(string tableName, string query, MainForm mainForm)
        {
            InitializeComponent();
            TableName = tableName;
            _query = query;
            _mainForm = mainForm;
            this.Text = "Данные таблицы: " + tableName;
            this.MdiParent = mainForm;

            // Настройка кнопок в зависимости от таблицы
            if (TableName.ToLower() == "билеты")
            {
                btnAdd.Text = "Оформить билет";
                btnEdit.Visible = false; // Скрываем редактирование
                btnDelete.Text = "Отменить билет";
            }
            else
            {
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    _dataTable = new DataTable();
                    _adapter = new SQLiteDataAdapter(_query, conn);
                    var commandBuilder = new SQLiteCommandBuilder(_adapter);
                    _adapter.Fill(_dataTable);
                    dgvData.DataSource = _dataTable;
                    ConfigureGridView();
                    _mainForm.UpdateStatus($"Загружено {_dataTable.Rows.Count} записей из {TableName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _mainForm.UpdateStatus("Ошибка загрузки данных");
            }
        }

        private void ConfigureGridView()
        {
            foreach (DataGridViewColumn column in dgvData.Columns)
            {
                if (column.Name.StartsWith("ID_") || column.Name.Contains("_id"))
                    column.Visible = false;
            }

            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn column in dgvData.Columns)
            {
                column.HeaderText = GetColumnName(column.HeaderText);
            }
        }

        private string GetColumnName(string englishName)
        {
            switch (englishName.ToLower())
            {
                case "movie_name": return "Название фильма";
                case "duration": return "Длительность (мин)";
                case "description": return "Описание";
                case "hall_name": return "Название зала";
                case "total_rows": return "Количество рядов";
                case "seats_per_row": return "Мест в ряду";
                case "start_datetime": return "Начало сеанса";
                case "end_datetime": return "Конец сеанса";
                case "final_price": return "Цена билета";
                case "ticket_status": return "Статус";
                case "purchase_date": return "Дата покупки";
                case "genre_name": return "Жанр";
                case "restriction_name": return "Возрастное ограничение";
                case "type_name": return "Тип экрана";
                case "markup": return "Наценка";
                case "category_name": return "Категория места";
                case "row_number": return "Ряд";
                case "seat_number": return "Место";
                default: return englishName;
            }
        }

        private int GetSelectedId()
        {
            if (dgvData.CurrentRow != null && dgvData.CurrentRow.Index >= 0)
            {
                foreach (DataGridViewColumn column in dgvData.Columns)
                {
                    if (column.Name.StartsWith("ID_") && dgvData.CurrentRow.Cells[column.Name].Value != null)
                    {
                        return Convert.ToInt32(dgvData.CurrentRow.Cells[column.Name].Value);
                    }
                }
            }
            return -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (TableName.ToLower() == "билеты")
                {
                    var form = new TicketSaleForm();
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else
                {
                    Form editForm = GetEditForm(null);
                    if (editForm != null && editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Этот метод не должен вызываться для "Билеты", но на всякий случай:
            if (TableName.ToLower() == "билеты")
            {
                MessageBox.Show("Редактирование билетов запрещено. Используйте отмену.", "Информация");
                return;
            }

            try
            {
                int id = GetSelectedId();
                if (id == -1)
                {
                    MessageBox.Show("Выберите запись для редактирования!", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Form editForm = GetEditForm(id);
                if (editForm != null && editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = GetSelectedId();
                if (id == -1)
                {
                    MessageBox.Show("Выберите запись для удаления!", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (TableName.ToLower() == "билеты")
                {
                    // Отмена билета: меняем статус на 0
                    if (MessageBox.Show("Вы уверены, что хотите отменить этот билет?\nМесто станет доступным для продажи.", "Подтверждение отмены",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CancelTicket(id);
                    }
                }
                else
                {
                    // Обычное удаление
                    if (MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?", "Подтверждение удаления",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DeleteRecord(id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelTicket(int ticketId)
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Tickets SET Ticket_status = 0 WHERE ID_ticket = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", ticketId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Билет успешно отменён!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось отменить билет. Возможно, он уже отменён.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отмене билета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteRecord(int id)
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string idColumnName = GetIdColumnName();
                    string tableName = GetTableNameForDelete();
                    string query = $"DELETE FROM {tableName} WHERE {idColumnName} = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Запись успешно удалена!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось удалить запись.", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                if (ex.Message.Contains("FOREIGN KEY constraint failed"))
                {
                    MessageBox.Show("Нельзя удалить запись: на неё есть ссылки в других таблицах!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    throw;
                }
            }
        }

        private string GetIdColumnName()
        {
            switch (TableName.ToLower())
            {
                case "фильмы": return "ID_movie";
                case "залы": return "ID_hall";
                case "сеансы": return "ID_session";
                case "билеты": return "ID_ticket";
                case "жанры": return "ID_genre";
                case "возрастные ограничения": return "ID_age_rest";
                case "типы экранов": return "ID_screen_type";
                case "категории мест": return "ID_seat_category";
                case "места": return "ID_seat";
                default: return "ID";
            }
        }

        private string GetTableNameForDelete()
        {
            switch (TableName.ToLower())
            {
                case "фильмы": return "Movies";
                case "залы": return "Halls";
                case "сеансы": return "Sessions";
                case "билеты": return "Tickets";
                case "жанры": return "Genres";
                case "возрастные ограничения": return "Age_restrictions";
                case "типы экранов": return "Screen_types";
                case "категории мест": return "Seat_categories";
                case "места": return "Seats";
                default: return TableName;
            }
        }

        private Form GetEditForm(int? id)
        {
            try
            {
                switch (TableName.ToLower())
                {
                    case "жанры":
                        return new EditForm("Genres", "Genre_name", id);
                    case "возрастные ограничения":
                        return new EditForm("Age_restrictions", "Restriction_name", id);
                    case "типы экранов":
                        return new ScreenTypeForm(id);
                    case "категории мест":
                        return new SeatCategoryForm(id);
                    case "места":
                        MessageBox.Show("Редактирование мест осуществляется через форму залов.", "Информация");
                        break;
                    case "фильмы":
                        return new MovieForm(id);
                    case "залы":
                        return new HallForm(id);
                    case "сеансы":
                        return new SessionForm(id);
                    case "билеты":
                        // Не должно вызываться — редактирование скрыто
                        break;
                    default:
                        MessageBox.Show($"Редактирование для таблицы '{TableName}' не реализовано.", "Информация");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании формы: {ex.Message}", "Ошибка");
            }
            return null;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dataTable != null)
            {
                string filter = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(filter))
                {
                    _dataTable.DefaultView.RowFilter = "";
                }
                else
                {
                    var filterExpression = "";
                    var visibleColumns = dgvData.Columns.Cast<DataGridViewColumn>()
                        .Where(c => c.Visible);
                    foreach (var column in visibleColumns)
                    {
                        if (!string.IsNullOrEmpty(filterExpression))
                            filterExpression += " OR ";
                        filterExpression += $"[{column.DataPropertyName}] LIKE '%{filter}%'";
                    }
                    _dataTable.DefaultView.RowFilter = filterExpression;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mainForm.UpdateStatus("Готов");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}