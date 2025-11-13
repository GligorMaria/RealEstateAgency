using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using AgentApp.Core;

namespace AgentApp.Forms
{
    public class ViewListingsForm : Form
    {
        private ListView listView;
        private Button btnConfirm, btnReject, btnMissed;
        private string agentUsername;
        private string viewingsPath = Path.Combine("Core", "Data", "Viewings");

        public ViewListingsForm(string username)
        {
            agentUsername = username;

            this.Text = "Manage Viewings - " + username;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            listView = new ListView()
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(650, 250)
            };

            listView.Columns.Add("ViewingId", 120);
            listView.Columns.Add("PropertyId", 120);
            listView.Columns.Add("Client", 120);
            listView.Columns.Add("Date/Time", 150);
            listView.Columns.Add("Status", 100);

            btnConfirm = new Button() { Text = "Confirm", Location = new System.Drawing.Point(20, 300), Size = new System.Drawing.Size(150, 40) };
            btnReject = new Button() { Text = "Reject", Location = new System.Drawing.Point(180, 300), Size = new System.Drawing.Size(150, 40) };
            btnMissed = new Button() { Text = "Mark Missed", Location = new System.Drawing.Point(340, 300), Size = new System.Drawing.Size(150, 40) };

            btnConfirm.Click += (s, e) => UpdateStatus("Confirmed");
            btnReject.Click += (s, e) => UpdateStatus("Rejected");
            btnMissed.Click += (s, e) => UpdateStatus("Missed");

            Controls.Add(listView);
            Controls.Add(btnConfirm);
            Controls.Add(btnReject);
            Controls.Add(btnMissed);

            LoadViewings();
        }

        private void LoadViewings()
        {
            listView.Items.Clear();

            if (!Directory.Exists(viewingsPath))
                Directory.CreateDirectory(viewingsPath);

            foreach (var file in Directory.GetFiles(viewingsPath, "*.json"))
            {
                try
                {
                    var json = File.ReadAllText(file);
                    var viewing = JsonSerializer.Deserialize<Viewing>(json);

                    if (viewing != null && viewing.AgentUsername == agentUsername)
                    {
                        var item = new ListViewItem(viewing.ViewingId);
                        item.SubItems.Add(viewing.PropertyId);
                        item.SubItems.Add(viewing.ClientUsername);
                        item.SubItems.Add(viewing.DateTime.ToString("g"));
                        item.SubItems.Add(viewing.Status);
                        item.Tag = file; // store full file path for safe retrieval
                        listView.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading viewing: " + ex.Message);
                }
            }
        }

        private void UpdateStatus(string newStatus)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a viewing first.");
                return;
            }

            var selected = listView.SelectedItems[0];
            if (selected.Tag is not string filePath)
            {
                MessageBox.Show("No file path associated with this viewing.");
                return;
            }

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Viewing file not found.");
                return;
            }

            try
            {
                var json = File.ReadAllText(filePath);
                var viewing = JsonSerializer.Deserialize<Viewing>(json);

                if (viewing != null)
                {
                    viewing.Status = newStatus;
                    var updatedJson = JsonSerializer.Serialize(viewing, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(filePath, updatedJson);

                    MessageBox.Show($"Viewing marked as {newStatus}!");
                    LoadViewings();
                }
                else
                {
                    MessageBox.Show("Error: Viewing data could not be loaded.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message);
            }
        }
    }
}
