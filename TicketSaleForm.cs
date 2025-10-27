using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Cinema_APP
{
    public partial class TicketSaleForm : Form
    {
        private DataTable _sessionsTable;

        public TicketSaleForm()
        {
            InitializeComponent();
            LoadSessions();
            cmbSeat.Enabled = false;
            lblPrice.Text = "Цена: —";
        }

        private void LoadSessions()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            s.ID_session, 
                            m.Movie_name || ' (' || substr(s.Start_datetime, 12, 5) || ', ' || h.Hall_name || ')' AS SessionInfo,
                            s.Start_datetime,
                            s.ID_hall,
                            h.Hall_name
                        FROM Sessions s
                        JOIN Movies m ON s.ID_movie = m.ID_movie
                        JOIN Halls h ON s.ID_hall = h.ID_hall
                        WHERE s.Start_datetime > datetime('now')
                        ORDER BY s.Start_datetime";

                    var adapter = new SQLiteDataAdapter(query, conn);
                    _sessionsTable = new DataTable();
                    adapter.Fill(_sessionsTable);

                    cmbSession.DisplayMember = "SessionInfo";
                    cmbSession.ValueMember = "ID_session";
                    cmbSession.DataSource = _sessionsTable;

                    if (_sessionsTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Нет доступных сеансов для продажи билетов!", "Информация",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки сеансов: {ex.Message}", "Ошибка");
            }
        }

        private void LoadSeatsForHall(int hallId)
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    // Проверяем, есть ли доступные места в зале
                    string availableSeatsQuery = @"
                        SELECT COUNT(*) 
                        FROM Seats s
                        WHERE s.ID_hall = @hallId
                        AND s.ID_seat NOT IN (
                            SELECT t.ID_seat 
                            FROM Tickets t 
                            JOIN Sessions sess ON t.ID_session = sess.ID_session 
                            WHERE sess.ID_hall = @hallId 
                            AND t.Ticket_status = 1
                            AND sess.Start_datetime > datetime('now')
                        )";

                    using (var countCmd = new SQLiteCommand(availableSeatsQuery, conn))
                    {
                        countCmd.Parameters.AddWithValue("@hallId", hallId);
                        int availableSeats = Convert.ToInt32(countCmd.ExecuteScalar());

                        if (availableSeats == 0)
                        {
                            MessageBox.Show("В выбранном зале нет свободных мест!", "Информация",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmbSeat.DataSource = null;
                            cmbSeat.Enabled = false;
                            return;
                        }
                    }

                    // Загружаем только свободные места для этого зала
                    string query = @"
                        SELECT 
                            s.ID_seat,
                            'Ряд ' || s.Row_number || ', Место ' || s.Seat_number AS SeatInfo,
                            s.Row_number,
                            s.Seat_number
                        FROM Seats s
                        WHERE s.ID_hall = @hallId
                        AND s.ID_seat NOT IN (
                            SELECT t.ID_seat 
                            FROM Tickets t 
                            JOIN Sessions sess ON t.ID_session = sess.ID_session 
                            WHERE sess.ID_hall = @hallId 
                            AND t.Ticket_status = 1
                            AND sess.Start_datetime > datetime('now')
                        )
                        ORDER BY s.Row_number, s.Seat_number";

                    var adapter = new SQLiteDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@hallId", hallId);
                    var seatsTable = new DataTable();
                    adapter.Fill(seatsTable);

                    cmbSeat.DisplayMember = "SeatInfo";
                    cmbSeat.ValueMember = "ID_seat";
                    cmbSeat.DataSource = seatsTable;

                    cmbSeat.Enabled = (seatsTable.Rows.Count > 0);

                    if (seatsTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Все места в этом зале уже заняты на ближайшие сеансы!", "Информация",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        cmbSeat.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки мест: {ex.Message}", "Ошибка");
                cmbSeat.Enabled = false;
            }
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSession.SelectedValue != null && _sessionsTable != null)
            {
                // Находим выбранную строку в таблице сеансов
                DataRowView selectedRow = cmbSession.SelectedItem as DataRowView;
                if (selectedRow != null && selectedRow.Row["ID_hall"] != DBNull.Value)
                {
                    int hallId = Convert.ToInt32(selectedRow.Row["ID_hall"]);
                    LoadSeatsForHall(hallId);
                }
            }
            else
            {
                cmbSeat.DataSource = null;
                cmbSeat.Enabled = false;
                lblPrice.Text = "Цена: —";
            }

            CalculatePrice();
        }

        private void cmbSeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        private void CalculatePrice()
        {
            if (cmbSession.SelectedValue == null || cmbSeat.SelectedValue == null)
            {
                lblPrice.Text = "Цена: —";
                return;
            }

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            CASE 
                                WHEN sc.Base_price IS NOT NULL THEN sc.Base_price * (1 + st.Markup / 100.0)
                                ELSE 300 * (1 + st.Markup / 100.0)
                            END AS FinalPrice
                        FROM Seats s
                        JOIN Halls h ON s.ID_hall = h.ID_hall
                        JOIN Screen_types st ON h.ID_screen_type = st.ID_screen_type
                        LEFT JOIN Seat_categories sc ON s.ID_seat_category = sc.ID_seat_category
                        WHERE s.ID_seat = @seatId";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@seatId", cmbSeat.SelectedValue);
                        var result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            decimal price = Math.Round(Convert.ToDecimal(result), 2);
                            lblPrice.Text = $"Цена: {price:F2} ₽";
                        }
                        else
                        {
                            lblPrice.Text = "Цена: недоступна";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblPrice.Text = "Ошибка расчёта";
                Console.WriteLine($"Ошибка расчета цены: {ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSession.SelectedValue == null)
            {
                MessageBox.Show("Выберите сеанс!", "Ошибка");
                cmbSession.Focus();
                return;
            }

            if (cmbSeat.SelectedValue == null)
            {
                MessageBox.Show("Выберите место!", "Ошибка");
                cmbSeat.Focus();
                return;
            }

            // Проверка: не продано ли уже это место на этом сеансе
            if (IsSeatSold())
            {
                MessageBox.Show("Это место уже продано на выбранном сеансе! Пожалуйста, выберите другое место.", "Ошибка");
                cmbSeat.Focus();
                return;
            }

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    // Получаем финальную цену
                    decimal finalPrice = GetFinalPrice();

                    string insertQuery = @"
                        INSERT INTO Tickets (Final_price, Ticket_status, ID_session, ID_seat, Purchase_date)
                        VALUES (@price, 1, @sessionId, @seatId, datetime('now'))";

                    using (var cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@price", finalPrice);
                        cmd.Parameters.AddWithValue("@sessionId", cmbSession.SelectedValue);
                        cmd.Parameters.AddWithValue("@seatId", cmbSeat.SelectedValue);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Билет успешно оформлен!", "Успех",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось оформить билет!", "Ошибка",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при оформлении билета: {ex.Message}", "Ошибка");
            }
        }

        private bool IsSeatSold()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT COUNT(*) 
                        FROM Tickets
                        WHERE ID_session = @sessionId 
                        AND ID_seat = @seatId 
                        AND Ticket_status = 1";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sessionId", cmbSession.SelectedValue);
                        cmd.Parameters.AddWithValue("@seatId", cmbSeat.SelectedValue);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке места: {ex.Message}", "Ошибка");
                return true; // Блокируем продажу в случае ошибки
            }
        }

        private decimal GetFinalPrice()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            CASE 
                                WHEN sc.Base_price IS NOT NULL THEN sc.Base_price * (1 + st.Markup / 100.0)
                                ELSE 300 * (1 + st.Markup / 100.0)
                            END AS FinalPrice
                        FROM Seats s
                        JOIN Halls h ON s.ID_hall = h.ID_hall
                        JOIN Screen_types st ON h.ID_screen_type = st.ID_screen_type
                        LEFT JOIN Seat_categories sc ON s.ID_seat_category = sc.ID_seat_category
                        WHERE s.ID_seat = @seatId";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@seatId", cmbSeat.SelectedValue);
                        var result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            return Math.Round(Convert.ToDecimal(result), 2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка получения цены: {ex.Message}");
            }

            return 300m; // Цена по умолчанию
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbSession_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbSeat_KeyDown(object sender, KeyEventArgs e)
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