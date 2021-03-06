﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
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

        public static void Delete()
        {
            File.Delete(DATABASE_FILE);
            Directory.GetCurrentDirectory();
        }

        public static bool Exists()
        {
            return File.Exists(DATABASE_FILE);
        }

        public static void ExecuteNonQuery(string sql)
        {
            using (SQLiteConnection connection = Connection())
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<Dictionary<string, object>> Query(string sql, DataLoader dataLoader)
        {
            using (SQLiteConnection connection = Connection())
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        List<Dictionary<string, object>> results;
                        dataLoader(reader, out results);

                        return results;
                    }
                }
            }
        }

        public delegate void DataLoader(SQLiteDataReader reader, out List<Dictionary<string, object>> results);

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
