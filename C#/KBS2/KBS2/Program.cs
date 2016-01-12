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

            //Als deze true is wordt de applicatie geopend als student.
            StudentView.studentKijkt = false;
            //StudentView.studentKijkt = true;

            //Visuale instellinging
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //kijken of het programma voor een student is
            if (StudentView.studentKijkt)
            {

                //proberen de studentenversie te openenen
                try
                {
                    //Draai de versie voor studenten
                    Application.Run(new InlogSchermStudent());                    
                }
                catch (ObjectDisposedException)
                {
                    //Bericht dat je krijgt als exception optreed
                    MessageBox.Show("Student niet gevonden",
                        "Error",
                        MessageBoxButtons.OK);
                    //Zorgt dat de applicatie afsluit als er geen student wordt gevonden
                    Environment.Exit(0);
                }
            }
            //anders open de docenten versie
            else
            {
                    Application.Run(new Window());
            }
        }
    }
}

