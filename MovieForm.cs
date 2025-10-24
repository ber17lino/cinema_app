using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Cinema_APP
{
    public partial class MovieForm : Form
    {
        private int? _movieId;
        private DataTable _genresTable;
        private DataTable _ageRestrictionsTable;

        public MovieForm(int? movieId = null)
        {
            _movieId = movieId;
            InitializeComponent();
            LoadComboBoxData();
            if (movieId.HasValue)
                LoadMovieData();
            else
                this.Text = "Добавление фильма";
        }

        private void LoadComboBoxData()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();

                    // Загрузка жанров
                    var genresAdapter = new SQLiteDataAdapter(
                        "SELECT ID_genre, Genre_name FROM Genres ORDER BY Genre_name", conn);
                    _genresTable = new DataTable();
                    genresAdapter.Fill(_genresTable);

                    cmbGenre.DataSource = _genresTable;
                    cmbGenre.DisplayMember = "Genre_name";
                    cmbGenre.ValueMember = "ID_genre";
                    cmbGenre.SelectedIndex = -1;

                    // Загрузка возрастных ограничений
                    var ageAdapter = new SQLiteDataAdapter(
                        "SELECT ID_age_rest, Restriction_name FROM Age_restrictions ORDER BY Restriction_name", conn);
                    _ageRestrictionsTable = new DataTable();
                    ageAdapter.Fill(_ageRestrictionsTable);

                    cmbAgeRestriction.DataSource = _ageRestrictionsTable;
                    cmbAgeRestriction.DisplayMember = "Restriction_name";
                    cmbAgeRestriction.ValueMember = "ID_age_rest";
                    cmbAgeRestriction.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников: {ex.Message}", "Ошибка");
            }
        }

        private void LoadMovieData()
        {
            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT m.*, g.Genre_name, a.Restriction_name 
                                   FROM Movies m 
                                   LEFT JOIN Genres g ON m.ID_genre = g.ID_genre 
                                   LEFT JOIN Age_restrictions a ON m.ID_age_rest = a.ID_age_rest 
                                   WHERE m.ID_movie = @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _movieId.Value);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtMovieName.Text = reader["Movie_name"].ToString();
                                numDuration.Value = Convert.ToInt32(reader["Duration"]);
                                txtDescription.Text = reader["Description"].ToString();

                                if (!reader.IsDBNull(reader.GetOrdinal("ID_genre")))
                                    cmbGenre.SelectedValue = reader["ID_genre"];
                                if (!reader.IsDBNull(reader.GetOrdinal("ID_age_rest")))
                                    cmbAgeRestriction.SelectedValue = reader["ID_age_rest"];

                                this.Text = "Редактирование фильма: " + reader["Movie_name"];
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
            if (!ValidateInput())
                return;

            try
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = _movieId.HasValue ?
                        @"UPDATE Movies SET Movie_name=@name, Duration=@duration, 
                          Description=@desc, ID_genre=@genre, ID_age_rest=@age 
                          WHERE ID_movie=@id" :
                        @"INSERT INTO Movies (Movie_name, Duration, Description, ID_genre, ID_age_rest) 
                          VALUES (@name, @duration, @desc, @genre, @age)";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtMovieName.Text.Trim());
                        cmd.Parameters.AddWithValue("@duration", (int)numDuration.Value);
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());

                        // Обработка NULL значений для выпадающих списков
                        cmd.Parameters.AddWithValue("@genre",
                            cmbGenre.SelectedValue != null ? cmbGenre.SelectedValue : DBNull.Value);
                        cmd.Parameters.AddWithValue("@age",
                            cmbAgeRestriction.SelectedValue != null ? cmbAgeRestriction.SelectedValue : DBNull.Value);

                        if (_movieId.HasValue)
                            cmd.Parameters.AddWithValue("@id", _movieId.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Данные сохранены успешно!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Фильм с таким названием уже существует!", "Ошибка");
                    txtMovieName.Focus();
                    txtMovieName.SelectAll();
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
            // Проверка названия
            if (string.IsNullOrWhiteSpace(txtMovieName.Text))
            {
                MessageBox.Show("Введите название фильма!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMovieName.Focus();
                return false;
            }

            if (txtMovieName.Text.Trim().Length < 2)
            {
                MessageBox.Show("Название фильма должно содержать не менее 2 символов!", "Ошибка");
                txtMovieName.Focus();
                txtMovieName.SelectAll();
                return false;
            }

            // Проверка длительности
            if (numDuration.Value <= 0 || numDuration.Value > 500)
            {
                MessageBox.Show("Длительность должна быть от 1 до 500 минут!", "Ошибка");
                numDuration.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MovieForm_Load(object sender, EventArgs e)
        {
            txtMovieName.Focus();
        }

        // Обработка нажатия Enter и Escape
        private void txtMovieName_KeyDown(object sender, KeyEventArgs e)
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