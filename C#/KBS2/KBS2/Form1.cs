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

namespace KBS2
{
    public partial class Form1 : Form
    {
        Panel p;

        public Form1()
        {
            InitializeComponent();
           
            

        }

        private void btn_zoek_Click(object sender, EventArgs e)
        {
            txb_zoek.Location = new Point(txb_zoek.Location.X, 20);
            btn_zoek.Location = new Point(btn_zoek.Location.X, 20);
            
            
            List<ToetsCijfer> cijfers = new List<ToetsCijfer>();
            cijfers.Add(new ToetsCijfer("1234567890", "Jan Jansen", 5.0));
            cijfers.Add(new ToetsCijfer("0987654321", "Piet Peters", 4.0));
            cijfers.Add(new ToetsCijfer("1235789075", "Paul Bakker", 6.0));
            cijfers.Add(new ToetsCijfer("0998763456", "Thijme de Boer", 7.0));


            Toets toets = new Toets("Scrum", "Multiplechoice", "11/11/2015", 5, cijfers);

            p = new ToetsView(toets);
            p.Parent = this;
        }
    }
}
