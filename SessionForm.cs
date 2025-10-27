using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Cinema_APP
{
    public partial class SessionForm : Form
    {
        private int? _sessionId;
        private DataTable _moviesTable;
        private DataTable _hallsTable;

        public SessionForm(int? sessionId = null)
        {
            _sessionId = sessionId;
            InitializeComponent();
            LoadMoviesAndHalls();
            if (sessionId.HasValue)
                LoadSessionData();
            else
                this.Text = "Добавление сеанса";
        }

        private void LoadMoviesAndHalls()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    var moviesAdapter = new SQLiteDataAdapter(
                        "SELECT ID_movie, Movie_name, Duration FROM Movies ORDER BY Movie_name", conn);
                    _moviesTable = new DataTable();
                    moviesAdapter.Fill(_moviesTable);
                    cmbMovie.DataSource = _moviesTable;
                    cmbMovie.DisplayMember = "Movie_name";
                    cmbMovie.ValueMember = "ID_movie";

                    var hallsAdapter = new SQLiteDataAdapter(
                        "SELECT ID_hall, Hall_name FROM Halls ORDER BY Hall_name", conn);
                    _hallsTable = new DataTable();
                    hallsAdapter.Fill(_hallsTable);
                    cmbHall.DataSource = _hallsTable;
                    cmbHall.DisplayMember = "Hall_name";
                    cmbHall.ValueMember = "ID_hall";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка");
            }
        }

        private void LoadSessionData()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT s.*, m.Movie_name, h.Hall_name 
                                   FROM Sessions s 
                                   JOIN Movies m ON s.ID_movie = m.ID_movie 
                                   JOIN Halls h ON s.ID_hall = h.ID_hall 
                                   WHERE s.ID_session = @id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _sessionId.Value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cmbMovie.SelectedValue = reader["ID_movie"];
                                cmbHall.SelectedValue = reader["ID_hall"];
                                dtpStartDate.Value = Convert.ToDateTime(reader["Start_datetime"]);
                                dtpStartTime.Value = Convert.ToDateTime(reader["Start_datetime"]);
                                this.Text = "Редактирование сеанса";
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

        private void CalculateEndTime()
        {
            if (cmbMovie.SelectedValue != null)
            {
                var selectedRow = (cmbMovie.SelectedItem as DataRowView)?.Row;
                if (selectedRow != null && !selectedRow.IsNull("Duration"))
                {
                    int duration = Convert.ToInt32(selectedRow["Duration"]);
                    DateTime startDateTime = dtpStartDate.Value.Date + dtpStartTime.Value.TimeOfDay;
                    DateTime endDateTime = startDateTime.AddMinutes(duration);
                    lblEndTime.Text = $"Окончание: {endDateTime:dd.MM.yyyy HH:mm}";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            DateTime startDateTime = dtpStartDate.Value.Date + dtpStartTime.Value.TimeOfDay;
            DateTime endDateTime = startDateTime.AddMinutes(GetSelectedMovieDuration());

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    if (CheckSessionOverlap(startDateTime, endDateTime))
                    {
                        MessageBox.Show("В этом зале уже есть сеанс в указанное время!", "Ошибка");
                        return;
                    }

                    string query = _sessionId.HasValue ?
                        @"UPDATE Sessions SET ID_movie=@movie, ID_hall=@hall, 
                          Start_datetime=@start, End_datetime=@end 
                          WHERE ID_session=@id" :
                        @"INSERT INTO Sessions (ID_movie, ID_hall, Start_datetime, End_datetime) 
                          VALUES (@movie, @hall, @start, @end)";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@movie", cmbMovie.SelectedValue);
                        cmd.Parameters.AddWithValue("@hall", cmbHall.SelectedValue);
                        cmd.Parameters.AddWithValue("@start", startDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@end", endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        if (_sessionId.HasValue)
                            cmd.Parameters.AddWithValue("@id", _sessionId.Value);

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
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка");
            }
        }

        private int GetSelectedMovieDuration()
        {
            var selectedRow = (cmbMovie.SelectedItem as DataRowView)?.Row;
            return selectedRow != null && !selectedRow.IsNull("Duration")
                ? Convert.ToInt32(selectedRow["Duration"])
                : 0;
        }

        private bool CheckSessionOverlap(DateTime startDateTime, DateTime endDateTime)
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT COUNT(*) FROM Sessions s
                        WHERE s.ID_hall = @hallId 
                        AND s.ID_session != @sessionId 
                        AND (
                            (s.Start_datetime < @end AND s.End_datetime > @start)
                        )";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@hallId", cmbHall.SelectedValue);
                        cmd.Parameters.AddWithValue("@sessionId", _sessionId ?? -1);
                        cmd.Parameters.AddWithValue("@start", startDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@end", endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private bool ValidateInput()
        {
            if (cmbMovie.SelectedValue == null)
            {
                MessageBox.Show("Выберите фильм!", "Ошибка");
                cmbMovie.Focus();
                return false;
            }
            if (cmbHall.SelectedValue == null)
            {
                MessageBox.Show("Выберите зал!", "Ошибка");
                cmbHall.Focus();
                return false;
            }

            DateTime startDateTime = dtpStartDate.Value.Date + dtpStartTime.Value.TimeOfDay;
            if (startDateTime <= DateTime.Now)
            {
                MessageBox.Show("Время сеанса должно быть в будущем!", "Ошибка");
                dtpStartDate.Focus();
                return false;
            }

            if (GetSelectedMovieDuration() <= 0)
            {
                MessageBox.Show("Невозможно определить длительность фильма!", "Ошибка");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbMovie_SelectedIndexChanged(object sender, EventArgs e) => CalculateEndTime();
        private void dtpStartDate_ValueChanged(object sender, EventArgs e) => CalculateEndTime();
        private void dtpStartTime_ValueChanged(object sender, EventArgs e) => CalculateEndTime();
    }
}