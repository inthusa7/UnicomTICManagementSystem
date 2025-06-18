using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTICManagementSystem.Data
{
    internal class DBConfig
    {
        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=unicomTIC.db;Version=3;");
            conn.Open();
            return conn;
        }
    }
}
