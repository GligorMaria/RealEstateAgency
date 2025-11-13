namespace ClientApp
{
    partial class CreateAccountForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox fullnameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button backButton;

        private void InitializeComponent()
        {
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.fullnameTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Example control setup
            this.usernameTextBox.Location = new System.Drawing.Point(140, 30);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(150, 20);

            // (add other controls same way…)

            this.registerButton.Text = "Register";
            this.registerButton.Location = new System.Drawing.Point(140, 230);
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);

            this.backButton.Text = "Back";
            this.backButton.Location = new System.Drawing.Point(140, 270);
            this.backButton.Click += new System.EventHandler(this.backButton_Click);

            // Add all controls to form
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.fullnameTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.backButton);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
