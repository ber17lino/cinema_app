using System.Data.SQLite;

namespace Cinema_APP
{
    public static class DbHelper
    {
        private static string _dbPath = "my_db_cinema.db";
        public static string ConnectionString => $"Data Source={_dbPath};Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }
    }
}