namespace ClientApp
{
    partial class ViewListingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel listingsPanel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label titleLabel;

        private void InitializeComponent()
        {
            this.listingsPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // titleLabel
            this.titleLabel.Text = "🏡 Available Properties";
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(20, 10);
            this.titleLabel.AutoSize = true;

            // listingsPanel
            this.listingsPanel.AutoScroll = true;
            this.listingsPanel.Location = new System.Drawing.Point(10, 50);
            this.listingsPanel.Size = new System.Drawing.Size(480, 380);

            // backButton
            this.backButton.Text = "⬅ Back";
            this.backButton.Location = new System.Drawing.Point(390, 440);
            this.backButton.Size = new System.Drawing.Size(80, 30);
            this.backButton.Click += new System.EventHandler(this.backButton_Click);

            // Form setup
            this.ClientSize = new System.Drawing.Size(500, 480);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.listingsPanel);
            this.Controls.Add(this.backButton);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Listings";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
