using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using AgentApp.Core;

namespace AgentApp.Forms
{
    public class ViewListingsForm : Form
    {
        private ListView? listView;

        public ViewListingsForm(string agentUsername)
        {
            this.Text = "Your Property Listings";
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            listView = new ListView()
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(550, 340)
            };

            listView.Columns.Add("Title", 200);
            listView.Columns.Add("Size", 100);
            listView.Columns.Add("Price", 100);

            LoadListings(agentUsername);

            Controls.Add(listView);
        }

        private void LoadListings(string agentUsername)
        {
            string folder = Path.Combine("Core", "Data", "Listings");
            if (!Directory.Exists(folder)) return;

            var files = Directory.GetFiles(folder, "*.json");
            foreach (var file in files)
            {
                var json = File.ReadAllText(file);
                var listing = JsonSerializer.Deserialize<PropertyListing>(json);
                if (listing != null && listing.AgentUsername == agentUsername)
                {
                    var item = new ListViewItem(listing.Title);
                    item.SubItems.Add(listing.Size.ToString());
                    item.SubItems.Add($"${listing.Price:N0}");
                    listView?.Items.Add(item);
                }
            }
        }
    }
}
