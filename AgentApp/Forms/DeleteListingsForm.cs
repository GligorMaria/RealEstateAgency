using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;
using RealEstateApp.Core;

namespace AgentApp.Forms
{
    public class DeleteListingsForm : Form
    {
        private DataGridView dgvListings;
        private string agentUsername;

        public DeleteListingsForm(string username)
        {
            agentUsername = username;

            this.Text = "Delete Listings";
            this.ClientSize = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            dgvListings = new DataGridView()
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                BackgroundColor = Color.LavenderBlush
            };

            // Columns
            dgvListings.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Title",
                DataPropertyName = "Title",
                Width = 200
            });
            dgvListings.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Location",
                DataPropertyName = "Location",
                Width = 150
            });
            dgvListings.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Type",
                DataPropertyName = "PropertyType",
                Width = 100
            });

            // Delete button column
            var deleteCol = new DataGridViewButtonColumn()
            {
                HeaderText = "Action",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dgvListings.Columns.Add(deleteCol);

            dgvListings.CellClick += DgvListings_CellClick;

            Controls.Add(dgvListings);

            LoadListings();
        }

        private void LoadListings()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection("AgentListings.db");
                conn.Open();

                var cmd = new SQLiteCommand(@"
                    SELECT Id, Title, Location, PropertyType
                    FROM Listings
                    WHERE AgentUsername=@u
                    ORDER BY Title ASC;", conn);
                cmd.Parameters.AddWithValue("@u", agentUsername);

                var adapter = new SQLiteDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);

                dgvListings.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading listings:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvListings_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvListings.Columns["Action"].Index)
            {
                int listingId = Convert.ToInt32(((DataTable)dgvListings.DataSource).Rows[e.RowIndex]["Id"]);

                var confirm = MessageBox.Show("Delete this listing?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    DeleteListing(listingId);
                    LoadListings();
                }
            }
        }

        private void DeleteListing(int id)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection("AgentListings.db");
                conn.Open();

                var cmd = new SQLiteCommand("DELETE FROM Listings WHERE Id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting listing:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
