using System;
using System.Windows.Forms;
using ClientApp.Core;

namespace ClientApp.Forms
{
    public partial class ClientDashboardForm : Form
    {
        private ClientAccount clientAccount;

        public ClientDashboardForm(ClientAccount clientAccount)
        {
            this.clientAccount = clientAccount;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Text = $"Dashboard - {clientAccount.FullName}";
            this.ResumeLayout(false);
        }
    }
}
