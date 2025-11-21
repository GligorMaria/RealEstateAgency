using System;
using System.Windows.Forms;
using AgentApp.Forms;


namespace AgentApp
{
    internal static class Program
    {
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new StartUpForm());

        }
    }
}
