using System.Data.SQLite;
using ClientApp.Core; 

using System.Data.SQLite;

namespace ClientApp.Core
{
    public static class Database
    {
        private static string connectionString = @"Data Source=..\..\..\Database\RealEstate.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }
    }
}
