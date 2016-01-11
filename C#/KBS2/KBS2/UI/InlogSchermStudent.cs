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
        public static string wwInput;

        public InlogSchermStudent()
        {
            InitializeComponent();
            StudentSql.connect();
        }

        // Op enter drukken heeft hetzelfde effect als op de knop "Inloggen" klikken.
        private void txtbx_wachtwoord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btn_inloggen.PerformClick();
            }
        }
        // Op enter drukken heeft hetzelfde effect als op de knop "Inloggen" klikken.
        private void txtbx_studentnr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btn_inloggen.PerformClick();
            }
        }

        private void btn_inloggen_Click(object sender, EventArgs e)
        {
            wwInput = this.txtbx_wachtwoord.Text;
            if (string.IsNullOrWhiteSpace(txtbx_studentnr.Text))
            {
                MessageBox.Show("U moet nog een studentnummer invoeren!", "Error", MessageBoxButtons.OK);
            }
            else
            {
                //Bool b, controle bool zodat de code op de correcte volgorde uitvoert
                bool b = true;
                try
                {
                    //Convert string studentnummer naar int
                    ingelogdID = Convert.ToInt32(txtbx_studentnr.Text);
                }
                catch(Exception)
                {
                    MessageBox.Show(
                        "Het gegeven studentnummer is te lang! Controleer of u het correct heeft ingevoerd.",
                        "Error",
                        MessageBoxButtons.OK);
                    b = false;
                }
                if (b)
                {
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
                            //Als wachtwoord fout is krijg je deze melding
                            MessageBox.Show(
                                "Het gegeven wachtwoord is incorrect. Probeer het opnieuw.",
                                "Incorrect wachtwoord",
                                MessageBoxButtons.OK);
                        }

                    }
                    else
                    {
                        // Als studentnummer niet bestaat krijg je deze melding
                        MessageBox.Show(
                            "Het gegeven studentnummer bestaat niet. Controleer of u het correct heeft ingevoerd." +
                            Environment.NewLine + " Inloggen zónder S voor uw studentnummer.",
                            "Studentnummer incorrect",
                            MessageBoxButtons.OK);
                    }
                }
            }
        }

        //Functie om hash te krijgen van ingevoerde wachtwoord
        public string getHash(string text)
        {
            // Maken gebruik van SHA512 algoritme
            SHA512 alg = SHA512.Create();
            // Voeg salt toe aan wachtwoord voordat het gehash word
            string salted = text + StudentSql.getSalt(ingelogdID);
            // byte result is de hash
            result = alg.ComputeHash(Encoding.UTF8.GetBytes(salted));
            // Convert byte naar HEX string
            StringBuilder hex = new StringBuilder(result.Length * 2);
            foreach (byte b in result)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            // HEX string hash
            return hex.ToString().ToUpper();
        }
        
    }
}
