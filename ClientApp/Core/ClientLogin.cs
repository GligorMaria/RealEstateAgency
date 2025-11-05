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

            if (!File.Exists(DataPath))
            {
                MessageBox.Show("File does not exist.");
                return new List<ClientAccount>();
            }

            string json = File.ReadAllText(DataPath);
            var clients = JsonSerializer.Deserialize<List<ClientAccount>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return clients ?? new();
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
    }
}
