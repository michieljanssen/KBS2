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
            p = new ToetsView(null);
            p.Parent = this;
        }
    }
}
