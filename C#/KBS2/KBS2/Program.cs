using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS2.UI;
using KBS2.data;
using KBS2.model;
using KBS2.views;

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

            //a = false;
            //uitleg pls

            bool studentKijkt = false;
            //Als deze true is wordt de applicatie geopend als student.

            //studentKijkt = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (studentKijkt)
            {
                try
                {
                    Application.Run(new StudentKijkt());
                    //Draai de versie voor studenten
                }
                catch (ObjectDisposedException)
                {
                    Environment.Exit(0);
                }
            }
            else
            {
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
}

