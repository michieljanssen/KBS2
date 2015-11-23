using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KBS2.views;
using KBS2.cijfer;
using KBS2.data;
namespace KBS2
{
    public partial class Form1 : Form
    {
        Panel p;
        Sql sql;

        public Form1()
        {
            InitializeComponent();
            sql = new Sql();
            

        }

        private void btn_zoek_Click(object sender, EventArgs e)
        {
            txb_zoek.Location = new Point(txb_zoek.Location.X, 20);
            btn_zoek.Location = new Point(btn_zoek.Location.X, 20);
            
            
            List<ToetsCijfer> cijfers = new List<ToetsCijfer>();
            cijfers.Add(new ToetsCijfer("1234567890", "Jan Jansen", 5.0, "11/11/2015"));
            cijfers.Add(new ToetsCijfer("0987654321", "Piet Peters", 4.0, "11/11/2015"));
            cijfers.Add(new ToetsCijfer("1235789075", "Paul Bakker", 6.0, "11/11/2015"));
            cijfers.Add(new ToetsCijfer("0998763456", "Thijme de Boer", 7.0, "20/11/2015"));


            Toets toets = new Toets("Scrum", "Multiplechoice", "11/11/2015",  cijfers);

            List<VakCijfer> c = new List<VakCijfer>();
            c.Add(new VakCijfer("Scrum", 5, 5.5));
            c.Add(new VakCijfer("UML", 5, 9.0));
            c.Add(new VakCijfer("c#", 5, 4.0));

            Student student = new Student("Jan Jansen", "123456789",c);

           // p = new ToetsView(toets);



             p = new StudentView(student);
            p.Parent = this;
        }
    }
}
