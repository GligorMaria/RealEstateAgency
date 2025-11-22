using System;
using System.Windows.Forms;
using AgentApp.Forms;
using RealEstateApp.Core;
using System.Data.SQLite;

namespace AgentApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                SQLitePCL.Batteries_V2.Init();

                // ✅ Run initializer
                DatabaseInitializer.Initialize();
                MessageBox.Show("✅ DatabaseInitializer ran successfully", "Startup Check");

                // ✅ Confirm DB path
                string dbPath = DatabaseHelper.GetDatabasePath("AgentAccounts.db");
                MessageBox.Show($"Using AgentAccounts.db at:\n{dbPath}", "Path Check");

                // ✅ Confirm Agents table exists
                using var conn = DatabaseHelper.GetConnection("AgentAccounts.db");
                conn.Open();
                var cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='Agents';", conn);
                var result = cmd.ExecuteScalar();

                if (result == null || result.ToString() != "Agents")
                {
                    MessageBox.Show("❌ Agents table NOT found in AgentAccounts.db", "DB Check");
                }
                else
                {
                    MessageBox.Show("✅ Agents table exists in AgentAccounts.db", "DB Check");
                }

                // ✅ Launch UI
                ApplicationConfiguration.Initialize();
                Application.Run(new StartUpForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Fatal error:\n" + ex.Message, "Startup Crash");
            }
        }
    }
}
