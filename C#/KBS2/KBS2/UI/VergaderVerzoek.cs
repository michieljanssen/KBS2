using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using KBS2.data;

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

            String cijferTekst = "<table style=\"width:150px\">";

            for (int i = 0; i < cijferLijst.Count; i++)
            {
                Console.WriteLine(cijferLijst[i].VakNaam + "     " + cijferLijst[i].Cijfers[0].Cijfer);


                cijferTekst += "<tr> <td>" + cijferLijst[i].VakNaam + "</td><td></td><td> " + cijferLijst[i].gemiddelde() + "</td></tr> ";


                List<model.cijfer.ToetsCijfer> toetsen = cijferLijst[i].besteToetsen();
                for (int b = 0; b < toetsen.Count; b++)
                {
                    cijferTekst += "<tr><td></td> <td>" + toetsen[b].toetsName + "</td><td>" + toetsen[b].Cijfer + "</td></tr>";
                }


                cijferTekst += "</table>";
                //cijferTekst = cijferTekst + cijfer.VakNaam + " " + cijfer.Cijfers + Environment.NewLine;
            }

            //cijferTekst.Replace("@", "@" + Environment.NewLine);

            //student.Cijfers.ToString();

            //cijferLijst

            //model.cijfer.VakCijfer Vak = 

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
                msg.From = new MailAddress(StudentSql.getEmail(InlogSchermStudent.ingelogdID), StudentSql.getEmail(InlogSchermStudent.ingelogdID));
                //msg.From = new MailAddress("windesheimstudentvolg@gmail.com");
                msg.Subject = this.txtbx_onderwerp.Text;
                msg.IsBodyHtml = true;
                msg.Body = this.txtbx_bericht.Text + Environment.NewLine + cijferTekst;
                client.Send(msg);
                MessageBox.Show("Bericht succesvol verzonden.");
            }
            //catch (Exception ex)
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Er is iets fout gegaan, probeer het opnieuw.", "Error", MessageBoxButtons.OK);
            }
        }
            

            
        private void VergaderVerzoek_FormClosed(object sender, FormClosedEventArgs e)
        {
            views.StudentView.has_been_shown = false;
        }
    }
}
