using KBS2.data;
using KBS2.model;
using KBS2.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS2.UI
{
    public partial class StudentKijkt : Form
    {
        public StudentKijkt()
        {
            //InitializeComponent();

            int id = 1234551;
            //Kiest welke student wordt opgehaald aan de hand van de id
            //Verander om een andere student te zien

            ToetsSql.connect();
            StudentSql.connect();
            //Maakt een connectie met de database

            Student student = StudentSql.getStudent(id);
            //Haalt de data van de student op

            StudentView view = new StudentView(student, this);
            //Maakt de studentview aan

            this.SetBounds(100, 100, 1280, 800);
            //Bepaald het formaat en de positie van het scherm
        }
    }
}
