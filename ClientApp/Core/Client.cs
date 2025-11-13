using System;
using System.Collections.Generic;

namespace ClientApp.Core
{
    [Serializable]
    public class Client
    {
        // Basic info
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Consider hashing in the future

        // Optional contact info
        public string PhoneNumber { get; set; }
        public string PreferredLocation { get; set; }

        // Client’s saved/favorite properties
        public List<string> FavoritePropertyIds { get; set; } = new List<string>();

        // Constructor
        public Client(string fullName, string email, string password)
        {
            FullName = fullName;
            Email = email;
            Password = password;
        }

        // Parameterless constructor for JSON serialization
        public Client() { }

        // Add/remove favorites
        public void AddFavorite(string propertyId)
        {
            if (!FavoritePropertyIds.Contains(propertyId))
                FavoritePropertyIds.Add(propertyId);
        }

        public void RemoveFavorite(string propertyId)
        {
            FavoritePropertyIds.Remove(propertyId);
        }

        public bool IsFavorite(string propertyId)
        {
            return FavoritePropertyIds.Contains(propertyId);
        }
    }
}
