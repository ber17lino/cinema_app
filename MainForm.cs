using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace Cinema_APP
{
    public partial class MainForm : Form
    {
        private SQLiteConnection _connection;

        public MainForm()
        {
            InitializeComponent();
            statusLabel.Text = "БД не подключена";

            // Автоматическое подключение к БД при запуске
            AutoConnectToDatabase();
        }

        private void AutoConnectToDatabase()
        {
            try
            {
                _connection = DbHelper.GetConnection();
                _connection.Open();
                UpdateStatus("Подключено к БД");
                UpdateMenuAvailability(true);
            }
            catch (Exception ex)
            {
                UpdateStatus("БД не подключена");
                UpdateMenuAvailability(false);
                MessageBox.Show($"Не удалось подключиться к базе данных: {ex.Message}\n\n" +
                    "Убедитесь, что файл базы данных находится в правильной директории.",
                    "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void UpdateStatus(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(UpdateStatus), message);
            }
            else
            {
                statusLabel.Text = message;
                statusLabel.Invalidate();
            }
        }

        private void UpdateMenuAvailability(bool isConnected)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<bool>(UpdateMenuAvailability), isConnected);
                return;
            }

            таблицыToolStripMenuItem.Enabled = isConnected;
            отчётыToolStripMenuItem.Enabled = isConnected;
            toolStrip1.Enabled = isConnected;

            toolStripButtonФильмы.Enabled = isConnected;
            toolStripButtonЗалы.Enabled = isConnected;
            toolStripButtonСеансы.Enabled = isConnected;
            toolStripButtonБилеты.Enabled = isConnected;
            toolStripButtonМеста.Enabled = isConnected;
            toolStripButtonОтчётWord.Enabled = isConnected;
            toolStripButtonОтчётExcel.Enabled = isConnected;
            toolStripButtonОтчётPDF.Enabled = isConnected;
        }

        private void подключитьсяКБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Соединение с БД уже установлено.", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _connection = DbHelper.GetConnection();
                _connection.Open();
                UpdateStatus("Подключено к БД");
                UpdateMenuAvailability(true);

                MessageBox.Show("Подключение к базе данных успешно установлено!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Ошибка подключения");
                UpdateMenuAvailability(false);
            }
        }

        private void закрытьСоединениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    foreach (Form child in this.MdiChildren)
                    {
                        child.Close();
                    }

                    _connection.Close();
                    _connection = null;
                    UpdateStatus("Соединение с БД закрыто");
                    UpdateMenuAvailability(false);

                    MessageBox.Show("Соединение с базе данных закрыто.", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Соединение не установлено.", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при закрытии соединения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
            Application.Exit();
        }

        // === Таблицы → Основные ===
        private void фильмыToolStripMenuItem_Click(object sender, EventArgs e)
            => OpenTable("Фильмы", @"SELECT m.ID_movie, m.Movie_name, m.Duration, m.Description, 
                                    g.Genre_name, a.Restriction_name 
                                    FROM Movies m 
                                    LEFT JOIN Genres g ON m.ID_genre = g.ID_genre 
                                    LEFT JOIN Age_restrictions a ON m.ID_age_rest = a.ID_age_rest");

        private void залыToolStripMenuItem_Click(object sender, EventArgs e)
            => OpenTable("Залы", @"SELECT h.ID_hall, h.Hall_name, h.Total_rows, h.Seats_per_row, 
                                  st.Type_name, st.Markup 
                                  FROM Halls h 
                                  JOIN Screen_types st ON h.ID_screen_type = st.ID_screen_type");

        private void сеансыToolStripMenuItem_Click(object sender, EventArgs e)
            => OpenTable("Сеансы", @"SELECT s.ID_session, s.Start_datetime, s.End_datetime, 
                                    m.Movie_name, h.Hall_name 
                                    FROM Sessions s 
                                    JOIN Movies m ON s.ID_movie = m.ID_movie 
                                    JOIN Halls h ON s.ID_hall = h.ID_hall");

        private void билетыToolStripMenuItem_Click(object sender, EventArgs e)
            => OpenTable("Билеты", @"SELECT t.ID_ticket, t.Final_price, t.Purchase_date, 
                                    t.Ticket_status, m.Movie_name, h.Hall_name, 
                                    seat.Row_number, seat.Seat_number 
                                    FROM Tickets t 
                                    JOIN Sessions s ON t.ID_session = s.ID_session 
                                    JOIN Movies m ON s.ID_movie = m.ID_movie 
                                    JOIN Halls h ON s.ID_hall = h.ID_hall 
                                    JOIN Seats seat ON t.ID_seat = seat.ID_seat");

        private void местаToolStripMenuItem_Click(object sender, EventArgs e)
            => OpenTable("Места", @"SELECT s.ID_seat, s.Row_number, s.Seat_number, 
                           h.Hall_name, sc.Category_name
                           FROM Seats s 
                           LEFT JOIN Halls h ON s.ID_hall = h.ID_hall 
                           LEFT JOIN Seat_categories sc ON s.ID_seat_category = sc.ID_seat_category");

        // === Таблицы → Справочники ===
        private void жанрыToolStripMenuItem_Click(object sender, EventArgs e)
            => OpenTable("Жанры", "SELECT * FROM Genres");

        private void возрастныеОграниченияToolStripMenuItem_Click(object sender, EventArgs e)
            => OpenTable("Возрастные ограничения", "SELECT * FROM Age_restrictions");

        private void типыЭкрановToolStripMenuItem_Click(object sender, EventArgs e)
            => OpenTable("Типы экранов", "SELECT * FROM Screen_types");

        private void категорииМестToolStripMenuItem_Click(object sender, EventArgs e)
            => OpenTable("Категории мест", "SELECT * FROM Seat_categories");

        private void OpenTable(string tableName, string query)
        {
            if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Сначала подключитесь к базе данных!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (Form child in this.MdiChildren)
            {
                if (child is TableForm tf && tf.TableName == tableName)
                {
                    child.Activate();
                    child.WindowState = FormWindowState.Normal;
                    child.BringToFront();
                    return;
                }
            }

            try
            {
                var tableForm = new TableForm(tableName, query, this);
                tableForm.MdiParent = this;
                tableForm.Show();
                UpdateStatus($"Открыта таблица: {tableName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии таблицы {tableName}: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // === Обработчики для кнопок панели инструментов ===
        private void toolStripButtonФильмы_Click(object sender, EventArgs e) => фильмыToolStripMenuItem_Click(sender, e);
        private void toolStripButtonЗалы_Click(object sender, EventArgs e) => залыToolStripMenuItem_Click(sender, e);
        private void toolStripButtonСеансы_Click(object sender, EventArgs e) => сеансыToolStripMenuItem_Click(sender, e);
        private void toolStripButtonБилеты_Click(object sender, EventArgs e) => билетыToolStripMenuItem_Click(sender, e);
        private void toolStripButtonМеста_Click(object sender, EventArgs e) => местаToolStripMenuItem_Click(sender, e);

        // === Обработчики для кнопок отчетов на панели инструментов ===
        private void toolStripButtonОтчётWord_Click(object sender, EventArgs e)
        {
            if (CheckDatabaseConnection())
            {
                ReportsManager.GenerateHallsAndSeatsReport();
            }
        }

        private void toolStripButtonОтчётExcel_Click(object sender, EventArgs e)
        {
            if (CheckDatabaseConnection())
            {
                ShowFinancialReportDialog();
            }
        }

        private void toolStripButtonОтчётPDF_Click(object sender, EventArgs e)
        {
            if (CheckDatabaseConnection())
            {
                ReportsManager.GenerateWeeklyScheduleReport();
            }
        }

        // === Отчёты ===
        private void вWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckDatabaseConnection())
            {
                ReportsManager.GenerateHallsAndSeatsReport();
            }
        }

        private void вExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckDatabaseConnection())
            {
                ShowFinancialReportDialog();
            }
        }

        private void вPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckDatabaseConnection())
            {
                ReportsManager.GenerateWeeklyScheduleReport();
            }
        }

        // === Вспомогательные методы для отчетов ===
        private bool CheckDatabaseConnection()
        {
            if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Сначала подключитесь к базе данных!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ShowFinancialReportDialog()
        {
            var result = MessageBox.Show("Сформировать отчет за последние 30 дней или выбрать период?",
                "Финансовый отчет",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Отчет за последние 30 дней
                ReportsManager.GenerateFinancialReport();
            }
            else if (result == DialogResult.No)
            {
                // Выбор периода
                ShowDateRangeDialog();
            }
            // Если Cancel - ничего не делаем
        }

        private void ShowDateRangeDialog()
        {
            using (var dateForm = new DateRangeForm())
            {
                if (dateForm.ShowDialog() == DialogResult.OK)
                {
                    ReportsManager.GenerateFinancialReportByDate(dateForm.StartDate, dateForm.EndDate);
                }
            }
        }

        // === Окно ===
        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
            UpdateStatus("Окна расположены каскадом");
        }

        private void горизонтальноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
            UpdateStatus("Окна расположены горизонтально");
        }

        private void вертикальноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
            UpdateStatus("Окна расположены вертикально");
        }

        private void закрытьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                MessageBox.Show("Нет открытых окон для закрытия.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Закрыть все открытые окна?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Form child in this.MdiChildren)
                {
                    child.Close();
                }
                UpdateStatus("Все окна закрыты");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        protected override void OnMdiChildActivate(EventArgs e)
        {
            base.OnMdiChildActivate(e);
            if (this.ActiveMdiChild is TableForm tableForm)
            {
                UpdateStatus($"Активна таблица: {tableForm.TableName}");
            }
            else if (this.MdiChildren.Length == 0)
            {
                UpdateStatus("Готов");
            }
        }
    }
}