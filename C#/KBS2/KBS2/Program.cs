﻿using System;
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

            a = false;
            //uitleg pls

 
            //Als deze true is wordt de applicatie geopend als student.
            StudentView.studentKijkt = false;
            StudentView.studentKijkt = true;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (StudentView.studentKijkt)
            {
                try
                {
                    Application.Run(new StudentKijkt());
                    //Draai de versie voor studenten
                }
                catch (ObjectDisposedException)
                {
                    Environment.Exit(0);
                    //Zorgt dat de applicatie afsluit als er geen student wordt gevonden
                }
            }
            else
            {
                if (a)
                {
                    Application.Run(new Form1());
                    //Start de standaard applicatie
                }
                else
                {
                    Application.Run(new Window());
                    //Start de test met andere zoekmethodes
                }
            }
        }
    }
}

