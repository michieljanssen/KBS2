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
    public partial class InlogSchermStudent : Form
    {
        public InlogSchermStudent()
        {
            InitializeComponent();
        }

        private void lbl_email_Click(object sender, EventArgs e)
        {

        }

        private void txtbx_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbx_wachtwoord_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_wachtwoord_Click(object sender, EventArgs e)
        {

        }

        private void btn_inloggen_Click(object sender, EventArgs e)
        {
            //Verberg de huidige form
            this.Hide();

            //Opent StudentKijkt als dialoog
            Form form = new StudentKijkt();
            form.ShowDialog();

            //Sluit de applicatie als StudentKijkt wordt afgesloten
            this.Close();
        }
    }
}
