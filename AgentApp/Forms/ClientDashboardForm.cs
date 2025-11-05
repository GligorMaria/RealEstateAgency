using System.Windows.Forms;

namespace AgentApp.Forms
{
    public class ClientDashboardForm : Form
    {
        public ClientDashboardForm(string username)
        {
            this.Text = $"Client Dashboard - {username}";
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
