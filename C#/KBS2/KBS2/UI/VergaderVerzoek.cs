using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

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
            int ingelogdId = 1;
            model.Student student = data.StudentSql.getStudent(ingelogdId);

            //Juiste student weten
            //student.Cijfers
            
            List<model.cijfer.VakCijfer> cijferLijst = student.Cijfers;

            String cijferTekst = "";

            for (int i = cijferLijst.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(cijferLijst[i].VakNaam + " " + cijferLijst[i].Cijfers[0].Cijfer);

                cijferTekst = cijferTekst + cijferLijst[i].VakNaam + " " + cijferLijst[i].Cijfers[0].Cijfer + Environment.NewLine;
                //cijferTekst = cijferTekst + cijfer.VakNaam + " " + cijfer.Cijfers + Environment.NewLine;
            }


            //cijferTekst.Replace("@", "@" + Environment.NewLine);

            //student.Cijfers.ToString();

            //cijferLijst

            //model.cijfer.VakCijfer Vak = 

            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(
                  "windesheimstudentvolg@gmail.com", "/,:vF4!NW&");
                MailMessage msg = new MailMessage();
                msg.To.Add(this.txtbx_emailOntvanger.Text);
                //msg.From = new MailAddress("s1082925@student.windesheim.nl", "Student naam hier");
                msg.From = new MailAddress("windesheimstudentvolg@gmail.com");
                msg.Subject = this.txtbx_onderwerp.Text;
                msg.Body = this.txtbx_bericht.Text + Environment.NewLine + cijferTekst;
                //+
                    
                    
                    
                    ;
                client.Send(msg);
                MessageBox.Show("Successfully Sent Message.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VergaderVerzoek_FormClosed(object sender, FormClosedEventArgs e)
        {
            views.StudentView.has_been_shown = false;
        }
    }
}
