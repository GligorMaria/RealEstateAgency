using System;
using System.Data.SQLite;
using System.IO;

namespace RealEstateApp.Core
{
    public static class DatabaseHelper
    {
        public static SQLiteConnection GetConnection(string dbName)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            // Navigate from bin/... to repo root if needed:
            // assuming executable is at AgentApp/bin/Debug/net9.0-windows/
            string repoRoot = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\.."));
            string dbPath = Path.Combine(repoRoot, "Database", dbName);

            // Optional: ensure file exists or create it
            if (!File.Exists(dbPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);
                SQLiteConnection.CreateFile(dbPath);
            }

            // If you want to debug the path, use Console.WriteLine instead of MessageBox
            // Console.WriteLine($"Using DB: {dbPath}");

            return new SQLiteConnection($"Data Source={dbPath};Version=3;");
        }
    }
}
