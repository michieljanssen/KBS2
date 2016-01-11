using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using KBS2.data;
using KBS2.model;

namespace KBS2.UI
{
    public partial class VergaderVerzoek : Form
    {
        public VergaderVerzoek()
        {
            InitializeComponent();
        }

        private void btn_verstuurBericht_Click(object sender, EventArgs e)
        {
            model.Student student = data.StudentSql.getStudent(InlogSchermStudent.ingelogdID);

            //Juiste student weten
            //student.Cijfers

            List<model.cijfer.VakCijfer> cijferLijst = student.Cijfers;

            String cijferTekst = "";

            for (int i = 0; i < cijferLijst.Count; i++)
            {
                Console.WriteLine(cijferLijst[i].VakNaam + "     " + cijferLijst[i].Cijfers[0].Cijfer);

                cijferTekst += cijferTekst + cijferLijst[i].VakNaam + '\t' + cijferLijst[i].gemiddelde() + Environment.NewLine;

                List<model.cijfer.ToetsCijfer> toetsen = cijferLijst[i].besteToetsen();
                for (int b = 0; b < toetsen.Count; b++)
                {
                    cijferTekst += '\t' + toetsen[b].toetsName + '\t' + toetsen[b].Cijfer + Environment.NewLine;
                }
            }

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
                client.Credentials = new NetworkCredential(
                    StudentSql.getEmail(InlogSchermStudent.ingelogdID), InlogSchermStudent.wwInput);
                MailMessage msg = new MailMessage();
                msg.To.Add(this.txtbx_emailOntvanger.Text);
                msg.From = new MailAddress(StudentSql.getEmail(InlogSchermStudent.ingelogdID), StudentSql.getStudentNaam(InlogSchermStudent.ingelogdID));
                //msg.From = new MailAddress("windesheimstudentvolg@gmail.com");
                msg.Subject = this.txtbx_onderwerp.Text;
                msg.Body = this.txtbx_bericht.Text + Environment.NewLine + Environment.NewLine + cijferTekst
                    + Environment.NewLine + student.ID + Environment.NewLine + student.Naam;
                client.Send(msg);
                MessageBox.Show(
                    "Bericht succesvol verzonden.",
                    "Verzonden", 
                    MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Er is iets fout gegaan. Probeer het opnieuw.", 
                    "Error", 
                    MessageBoxButtons.OK);
            }
        }
            

            
        private void VergaderVerzoek_FormClosed(object sender, FormClosedEventArgs e)
        {
            views.StudentView.has_been_shown = false;
        }
    }
}
