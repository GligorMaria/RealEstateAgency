using System.Windows.Forms;
using System.Drawing;

namespace AgentApp.Forms
{
    public class AgentDashboardForm : Form
    {
        private Button btnAddListing;
        private Button btnViewListings;
        private Button btnDeleteListing;

        private string agentUsername;

        public AgentDashboardForm(string username)
        {
            agentUsername = username;

            this.Text = "Agent Dashboard - " + username;
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(0, 229, 255);

            btnAddListing = new Button();
            btnAddListing.Text = "Add Listing";
            btnAddListing.Size = new Size(200, 50);
            btnAddListing.Location = new Point(200, 150);
            btnAddListing.Font = new Font("Segoe UI", 10, FontStyle.Bold);

           
            btnAddListing.Click += (sender, e) =>
            {
                var listingForm = new PropertyListingForm(agentUsername);
                listingForm.ShowDialog();
            };

            btnViewListings = new Button();
            btnViewListings.Text = "View Listings";
            btnViewListings.Size = new Size(200, 50);
            btnViewListings.Location = new Point(200, 220);
            btnViewListings.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btnViewListings.Click += (sender, e) =>
            {
                var viewForm = new ViewListingsForm(agentUsername);
                viewForm.ShowDialog();
            };
            
            btnDeleteListing = new Button();
            btnDeleteListing.Text = "Delete Listing";
            btnDeleteListing.Size = new Size(200, 50);
            btnDeleteListing.Location = new Point(200, 290); 
            btnDeleteListing.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            btnDeleteListing.Click += (sender, e) =>
            {
                var deleteForm = new PropertyListingForm(agentUsername);
                deleteForm.ShowDialog();
            };


            this.Controls.Add(btnAddListing);
            this.Controls.Add(btnViewListings);
        }
    }
}
