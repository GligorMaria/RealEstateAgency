using System.Data.SQLite;
using ClientApp.Core; 

using System.Data.SQLite;

namespace AgentApp.Core
{
    public static class Database
    {
        private static string connectionString = @"Data Source=..\..\..\Database\RealEstateDatabase.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }
    }
}