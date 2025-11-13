using System.Windows.Forms;
using System.Drawing;

namespace ClientApp.Forms
{
    public class ClientDashboardForm : Form
    {
        private Button btnBrowseListings;
        private Button btnRequestViewing;
        private Button btnMyRequests;
        private Button btnProfile;

        private string clientUsername;

        public ClientDashboardForm(string username)
        {
            clientUsername = username;

            this.Text = "Client Dashboard - " + username;
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(255, 229, 180);

            // --- Browse Listings ---
            btnBrowseListings = new Button();
            btnBrowseListings.Text = "Browse Listings";
            btnBrowseListings.Size = new Size(200, 50);
            btnBrowseListings.Location = new Point(200, 100);
            btnBrowseListings.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnBrowseListings.Click += (sender, e) =>
            {
                var browseForm = new BrowseListingsForm(clientUsername);
                browseForm.ShowDialog();
            };

            // --- Request Viewing ---
            btnRequestViewing = new Button();
            btnRequestViewing.Text = "Request Viewing";
            btnRequestViewing.Size = new Size(200, 50);
            btnRequestViewing.Location = new Point(200, 170);
            btnRequestViewing.Font = new Font("Segoe UI", 10, FontStyle.Bold);
       btnRequestViewing.Click += (sender, e) =>
{
    // For now, pass an empty propertyId until BrowseListingsForm selects one
    var requestForm = new RequestViewingForm(clientUsername, string.Empty);
    requestForm.ShowDialog();
};


            // --- My Requests ---
            btnMyRequests = new Button();
            btnMyRequests.Text = "My Requests";
            btnMyRequests.Size = new Size(200, 50);
            btnMyRequests.Location = new Point(200, 240);
            btnMyRequests.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnMyRequests.Click += (sender, e) =>
            {
                var requestsForm = new MyRequestsForm(clientUsername);
                requestsForm.ShowDialog();
            };

            // --- Profile Management ---
            btnProfile = new Button();
            btnProfile.Text = "Profile Management";
            btnProfile.Size = new Size(200, 50);
            btnProfile.Location = new Point(200, 310);
            btnProfile.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnProfile.Click += (sender, e) =>
            {
                var profileForm = new ClientProfileForm(clientUsername);
                profileForm.ShowDialog();
            };

            // Add buttons to the form
            this.Controls.Add(btnBrowseListings);
            this.Controls.Add(btnRequestViewing);
            this.Controls.Add(btnMyRequests);
            this.Controls.Add(btnProfile);
        }
    }
}
