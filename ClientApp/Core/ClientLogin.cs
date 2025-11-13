using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace ClientApp.Core
{
    public class ClientLogin
    {
        private static readonly string DataPath = @"C:\Ana\RealEstateApp\ClientApp\Core\Data\Clients.json";

        public static List<ClientAccount> LoadClients()
        {
            try
            {
                if (!File.Exists(DataPath))
                {
                    // Create an empty file if not exists
                    Directory.CreateDirectory(Path.GetDirectoryName(DataPath)!);
                    File.WriteAllText(DataPath, "[]");
                }

                string json = File.ReadAllText(DataPath);
                var clients = JsonSerializer.Deserialize<List<ClientAccount>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return clients ?? new();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clients: {ex.Message}");
                return new List<ClientAccount>();
            }
        }

        public static void SaveClients(List<ClientAccount> clients)
        {
            try
            {
                string json = JsonSerializer.Serialize(clients, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(DataPath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving clients: {ex.Message}");
            }
        }

        public static ClientAccount? Validate(string username, string password)
        {
            var clients = LoadClients();
            foreach (var client in clients)
            {
                if (client.Username == username && client.Password == password)
                    return client;
            }
            return null;
        }

        public static bool AddClient(ClientAccount newClient)
        {
            var clients = LoadClients();

            if (clients.Exists(c => c.Username == newClient.Username || c.Email == newClient.Email))
            {
                MessageBox.Show("Username or email already exists.");
                return false;
            }

            clients.Add(newClient);
            SaveClients(clients);
            return true;
        }
    }
}
