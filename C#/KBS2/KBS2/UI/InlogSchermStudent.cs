using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace KBS2.UI
{
    public partial class InlogSchermStudent : Form
    {
        private string wwInput;
        private byte[] result;

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
            string wwhash = getCrypt(txtbx_wachtwoord.Text);
            Console.WriteLine(wwhash);
            MessageBox.Show(wwhash);

            //wwInput = "";
            //SHA512 alg = SHA512.Create();
            //result = alg.ComputeHash(Encoding.UTF8.GetBytes(this.txtbx_wachtwoord.Text));
            //wwInput = Encoding.UTF8.GetString(result);
            //Console.WriteLine(wwInput);

            //Verberg de huidige form
            this.Hide();

            //Opent StudentKijkt als dialoog
            Form form = new StudentKijkt();
            form.ShowDialog();

            //Sluit de applicatie als StudentKijkt wordt afgesloten
            this.Close();
        }

        public string getCrypt(string text)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] message = UE.GetBytes(text);
            SHA512Managed hashString = new SHA512Managed();
            string hexNumber = "";
            byte[] hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hexNumber += String.Format("{0:x2}", x);
            }
            string hash = hexNumber;
            return hash;
        }
    }
}
