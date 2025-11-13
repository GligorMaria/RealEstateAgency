using System;
using System.IO;
using System.Linq; // needed for .Where
using System.Text.Json;
using System.Windows.Forms;

namespace ClientApp.Forms
{
    public class ClientProfileForm : Form
    {
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtPassword;
        private Button btnSave;
        private Button btnDelete;

        private readonly string clientUsername;
        private readonly string clientsFile = Path.Combine("Core", "Data", "Clients.json");

        public ClientProfileForm(string username)
        {
            clientUsername = username;

            this.Text = "Client Profile Management - " + username;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblFullName = new Label() { Text = "Full Name", Location = new System.Drawing.Point(20, 30) };
            txtFullName = new TextBox() { Location = new System.Drawing.Point(120, 30), Width = 200 };

            Label lblEmail = new Label() { Text = "Email", Location = new System.Drawing.Point(20, 70) };
            txtEmail = new TextBox() { Location = new System.Drawing.Point(120, 70), Width = 200 };

            Label lblPhone = new Label() { Text = "Phone", Location = new System.Drawing.Point(20, 110) };
            txtPhone = new TextBox() { Location = new System.Drawing.Point(120, 110), Width = 200 };

            Label lblPassword = new Label() { Text = "Password", Location = new System.Drawing.Point(20, 150) };
            txtPassword = new TextBox() { Location = new System.Drawing.Point(120, 150), Width = 200 };

            btnSave = new Button() { Text = "Save Changes", Location = new System.Drawing.Point(120, 200), Width = 200 };
            btnSave.Click += BtnSave_Click;

            btnDelete = new Button() { Text = "Delete Account", Location = new System.Drawing.Point(120, 240), Width = 200 };
            btnDelete.Click += BtnDelete_Click;

            Controls.AddRange(new Control[] { lblFullName, txtFullName, lblEmail, txtEmail, lblPhone, txtPhone, lblPassword, txtPassword, btnSave, btnDelete });

            LoadProfile();
        }

        private void LoadProfile()
        {
            if (!File.Exists(clientsFile)) return;

            try
            {
                var json = File.ReadAllText(clientsFile);
                var clients = JsonSerializer.Deserialize<Client[]>(json) ?? Array.Empty<Client>();

                var client = Array.Find(clients, c => c.Username == clientUsername);
                if (client != null)
                {
                    txtFullName.Text = client.FullName;
                    txtEmail.Text = client.Email;
                    txtPhone.Text = client.Phone;
                    txtPassword.Text = client.Password;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (!File.Exists(clientsFile)) return;

            try
            {
                var json = File.ReadAllText(clientsFile);
                var clients = JsonSerializer.Deserialize<Client[]>(json) ?? Array.Empty<Client>();

                var client = Array.Find(clients, c => c.Username == clientUsername);
                if (client != null)
                {
                    client.FullName = txtFullName.Text;
                    client.Email = txtEmail.Text;
                    client.Phone = txtPhone.Text;
                    client.Password = txtPassword.Text;
                }

                File.WriteAllText(clientsFile, JsonSerializer.Serialize(clients, new JsonSerializerOptions { WriteIndented = true }));
                MessageBox.Show("Profile updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving profile: " + ex.Message);
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (!File.Exists(clientsFile)) return;

            try
            {
                var json = File.ReadAllText(clientsFile);
                var clients = JsonSerializer.Deserialize<Client[]>(json) ?? Array.Empty<Client>();

                clients = clients.Where(c => c.Username != clientUsername).ToArray();

                File.WriteAllText(clientsFile, JsonSerializer.Serialize(clients, new JsonSerializerOptions { WriteIndented = true }));
                MessageBox.Show("Account deleted successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting account: " + ex.Message);
            }
        }
    }

    // Client model
    public class Client
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
