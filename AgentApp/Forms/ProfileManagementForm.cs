using System;
using System.IO;
using System.Windows.Forms;
using AgentApp.Core;

namespace AgentApp.Forms
{
    public class ProfileManagementForm : Form
    {
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private Button btnSave;
        private Button btnDelete;
        private string agentUsername;
        private string agentsFile = Path.Combine("Core", "Data", "Agents.json");

        public ProfileManagementForm(string username)
        {
            agentUsername = username;

            this.Text = "Profile Management - " + username;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblFullName = new Label() { Text = "Full Name", Location = new System.Drawing.Point(20, 30) };
            txtFullName = new TextBox() { Location = new System.Drawing.Point(120, 30), Width = 200 };

            Label lblEmail = new Label() { Text = "Email", Location = new System.Drawing.Point(20, 70) };
            txtEmail = new TextBox() { Location = new System.Drawing.Point(120, 70), Width = 200 };

            Label lblPhone = new Label() { Text = "Phone", Location = new System.Drawing.Point(20, 110) };
            txtPhone = new TextBox() { Location = new System.Drawing.Point(120, 110), Width = 200 };

            btnSave = new Button() { Text = "Save Changes", Location = new System.Drawing.Point(20, 160), Width = 140 };
            btnSave.Click += BtnSave_Click;

            btnDelete = new Button() { Text = "Delete Account", Location = new System.Drawing.Point(180, 160), Width = 140, BackColor = System.Drawing.Color.DarkRed, ForeColor = System.Drawing.Color.White };
            btnDelete.Click += BtnDelete_Click;

            Controls.AddRange(new Control[] { lblFullName, txtFullName, lblEmail, txtEmail, lblPhone, txtPhone, btnSave, btnDelete });

            LoadAgentData();
        }

        private void LoadAgentData()
        {
            var agents = DataHandler.Load<Agent>(agentsFile);
            var agent = Array.Find(agents, a => a.Username == agentUsername);

            if (agent != null)
            {
                txtFullName.Text = agent.FullName;
                txtEmail.Text = agent.Email;
                txtPhone.Text = agent.Phone;
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            var agents = DataHandler.Load<Agent>(agentsFile);
            for (int i = 0; i < agents.Length; i++)
            {
                if (agents[i].Username == agentUsername)
                {
                    agents[i].FullName = txtFullName.Text;
                    agents[i].Email = txtEmail.Text;
                    agents[i].Phone = txtPhone.Text;
                    break;
                }
            }

            DataHandler.Save(agentsFile, agents);
            MessageBox.Show("Profile updated successfully.");
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete your account?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                DataHandler.Remove<Agent>(agentsFile, a => a.Username == agentUsername);
                MessageBox.Show("Account deleted.");
                this.Close(); // close profile form, dashboard will remain
            }
        }
    }
}
