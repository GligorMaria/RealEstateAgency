using System;
using System.Windows.Forms;
using ClientApp.Core;

namespace ClientApp
{
    public partial class CreateAccountForm : Form
    {
        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string fullname = fullnameTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();
            string phone = phoneTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            var newClient = new ClientAccount
            {
                Username = username,
                Password = password,
                FullName = fullname,
                Email = email,
                Phone = phone
            };

            bool success = ClientLogin.AddClient(newClient);

            if (success)
            {
                MessageBox.Show("Account created successfully! You can now log in.");
                var loginForm = new ClientLoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var loginForm = new ClientLoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
