using System.Text.Json;
using System.IO;
using AgentApp.Core.Shared;

namespace AgentApp.Core
{
    public class PropertyListing
    {
        public string AgentUsername { get; set; } = "";
        public string Title { get; set; } = "";
        public PropertySize Size { get; set; }
        public decimal Price { get; set; }

        public static void Save(PropertyListing listing)
        {
            string folder = Path.Combine("Core", "Data", "Listings");
            Directory.CreateDirectory(folder);

            string file = Path.Combine(folder, $"{Guid.NewGuid()}.json");
            File.WriteAllText(file, JsonSerializer.Serialize(listing));
        }
    }
}
