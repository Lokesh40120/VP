using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace My_Database
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Global exception handlers to capture runtime errors and write them to a log file
            Application.ThreadException += (s, e) => HandleException(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) => HandleException(e.ExceptionObject as Exception);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Login());
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private static void HandleException(Exception ex)
        {
            try
            {
                if (ex == null) return;
                string path = Path.Combine(Application.StartupPath, "error.log");
                string text = $"[{DateTime.Now:O}] {ex}\r\n";
                File.AppendAllText(path, text);
                MessageBox.Show(ex.ToString(), "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                // swallow logging errors
            }
        }
    }
}
