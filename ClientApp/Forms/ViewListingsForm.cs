using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClientApp.Core;

namespace ClientApp
{
    public partial class ViewListingsForm : Form
    {
        private ClientAccount client;
        private List<Property> propertyList;

        public ViewListingsForm(ClientAccount client)
        {
            InitializeComponent();
            this.client = client;

            // Mock data (for now)
            propertyList = new List<Property>
            {
                new Property { Name = "Modern Apartment", Address = "Str. Lalelelor 10", Price = 120000, Description = "2 bedrooms, city view." },
                new Property { Name = "Family House", Address = "Str. Brândușelor 5", Price = 220000, Description = "Spacious 4-bedroom home with garden." },
                new Property { Name = "Studio Downtown", Address = "Bd. Unirii 25", Price = 85000, Description = "Compact studio in city center." }
            };

            LoadProperties();
        }

        private void LoadProperties()
        {
            listingsPanel.Controls.Clear();
            int y = 20;

            foreach (var property in propertyList)
            {
                Panel card = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new System.Drawing.Point(20, y),
                    Size = new System.Drawing.Size(440, 120)
                };

                Label nameLabel = new Label
                {
                    Text = property.Name,
                    Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                    Location = new System.Drawing.Point(10, 10),
                    AutoSize = true
                };

                Label addressLabel = new Label
                {
                    Text = "📍 " + property.Address,
                    Location = new System.Drawing.Point(10, 40),
                    AutoSize = true
                };

                Label priceLabel = new Label
                {
                    Text = $"💰 {property.Price:C0}",
                    Location = new System.Drawing.Point(10, 65),
                    AutoSize = true
                };

                Label descLabel = new Label
                {
                    Text = property.Description,
                    Location = new System.Drawing.Point(10, 90),
                    AutoSize = true
                };

                Button favButton = new Button
                {
                    Text = "❤️ Favorite",
                    Location = new System.Drawing.Point(340, 40),
                    Size = new System.Drawing.Size(80, 30)
                };
                favButton.Click += (s, e) => AddToFavorites(property);

                card.Controls.Add(nameLabel);
                card.Controls.Add(addressLabel);
                card.Controls.Add(priceLabel);
                card.Controls.Add(descLabel);
                card.Controls.Add(favButton);

                listingsPanel.Controls.Add(card);
                y += 140;
            }
        }

        private void AddToFavorites(Property property)
        {
            MessageBox.Show($"{property.Name} added to favorites!", "Success");
            // TODO: Save to client's favorites (e.g. database or list)
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
