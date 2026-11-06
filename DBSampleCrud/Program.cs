using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBSampleCrud
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
            // Show login dialog first
            using (var login = new Form2())
            {
                var dr = login.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Application.Run(new Form1());
                }
                else
                {
                    // Exit application if login cancelled/failed
                    return;
                }
            }
        }
    }
}
