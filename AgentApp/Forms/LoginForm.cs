using System;
using System.IO;
using System.Windows.Forms;
using AgentApp.Core;
using AgentApp.Forms;

namespace AgentApp.Forms
{
    public class LoginForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;

        private string agentsFile = Path.Combine("Core", "Data", "Agents.json");

        public LoginForm()
        {
            this.Text = "Agent Login";
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblUsername = new Label() { Text = "Username", Location = new System.Drawing.Point(20, 30) };
            txtUsername = new TextBox() { Location = new System.Drawing.Point(120, 30), Width = 200 };

            Label lblPassword = new Label() { Text = "Password", Location = new System.Drawing.Point(20, 70) };
            txtPassword = new TextBox() { Location = new System.Drawing.Point(120, 70), Width = 200, PasswordChar = '*' };

            btnLogin = new Button() { Text = "Login", Location = new System.Drawing.Point(120, 110), Width = 200 };
            btnLogin.Click += BtnLogin_Click;

            Controls.AddRange(new Control[] { lblUsername, txtUsername, lblPassword, txtPassword, btnLogin });
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var agents = DataHandler.Load<Agent>(agentsFile);
            var agent = Array.Find(agents, a => a.Username == username && a.Password == password);

            if (agent != null)
            {
                this.Hide();
                var dashboard = new AgentDashboardForm(agent.Username);
                dashboard.FormClosed += (s, args) => this.Show(); // show login again when dashboard closes
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("Invalid agent credentials.");
            }
        }
    }
}
