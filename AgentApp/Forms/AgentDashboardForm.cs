using System;
using System.Windows.Forms;

namespace AgentApp.Forms
{
    public class AgentDashboardForm : Form
    {
        private Button btnListings;
        private Button btnViewings;
        private Button btnProfile;
        private Button btnLogout;
        private string agentUsername;

        public AgentDashboardForm(string username)
        {
            agentUsername = username;

            this.Text = "Agent Dashboard - " + username;
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(250, 134, 208);

            Label lblWelcome = new Label()
            {
                Text = $"Welcome, {username}",
                Location = new System.Drawing.Point(120, 30),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.White
            };

            btnListings = new Button()
            {
                Text = "View Listings",
                Location = new System.Drawing.Point(120, 80),
                Size = new System.Drawing.Size(150, 40),
                BackColor = System.Drawing.Color.FromArgb(217, 184, 128, 1),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold)
            };
            btnListings.Click += (s, e) =>
            {
                var listingsForm = new ViewListingsForm(username);
                listingsForm.ShowDialog();
            };

            btnViewings = new Button()
            {
                Text = "Manage Viewings",
                Location = new System.Drawing.Point(120, 130),
                Size = new System.Drawing.Size(150, 40),
                BackColor = System.Drawing.Color.FromArgb(217, 184, 128, 1),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold)
            };
            btnViewings.Click += (s, e) =>
            {
                var viewingsForm = new ViewingsForm(username);
                viewingsForm.ShowDialog();
            };

            btnProfile = new Button()
            {
                Text = "Profile Management",
                Location = new System.Drawing.Point(120, 180),
                Size = new System.Drawing.Size(150, 40),
                BackColor = System.Drawing.Color.FromArgb(217, 184, 128, 1),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold)
            };
            btnProfile.Click += (s, e) =>
            {
                var profileForm = new ProfileManagementForm(username);
                profileForm.ShowDialog();
            };

            // ✅ Logout button
            btnLogout = new Button()
            {
                Text = "Logout",
                Location = new System.Drawing.Point(120, 230),
                Size = new System.Drawing.Size(150, 40),
                BackColor = System.Drawing.Color.DarkRed,
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold)
            };
            btnLogout.Click += (s, e) =>
            {
                this.Close(); // triggers FormClosed event in LoginForm to show login again
            };

            Controls.Add(lblWelcome);
            Controls.Add(btnListings);
            Controls.Add(btnViewings);
            Controls.Add(btnProfile);
            Controls.Add(btnLogout);
        }
    }
}
