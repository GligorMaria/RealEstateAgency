using System;
using System.Windows.Forms;

namespace ClientApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ClientLoginForm()); // start with client login
        }
    }
}
