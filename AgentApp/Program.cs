using System;
using System.Windows.Forms;
using AgentApp.Forms;
//using AgentApp.Forms.Startup;


namespace AgentApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainMenuForm(new LoginForm()));

        }
    }
}
