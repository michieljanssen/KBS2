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
            
            //Haalt de data van de student op
            Student student = StudentSql.getStudent(InlogSchermStudent.ingelogdID);
            //Maakt de studentview aan
            StudentView view = new StudentView(student, this);
            //Bepaald het formaat en de positie van het scherm    
            this.SetBounds(100, 100, 1280, 960);
            
        }
    }
}
