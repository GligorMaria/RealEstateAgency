using System;
using System.Data.SQLite;
using System.IO;

namespace RealEstateApp.Core
{
    public static class DatabaseHelper
    {
        // Centralized Database folder name
        private const string DatabaseFolderName = "Database";

        /// <summary>
        /// Returns a SQLiteConnection pointing to the common Database folder at solution root.
        /// Ensures the folder exists and creates the file if missing.
        /// </summary>
        public static SQLiteConnection GetConnection(string dbFile)
        {
            string dbPath = GetDatabasePath(dbFile);

            Console.WriteLine($"[DatabaseHelper] Using DB path: {dbPath}");

            try
            {
                // Ensure folder exists
                Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

                // Create file if missing
                if (!File.Exists(dbPath))
                {
                    SQLiteConnection.CreateFile(dbPath);
                    Console.WriteLine($"[DatabaseHelper] Created new DB file: {dbPath}");
                }

                // Log file size
                long size = new FileInfo(dbPath).Length;
                Console.WriteLine($"[DatabaseHelper] DB file size: {size} bytes");

                return new SQLiteConnection($"Data Source={dbPath};Version=3;");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"❌ Failed to access database file '{dbFile}' at {dbPath}", ex);
            }
        }

        /// <summary>
        /// Utility method to get the absolute path of a database file.
        /// Helpful for debugging/logging.
        /// </summary>
        public static string GetDatabasePath(string dbFile)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string rootPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\.."));
            string dbPath = Path.Combine(rootPath, DatabaseFolderName, dbFile);

            Console.WriteLine($"[DatabaseHelper] Resolved DB path: {dbPath}");
            return dbPath;
        }
    }
}
