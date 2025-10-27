using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Cinema_APP
{
    public static class ReportsManager
    {
        // 1. Отчет по залам и местам (Word) - без изменений
        public static void GenerateHallsAndSeatsReport()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            h.Hall_name as 'Название зала',
                            st.Type_name as 'Тип экрана',
                            st.Markup as 'Наценка (%)',
                            h.Total_rows as 'Количество рядов',
                            h.Seats_per_row as 'Мест в ряду',
                            (h.Total_rows * h.Seats_per_row) as 'Общая вместимость',
                            COUNT(DISTINCT s.ID_session) as 'Количество сеансов',
                            COUNT(t.ID_ticket) as 'Всего билетов',
                            COALESCE(SUM(CASE WHEN t.Ticket_status = 1 THEN t.Final_price ELSE 0 END), 0) as 'Общая выручка',
                            GROUP_CONCAT(DISTINCT sc.Category_name || ' (ряды ' || sc.Row_start || '-' || sc.Row_end || ')') as 'Категории мест'
                        FROM Halls h
                        JOIN Screen_types st ON h.ID_screen_type = st.ID_screen_type
                        LEFT JOIN Sessions s ON h.ID_hall = s.ID_hall
                        LEFT JOIN Tickets t ON s.ID_session = t.ID_session
                        LEFT JOIN Seats se ON h.ID_hall = se.ID_hall
                        LEFT JOIN Seat_categories sc ON se.ID_seat_category = sc.ID_seat_category
                        GROUP BY h.Hall_name, st.Type_name, st.Markup, h.Total_rows, h.Seats_per_row
                        ORDER BY h.Hall_name";

                    using (var adapter = new SQLiteDataAdapter(query, conn))
                    {
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        if (data.Rows.Count == 0)
                        {
                            MessageBox.Show("Нет данных о залах для формирования отчета.\nДобавьте залы в систему.",
                                "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        ReportGenerator.GenerateWordReport("Отчет по залам и местам", data);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации отчета по залам: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. Афиша на неделю (PDF) - ОБНОВЛЕННОЕ СОДЕРЖАНИЕ
        public static void GenerateWeeklyScheduleReport()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    // Получаем даты начала и конца текущей недели
                    DateTime today = DateTime.Today;
                    DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek + 1); // Понедельник
                    DateTime endOfWeek = startOfWeek.AddDays(6); // Воскресенье

                    string query = @"
                        SELECT 
                            date(s.Start_datetime) as 'Дата',
                            strftime('%d.%m.%Y', s.Start_datetime) as 'Дата сеанса',
                            time(s.Start_datetime) as 'Время начала',
                            time(s.End_datetime) as 'Время окончания',
                            m.Movie_name as 'Фильм',
                            m.Duration as 'Длительность (мин)',
                            m.Description as 'Описание',
                            g.Genre_name as 'Жанр',
                            a.Restriction_name as 'Возрастное ограничение',
                            h.Hall_name as 'Зал',
                            st.Type_name as 'Тип экрана',
                            (SELECT COUNT(*) FROM Seats WHERE ID_hall = h.ID_hall) as 'Всего мест',
                            (SELECT COUNT(*) FROM Tickets t2 WHERE t2.ID_session = s.ID_session AND t2.Ticket_status = 1) as 'Продано билетов',
                            (SELECT COUNT(*) FROM Seats WHERE ID_hall = h.ID_hall) - 
                            (SELECT COUNT(*) FROM Tickets t2 WHERE t2.ID_session = s.ID_session AND t2.Ticket_status = 1) as 'Свободных мест',
                            CASE 
                                WHEN (SELECT COUNT(*) FROM Seats WHERE ID_hall = h.ID_hall) > 0 THEN
                                    ROUND(CAST((SELECT COUNT(*) FROM Tickets t2 WHERE t2.ID_session = s.ID_session AND t2.Ticket_status = 1) AS FLOAT) / 
                                    (SELECT COUNT(*) FROM Seats WHERE ID_hall = h.ID_hall) * 100, 1)
                                ELSE 0 
                            END as 'Заполняемость (%)'
                        FROM Sessions s
                        JOIN Movies m ON s.ID_movie = m.ID_movie
                        LEFT JOIN Genres g ON m.ID_genre = g.ID_genre
                        LEFT JOIN Age_restrictions a ON m.ID_age_rest = a.ID_age_rest
                        JOIN Halls h ON s.ID_hall = h.ID_hall
                        JOIN Screen_types st ON h.ID_screen_type = st.ID_screen_type
                        WHERE date(s.Start_datetime) BETWEEN @startDate AND @endDate
                        ORDER BY s.Start_datetime, h.Hall_name";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@startDate", startOfWeek.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@endDate", endOfWeek.ToString("yyyy-MM-dd"));

                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            DataTable data = new DataTable();
                            adapter.Fill(data);

                            if (data.Rows.Count == 0)
                            {
                                MessageBox.Show($"На неделю с {startOfWeek:dd.MM.yyyy} по {endOfWeek:dd.MM.yyyy} нет запланированных сеансов.\nДобавьте сеансы в систему.",
                                    "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            string[] columnsForPdf = {
                                "Дата сеанса", "Время начала", "Фильм", "Длительность (мин)",
                                "Жанр", "Возрастное ограничение", "Зал", "Тип экрана",
                                "Продано билетов", "Свободных мест", "Заполняемость (%)"
                            };

                            ReportGenerator.GeneratePdfReport($"Афиша на неделю {startOfWeek:dd.MM.yyyy}-{endOfWeek:dd.MM.yyyy}", data, columnsForPdf);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации афиши: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. Финансовый отчет за период (Excel) - без изменений
        public static void GenerateFinancialReport()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            date(s.Start_datetime) as 'Дата',
                            m.Movie_name as 'Фильм',
                            g.Genre_name as 'Жанр',
                            h.Hall_name as 'Зал',
                            COUNT(t.ID_ticket) as 'Всего билетов',
                            COALESCE(SUM(CASE WHEN t.Ticket_status = 1 THEN 1 ELSE 0 END), 0) as 'Продано билетов',
                            COALESCE(SUM(CASE WHEN t.Ticket_status = 0 THEN 1 ELSE 0 END), 0) as 'Отменено билетов',
                            COALESCE(SUM(CASE WHEN t.Ticket_status = 1 THEN t.Final_price ELSE 0 END), 0) as 'Выручка',
                            COALESCE(AVG(CASE WHEN t.Ticket_status = 1 THEN t.Final_price ELSE NULL END), 0) as 'Средняя цена билета'
                        FROM Sessions s
                        JOIN Movies m ON s.ID_movie = m.ID_movie
                        LEFT JOIN Genres g ON m.ID_genre = g.ID_genre
                        JOIN Halls h ON s.ID_hall = h.ID_hall
                        LEFT JOIN Tickets t ON s.ID_session = t.ID_session
                        WHERE s.Start_datetime >= date('now', '-30 days')
                        GROUP BY date(s.Start_datetime), m.Movie_name, g.Genre_name, h.Hall_name
                        ORDER BY date(s.Start_datetime) DESC, Выручка DESC";

                    using (var adapter = new SQLiteDataAdapter(query, conn))
                    {
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        if (data.Rows.Count == 0)
                        {
                            MessageBox.Show("Нет финансовых данных за последние 30 дней для формирования отчета.\nДобавьте сеансы и продажи в систему.",
                                "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        ReportGenerator.GenerateExcelReport("Финансовый отчет", data);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации финансового отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. Финансовый отчет за выбранный период - без изменений
        public static void GenerateFinancialReportByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            date(s.Start_datetime) as 'Дата',
                            m.Movie_name as 'Фильм',
                            g.Genre_name as 'Жанр',
                            h.Hall_name as 'Зал',
                            COUNT(t.ID_ticket) as 'Всего билетов',
                            COALESCE(SUM(CASE WHEN t.Ticket_status = 1 THEN 1 ELSE 0 END), 0) as 'Продано билетов',
                            COALESCE(SUM(CASE WHEN t.Ticket_status = 0 THEN 1 ELSE 0 END), 0) as 'Отменено билетов',
                            COALESCE(SUM(CASE WHEN t.Ticket_status = 1 THEN t.Final_price ELSE 0 END), 0) as 'Выручка',
                            COALESCE(AVG(CASE WHEN t.Ticket_status = 1 THEN t.Final_price ELSE NULL END), 0) as 'Средняя цена билета'
                        FROM Sessions s
                        JOIN Movies m ON s.ID_movie = m.ID_movie
                        LEFT JOIN Genres g ON m.ID_genre = g.ID_genre
                        JOIN Halls h ON s.ID_hall = h.ID_hall
                        LEFT JOIN Tickets t ON s.ID_session = t.ID_session
                        WHERE date(s.Start_datetime) BETWEEN @startDate AND @endDate
                        GROUP BY date(s.Start_datetime), m.Movie_name, g.Genre_name, h.Hall_name
                        ORDER BY date(s.Start_datetime) DESC, Выручка DESC";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"));

                        using (var adapter = new SQLiteDataAdapter(cmd))
                        {
                            DataTable data = new DataTable();
                            adapter.Fill(data);

                            if (data.Rows.Count == 0)
                            {
                                MessageBox.Show($"Нет финансовых данных за период с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy} для формирования отчета.",
                                    "Нет данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            ReportGenerator.GenerateExcelReport($"Финансовый отчет {startDate:dd.MM.yyyy}-{endDate:dd.MM.yyyy}", data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации финансового отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для проверки наличия минимальных данных в системе - без изменений
        public static bool CheckMinimumData()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    var checks = new[]
                    {
                        new { Query = "SELECT COUNT(*) FROM Halls", Message = "залов" },
                        new { Query = "SELECT COUNT(*) FROM Movies", Message = "фильмов" },
                        new { Query = "SELECT COUNT(*) FROM Sessions", Message = "сеансов" },
                        new { Query = "SELECT COUNT(*) FROM Screen_types", Message = "типов экранов" },
                        new { Query = "SELECT COUNT(*) FROM Seat_categories", Message = "категорий мест" }
                    };

                    foreach (var check in checks)
                    {
                        using (var cmd = new SQLiteCommand(check.Query, conn))
                        {
                            var count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (count == 0)
                            {
                                MessageBox.Show($"Для формирования отчетов необходимо добавить {check.Message} в систему.",
                                    "Недостаточно данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}