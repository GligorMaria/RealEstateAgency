using System;
using System.Windows.Forms;

namespace ClientApp
{
    partial class ClientLoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button registerButton;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // usernameLabel
            this.usernameLabel.Text = "Username:";
            this.usernameLabel.Location = new System.Drawing.Point(50, 40);

            // passwordLabel
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.Location = new System.Drawing.Point(50, 90);

            // usernameTextBox
            this.usernameTextBox.Location = new System.Drawing.Point(150, 40);
            this.usernameTextBox.Width = 150;

            // passwordTextBox
            this.passwordTextBox.Location = new System.Drawing.Point(150, 90);
            this.passwordTextBox.Width = 150;
            this.passwordTextBox.PasswordChar = '*';

            // loginButton
            this.loginButton.Text = "Login";
            this.loginButton.Location = new System.Drawing.Point(150, 140);
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);

            // registerButton
            this.registerButton.Text = "Create Account";
            this.registerButton.Location = new System.Drawing.Point(150, 180);
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(380, 250);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.registerButton);
            this.Text = "Client Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
