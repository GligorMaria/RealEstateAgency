using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgentApp.Forms
{
    public class AgentDashboardForm : Form
    {
        private Button btnListings;
        private Button btnViewings;
        private Button btnProfile;
        private Button btnLogout;
        private Button btnClose;
        private string agentUsername;

        public AgentDashboardForm(string username)
        {
            agentUsername = username;

            // Form styling
            this.Text = "Agent Dashboard - " + username;
            this.ClientSize = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None; // custom close button
            this.DoubleBuffered = true;

            // Welcome label
            Label lblWelcome = new Label()
            {
                Text = $"Welcome, {username}",
                Location = new Point(100, 30),
                AutoSize = true,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };

            // View Listings button
            btnListings = new Button()
            {
                Text = "View Listings",
                Location = new Point(120, 80),
                Size = new Size(160, 40),
                BackColor = Color.DeepPink,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            btnListings.FlatAppearance.BorderSize = 0;
            btnListings.Click += (s, e) =>
            {
                var listingsForm = new ViewListingsForm(username);
                listingsForm.ShowDialog();
            };

            // Manage Viewings button
            btnViewings = new Button()
            {
                Text = "Manage Viewings",
                Location = new Point(120, 130),
                Size = new Size(160, 40),
                BackColor = Color.MediumPurple,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            btnViewings.FlatAppearance.BorderSize = 0;
            btnViewings.Click += (s, e) =>
            {
                var viewingsForm = new ViewingsForm(username);
                viewingsForm.ShowDialog();
            };

            // Profile Management button
            btnProfile = new Button()
            {
                Text = "Profile Management",
                Location = new Point(120, 180),
                Size = new Size(160, 40),
                BackColor = Color.DeepPink,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.Click += (s, e) =>
            {
                var profileForm = new ProfileManagementForm(username);
                profileForm.ShowDialog();
            };

            // Logout button
            btnLogout = new Button()
            {
                Text = "Logout",
                Location = new Point(120, 230),
                Size = new Size(160, 40),
                BackColor = Color.DarkRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += (s, e) =>
            {
                this.Close(); // triggers FormClosed event in LoginForm to show login again
            };

            // Classic "X" close button
            btnClose = new Button()
            {
                Text = "X",
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(this.ClientSize.Width - 40, 10),
                Size = new Size(30, 30),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();

            // Add controls
            Controls.Add(lblWelcome);
            Controls.Add(btnListings);
            Controls.Add(btnViewings);
            Controls.Add(btnProfile);
            Controls.Add(btnLogout);
            Controls.Add(btnClose);
        }

        // Gradient background
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
    }
}
