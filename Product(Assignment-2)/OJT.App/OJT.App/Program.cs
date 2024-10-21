using OJT.App.Views.Frame;
using System;
using System.Windows.Forms;

namespace OJT.App
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frame());
        }
    }
}
