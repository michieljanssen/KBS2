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
using KBS2.model.cijfer;
using KBS2.model;
using KBS2.data;

namespace KBS2
{
    public partial class Form1 : Form
    {
        //het paneel voor alle opgehaalde gegevens
        Panel p;

        //initalizatie
        public Form1()
        {
            InitializeComponent();
            //database connecties worden opgezet
            ToetsSql.connect();
            StudentSql.connect();
        }

        //zoek knop ingedrukt event
        private void btn_zoek_Click(object sender, EventArgs e)
        {
            //checkt of de toets bestaat

            if (txb_zoek.Text != "")
            {
                if (ToetsSql.ToetsExists(txb_zoek.Text))
                {
                    //beweegt de zoekbalk +knop omhoog
                    txb_zoek.Location = new Point(txb_zoek.Location.X, 20);
                    btn_zoek.Location = new Point(btn_zoek.Location.X, 20);
                    this.txb_zoek.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
                    this.btn_zoek.Anchor = (AnchorStyles.Top | AnchorStyles.Right);

                    //krijgt de toets uit de database
                    Toets toets = ToetsSql.getToets(txb_zoek.Text);
                    //maakt het paneel aan met de toets en voegt deze toe aan het scherm
                    ToetsView panel = new ToetsView(toets, this);
                    setPanel(panel);
                }
                else
                {
                    //anders als de toets neit bestaat laat een popup komen
                    var result = MessageBox.Show("Deze toets bestaat niet: \"" + txb_zoek.Text + "\"", "Niet bestaande toets", MessageBoxButtons.OK);
                }
            }
            else
            {
                //Geen een popup weer die zegt dat er wat moet worden ingevuld
                var result = MessageBox.Show("Voer a.u.b. een toets in.", "Voer aub een toets in", MessageBoxButtons.OK);
            }
        }
        //keypress event voor de zoekbalk
        private void txb_zoek_KeyPress(object sender, KeyPressEventArgs e)
        {
            //checked of enter is ingedrukt
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //voert de knop uit om te zoeken
                btn_zoek.PerformClick();
            }
        }
        //vervangt het paneel op het scherm
        public void setPanel(Panel panel)
        {
            //checkt of het paneel bestaat
            if (p != null)
            {
                //verwijdert het paneel
                p.Parent = null;
                p = null;
            }

            //voegt het paneel toe
            p = panel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void GraphPanel_Paint(object sender, PaintEventArgs e)
        {
            //int frequency = graphpanel1.graphfrequency;
            int frequency = 5;
            int height = graphpanel1.graphheight;
            int freqheight = frequency / height;

            int width = GraphPanel.Width;
            int cijferswidth = width / 12;

            List<Label> freqlabels = new List<Label>();
            List<Label> cijferlabels = new List<Label>();

            Console.WriteLine(cijferswidth.ToString());

            for (int a = 1; a < 11; a++)
            {
                Label cijfer = new Label();

                cijfer.Location = new Point(418, 300 + 10 * a);
                cijfer.Text = a.ToString();
                cijfer.Show();
                cijferlabels.Add(cijfer);

                //cijfer.Parent = GraphPanel;
                //GraphPanel.Container.Add(cijfer);
                Controls.Add(cijfer);
            }

            Label test = new Label();

            test.Location = new Point(10, 10);
            test.Text = "Test";
            test.Show();
            this.Controls.Add(test);

            for (int i = 0; i < frequency; i++)
            {
                Label nr = new Label();

                nr.Location = new Point(10, 10 + 10 * i);
                nr.Text = i.ToString();
                nr.Show();
                freqlabels.Add(nr);
                this.Controls.Add(nr);
            }
        }
    }
}
