using System;
using System.Windows.Forms;
using AgentApp.Core;
using ClientApp.Core;

namespace AgentApp.Forms
{
    public class LoginForm : Form
    {
    private Label? lblUsername;
    private Label? lblPassword;
    private Label? lblAccountType;
    private TextBox? txtUsername;
    private TextBox? txtPassword;
    private ComboBox? cmbAccountType;
    private Button? btnLogin;


        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Login";
            this.Size = new System.Drawing.Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(255, 123, 0);
            
            lblUsername = new Label();
            lblUsername.Text = "Username";
            lblUsername.Location = new System.Drawing.Point(50, 30);
            lblUsername.AutoSize = true;

            txtUsername = new TextBox();
            txtUsername.Location = new System.Drawing.Point(150, 30);
            txtUsername.Width = 180;

            lblPassword = new Label();
            lblPassword.Text = "Password";
            lblPassword.Location = new System.Drawing.Point(50, 70);
            lblPassword.AutoSize = true;

            txtPassword = new TextBox();
            txtPassword.Location = new System.Drawing.Point(150, 70);
            txtPassword.Width = 180;
            txtPassword.UseSystemPasswordChar = true;

            cmbAccountType = new ComboBox();
            cmbAccountType.Location = new System.Drawing.Point(150, 110);
            cmbAccountType.Width = 180;
            cmbAccountType.Items.AddRange(new string[] { "Agent", "Client" });
            cmbAccountType.SelectedIndex = 0;

            btnLogin = new Button();
            btnLogin.Text = "Login";
            btnLogin.Size = new System.Drawing.Size(120, 40);
            btnLogin.Location = new System.Drawing.Point(150, 160);
            btnLogin.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

            btnLogin.Click += (sender, e) =>
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string accountType = cmbAccountType?.SelectedItem?.ToString() ?? "";


                if (accountType == "Agent")
                {
                    var account = AgentLogin.Validate(username, password);
                    if (account != null)
                    {
                        if (!ProfileManager.ProfileExists(account.Username))
                        {
                            new ProfileSetupForm(account.Username).ShowDialog();
                        }

                        this.Hide();
                        var dashboard = new AgentDashboardForm(account.Username);
                        dashboard.FormClosed += (s, args) => this.Close();
                        dashboard.Show();
                        return;
                    }
                }
                else if (accountType == "Client")
                {
                    var account = ClientLogin.Validate(username, password);
                    if (account != null)
                    {
                       
                        if (!ProfileManager.ProfileExists(account.Username))
                        {
                            new ProfileSetupForm(account.Username).ShowDialog();
                        }

                        new ClientDashboardForm(account.Username).Show();
                        this.Hide();
                        return;
                    }
                }

                MessageBox.Show("Invalid username or password.");
            };

   
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(lblAccountType);
            this.Controls.Add(cmbAccountType);
            this.Controls.Add(btnLogin);
        }

    
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }
    }
}
