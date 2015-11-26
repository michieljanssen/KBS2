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
            if (ToetsSql.ToetExists(txb_zoek.Text))
            {
                //beweegt de zoekbalk +knop omhoog
                txb_zoek.Location = new Point(txb_zoek.Location.X, 20);
                btn_zoek.Location = new Point(btn_zoek.Location.X, 20);
                
                //krijgt de toets uit de database
                Toets toets = ToetsSql.getToets(txb_zoek.Text);
                //maakt het paneel aan met de toets en voegt deze toe aan het scherm
                ToetsView panel = new ToetsView(toets);
                setPanel(panel);
            }
            else
            {
                //anders als de toets neit bestaat laat een popup komen
                var result = MessageBox.Show("Deze toets bestaat niet: \"" + txb_zoek.Text+"\"","Niet bestaande toets", MessageBoxButtons.OK);
            }


        }
        //vervangt het paneel op het scherm
        public void setPanel(Panel panel) {
                //checkt of het paneel bestaat
            if (p != null)
            {
                //verwijdert het paneel
                p.Parent = null;
                p = null;
            }
            //voegt het paneel toe
            p = panel;
            p.Parent = this;
        }
    }
}
