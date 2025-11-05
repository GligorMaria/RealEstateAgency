using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using AgentApp.Core;

namespace AgentApp.Forms
{
    public class CreateAccountForm : Form
    {
        private Label ?lblUsername;
        private Label ?lblPassword;
        private Label ?lblConfirm;
        private TextBox ?txtUsername;
        private TextBox ?txtPassword;
        private TextBox ?txtConfirm;
        private Button ?btnCreate;
        private Button ?btnCancel;

        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Create Account";
            this.ClientSize = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(255, 123, 0);

            lblUsername = new Label() { Text = "Username", Location = new Point(50, 30), AutoSize = true };
            txtUsername = new TextBox() { Location = new Point(150, 30), Width = 180 };

            lblPassword = new Label() { Text = "Password", Location = new Point(50, 70), AutoSize = true };
            txtPassword = new TextBox() { Location = new Point(150, 70), Width = 180, UseSystemPasswordChar = true };

            lblConfirm = new Label() { Text = "Confirm Password", Location = new Point(50, 110), AutoSize = true };
            txtConfirm = new TextBox() { Location = new Point(180, 110), Width = 180, UseSystemPasswordChar = true };

            btnCreate = new Button()
            {
                Text = "Create",
                Location = new Point(80, 180),
                Size = new Size(120, 50),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };

            btnCancel = new Button()
            {
                Text = "Cancel",
                Location = new Point(200, 180),
                Size = new Size(120, 50),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };

            btnCreate.Click += (s, e) =>
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string confirm = txtConfirm.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Username and password are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password != confirm)
                {
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var agents = AgentLogin.LoadAgents();
                if (agents.Any(a => a.Username == username))
                {
                    MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                agents.Add(new AgentAccount { Username = username, Password = password });

                string json = JsonSerializer.Serialize(agents, new JsonSerializerOptions { WriteIndented = true });
                string path = Path.Combine("Core", "Data", "Agents.json");
                string folder = Path.GetDirectoryName(path)!;

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                File.WriteAllText(path, json);

                MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            };

            btnCancel.Click += (s, e) => this.Close();

            Controls.AddRange(new Control[] {
                lblUsername, txtUsername,
                lblPassword, txtPassword,
                lblConfirm, txtConfirm,
                btnCreate, btnCancel
            });
        }
    }
}
