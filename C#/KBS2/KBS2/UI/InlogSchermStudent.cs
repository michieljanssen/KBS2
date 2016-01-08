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
using KBS2.data;

namespace KBS2.UI
{
    public partial class InlogSchermStudent : Form
    {
        private string wwHash;
        private byte[] result;
        public static int ingelogdID;

        public InlogSchermStudent()
        {
            InitializeComponent();
            StudentSql.connect();
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
            ingelogdID = Convert.ToInt32(txtbx_email.Text);
            bool studentExists = StudentSql.studentExists(ingelogdID);
            if (studentExists)
            {
                // Genereer hash van ingevoerde wachtwoord
                wwHash = getHash(txtbx_wachtwoord.Text);
                if (StudentSql.passwordCompare(ingelogdID, wwHash))
                {
                    //Verberg de huidige form
                    this.Hide();

                    //Opent StudentKijkt als dialoog
                    Form form = new StudentKijkt();
                    form.ShowDialog();

                    //Sluit de applicatie als StudentKijkt wordt afgesloten
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Het gegeven wachtwoord is incorrect. Probeer het opnieuw.");
                }
                
            }
            else
            {
                // Als studentnummer niet bestaat krijg je deze melding
                MessageBox.Show("Het gegeven studentnummer bestaat niet. Controleer of u het correct heeft ingevoerd.");
            }

            
            
        }

        //Functie om hash te krijgen van ingevoerde wachtwoord
        public string getHash(string text)
        {
            // Maken gebruik van SHA512 algoritme
            SHA512 alg = SHA512.Create();
            // byte result is de hash
            result = alg.ComputeHash(Encoding.UTF8.GetBytes(this.txtbx_wachtwoord.Text));
            // Convert byte naar HEX string
            StringBuilder hex = new StringBuilder(result.Length * 2);
            foreach (byte b in result)
                hex.AppendFormat("{0:x2}", b);
            // HEX string hash
            return hex.ToString().ToUpper();
        }

    }
}
