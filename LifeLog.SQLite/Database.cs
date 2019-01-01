using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLog.SQLite
{
    public class Database
    {
        public void Create()
        {
            SQLiteConnection.CreateFile(DATABASE_FILE);
        }

        public const string DATABASE_FILE = "database.sqlite";
    }
}
