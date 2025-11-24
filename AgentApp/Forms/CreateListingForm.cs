using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using RealEstateApp.Core;

namespace AgentApp.Forms
{
    public class CreateListingForm : Form
    {
        private TextBox txtTitle;
        private TextBox txtDescription;
        private TextBox txtPrice;
        private TextBox txtLocation;
        private ComboBox cmbType;
        private Button btnSubmit;
        private Button btnCancel;
        private string agentUsername;

        public CreateListingForm(string username)
        {
            agentUsername = username;

            this.Text = "Create Listing";
            this.ClientSize = new Size(440, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;

            // Stronger input color
            Color inputColor = Color.LightPink;

            // Title
            Label lblTitle = new Label()
            {
                Text = "Title",
                Location = new Point(40, 40),
                ForeColor = Color.White,
                BackColor = Color.DeepSkyBlue, // colorful background
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            txtTitle = new TextBox()
            {
                Location = new Point(150, 40),
                Width = 240,
                BackColor = inputColor,
                ForeColor = Color.DarkSlateGray
            };

            // Description (larger box)
            Label lblDescription = new Label()
            {
                Text = "Description",
                Location = new Point(40, 90),
                ForeColor = Color.White,
                BackColor = Color.LimeGreen, // colorful background
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            txtDescription = new TextBox()
            {
                Location = new Point(150, 90),
                Width = 240,
                Height = 100, // larger height
                Multiline = true,
                BackColor = inputColor,
                ForeColor = Color.DarkSlateGray,
                ScrollBars = ScrollBars.Vertical
            };

            // Price
            Label lblPrice = new Label()
            {
                Text = "Price",
                Location = new Point(40, 210),
                ForeColor = Color.White,
                BackColor = Color.Gold, // colorful background
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            txtPrice = new TextBox()
            {
                Location = new Point(150, 210),
                Width = 240,
                BackColor = inputColor,
                ForeColor = Color.DarkSlateGray
            };

            // Location
            Label lblLocation = new Label()
            {
                Text = "Location",
                Location = new Point(40, 250),
                ForeColor = Color.White,
                BackColor = Color.OrangeRed, // colorful background
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            txtLocation = new TextBox()
            {
                Location = new Point(150, 250),
                Width = 240,
                BackColor = inputColor,
                ForeColor = Color.DarkSlateGray
            };

            // Property Type
            Label lblType = new Label()
            {
                Text = "Type",
                Location = new Point(40, 290),
                ForeColor = Color.White,
                BackColor = Color.MediumOrchid, // colorful background
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            cmbType = new ComboBox()
            {
                Location = new Point(150, 290),
                Width = 240,
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.Plum,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            cmbType.Items.AddRange(new string[] { "Apartment", "House", "Duplex" });
            cmbType.SelectedIndex = 0;

            // Submit button
            btnSubmit = new Button()
            {
                Text = "Submit",
                Location = new Point(100, 360),
                Width = 100,
                Height = 40,
                BackColor = Color.DeepPink,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Click += BtnSubmit_Click;

            // Cancel button
            btnCancel = new Button()
            {
                Text = "Cancel",
                Location = new Point(240, 360),
                Width = 100,
                Height = 40,
                BackColor = Color.MediumPurple,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => this.Close();

            Controls.AddRange(new Control[]
            {
                lblTitle, txtTitle,
                lblDescription, txtDescription,
                lblPrice, txtPrice,
                lblLocation, txtLocation,
                lblType, cmbType,
                btnSubmit, btnCancel
            });
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var rect = this.ClientRectangle;
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                rect, Color.MediumPurple, Color.DeepPink, 45F))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
            base.OnPaint(e);
        }

        private void BtnSubmit_Click(object? sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            string priceText = txtPrice.Text.Trim();
            string location = txtLocation.Text.Trim();
            string type = cmbType.SelectedItem?.ToString() ?? "Unknown";

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(priceText))
            {
                MessageBox.Show("Title and price are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Invalid price format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection("AgentListings.db");
                conn.Open();

                var cmd = new SQLiteCommand(@"
                    CREATE TABLE IF NOT EXISTS Listings (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        AgentUsername TEXT,
                        Title TEXT,
                        Description TEXT,
                        Price REAL,
                        Location TEXT,
                        PropertyType TEXT
                    );", conn);
                cmd.ExecuteNonQuery();

                var insertCmd = new SQLiteCommand(@"
                    INSERT INTO Listings (AgentUsername, Title, Description, Price, Location, PropertyType)
                    VALUES (@u, @t, @d, @p, @l, @pt);", conn);
                insertCmd.Parameters.AddWithValue("@u", agentUsername);
                insertCmd.Parameters.AddWithValue("@t", title);
                insertCmd.Parameters.AddWithValue("@d", description);
                insertCmd.Parameters.AddWithValue("@p", price);
                insertCmd.Parameters.AddWithValue("@l", location);
                insertCmd.Parameters.AddWithValue("@pt", type);

                insertCmd.ExecuteNonQuery();

                MessageBox.Show("Listing created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating listing:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
