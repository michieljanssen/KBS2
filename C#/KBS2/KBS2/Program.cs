using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS2.UI;

namespace KBS2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool a = true;
            
            a = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (a)
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Run(new Window());
            }
            
        }
    }
}
