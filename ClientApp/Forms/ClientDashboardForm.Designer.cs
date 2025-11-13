namespace ClientApp
{
    partial class ClientDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Button viewListingsButton;
        private System.Windows.Forms.Button favoritesButton;
        private System.Windows.Forms.Button requestMeetingButton;
        private System.Windows.Forms.Button logoutButton;

        private void InitializeComponent()
        {
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.viewListingsButton = new System.Windows.Forms.Button();
            this.favoritesButton = new System.Windows.Forms.Button();
            this.requestMeetingButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Welcome label
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.welcomeLabel.Location = new System.Drawing.Point(50, 30);
            this.welcomeLabel.AutoSize = true;

            // View Listings
            this.viewListingsButton.Text = "🏡 View Listings";
            this.viewListingsButton.Location = new System.Drawing.Point(100, 90);
            this.viewListingsButton.Size = new System.Drawing.Size(180, 40);
            this.viewListingsButton.Click += new System.EventHandler(this.viewListingsButton_Click);

            // Favorites
            this.favoritesButton.Text = "💖 Favorite Properties";
            this.favoritesButton.Location = new System.Drawing.Point(100, 150);
            this.favoritesButton.Size = new System.Drawing.Size(180, 40);
            this.favoritesButton.Click += new System.EventHandler(this.favoritesButton_Click);

            // Request Meeting
            this.requestMeetingButton.Text = "📅 Request Meeting";
            this.requestMeetingButton.Location = new System.Drawing.Point(100, 210);
            this.requestMeetingButton.Size = new System.Drawing.Size(180, 40);
            this.requestMeetingButton.Click += new System.EventHandler(this.requestMeetingButton_Click);

            // Logout
            this.logoutButton.Text = "🚪 Logout";
            this.logoutButton.Location = new System.Drawing.Point(100, 270);
            this.logoutButton.Size = new System.Drawing.Size(180, 35);
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);

            // Form setup
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.viewListingsButton);
            this.Controls.Add(this.favoritesButton);
            this.Controls.Add(this.requestMeetingButton);
            this.Controls.Add(this.logoutButton);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Dashboard";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
