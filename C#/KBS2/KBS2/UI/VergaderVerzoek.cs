using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using KBS2.data;
using KBS2.model;
using KBS2.model.cijfer;
using KBS2.views;

namespace KBS2.UI
{
    public partial class VergaderVerzoek : Form
    {

        private String cijferTekst;

        public VergaderVerzoek()
        {
            InitializeComponent();
            //Zet focus op textbox email ontvanger zodat de gebruiker meteen kan typen
            this.ActiveControl = txtbx_emailOntvanger;
        }

        private void btn_verstuurBericht_Click(object sender, EventArgs e)
        {
            // Achterhalen welke student is ingelogd
            Student student = StudentSql.getStudent(InlogSchermStudent.ingelogdID);
            
            // Verduidelijking van wie de cijferlijst is indien student mail niet afsluit met zijn/haar naam
            cijferTekst = "Cijferlijst van " + StudentSql.getStudentNaam(InlogSchermStudent.ingelogdID) + ":" + Environment.NewLine;

            List<VakCijfer> cijferLijst = student.Cijfers;
            for (int i = 0; i < cijferLijst.Count; i++)
            {
                // Voor elk vak waarvan de student een cijfer heeft het gemiddelde geven
                cijferTekst += cijferLijst[i].VakNaam + '\t' + '\t' + '\t' + cijferLijst[i].gemiddelde() + Environment.NewLine;
                List<ToetsCijfer> toetsen = cijferLijst[i].besteToetsen();
                for (int b = 0; b < toetsen.Count; b++)
                {
                    // Als de lengte van de toetsnaam langer is dan 8 output veranderd
                    if (toetsen[b].toetsName.Length >= 8)
                    {
                        // Individuele toetsen toevoegen aan de output per vak
                        cijferTekst += '\t' + toetsen[b].toetsName + '\t' + toetsen[b].Cijfer + Environment.NewLine;
                    }
                    else
                    {
                        // Individuele toetsen toevoegen aan de output per vak
                        cijferTekst += '\t' + toetsen[b].toetsName + '\t' + '\t' + toetsen[b].Cijfer + Environment.NewLine;
                    }
                }
            }

            //Probeer mail te versturen
            try
            {
                //SmtpClient client = new SmtpClient("smtp.gmail.com");
                SmtpClient client = new SmtpClient("smtp.office365.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //client.Credentials = new NetworkCredential(
                //  "windesheimstudentvolg@gmail.com", "/,:vF4!NW&");
                // Student inloggen om mail te versturen, ingelogd student wordt hiervoor gebruikt
                client.Credentials = new NetworkCredential(
                    StudentSql.getEmail(InlogSchermStudent.ingelogdID), InlogSchermStudent.wwInput);

                //Achterhalen aan wie bericht verzonden wordt en bericht samenstellen met cijferlijst
                MailMessage msg = new MailMessage();
                msg.To.Add(this.txtbx_emailOntvanger.Text);
                msg.From = new MailAddress(StudentSql.getEmail(InlogSchermStudent.ingelogdID), StudentSql.getStudentNaam(InlogSchermStudent.ingelogdID));
                //msg.From = new MailAddress("windesheimstudentvolg@gmail.com");
                msg.Subject = this.txtbx_onderwerp.Text;
                msg.Body = this.txtbx_bericht.Text + Environment.NewLine + Environment.NewLine + cijferTekst;

                //Verzend mail
                client.Send(msg);
                //Als er geen fouten optreden krijg je deze melding en is de mail verzonden
                MessageBox.Show(
                    "Bericht succesvol verzonden.",
                    "Verzonden", 
                    MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                //Als er een fout optreed krijg je deze melding
                MessageBox.Show(
                    "Er is iets fout gegaan. Probeer het opnieuw.", 
                    "Error", 
                    MessageBoxButtons.OK);
            }
        }
            

            
        private void VergaderVerzoek_FormClosed(object sender, FormClosedEventArgs e)
        {
            StudentView.has_been_shown = false;
        }
    }
}
