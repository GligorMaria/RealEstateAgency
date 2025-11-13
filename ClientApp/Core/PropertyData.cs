using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ClientApp.Core
{
    public static class PropertyData
    {
        public static List<Property> GetAllProperties()
        {
            var properties = new List<Property>();

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT Id, Name, Address, Price, Description FROM Properties";
                    using (var cmd = new SQLiteCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var property = new Property
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2),
                                Price = reader.GetDouble(3), // SQLite REAL → C# double
                                Description = reader.IsDBNull(4) ? "" : reader.GetString(4)
                            };

                            properties.Add(property);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Optional: handle exceptions (log or show message)
                Console.WriteLine("Error fetching properties: " + ex.Message);
            }

            return properties;
        }
    }
}
