using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLog.SQLite
{
    /// <summary>
    /// SQLite wrapper functions for database access
    /// </summary>
    public class Database
    {
        public static void Create()
        {
            CreateDatabaseFile();
            CreateTables();
        }

        private static void CreateDatabaseFile()
        {
            SQLiteConnection.CreateFile(DATABASE_FILE);
        }

        private static void CreateTables()
        {
            using (SQLiteConnection connection = Connection())
            {
                using (SQLiteCommand command = new SQLiteCommand(CREATE_DAY_TABLE, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private static SQLiteConnection Connection()
        {
            SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0};", DATABASE_FILE));
            connection.Open();
            return connection;
        }

        private const string DATABASE_FILE = "database.sqlite";
        private const string CREATE_DAY_TABLE = "CREATE TABLE days (date INT, score INT)";
    }
}
