using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS2.data;
using KBS2.views;
using KBS2.model;

namespace KBS2.UI
{
    public partial class Searchwindow : UserControl
    {
        
        public Searchwindow()
        {
            //init
            InitializeComponent();
            this.Zk_Error.Text = "";
        }

        //zoekbutton wordt ingedrukt(event)
        private void Zk_btn_Click(object sender, EventArgs e)
        {
            String inputstring = this.Zk_Bx.Text;
            //check of er iets is ingevult
            if (inputstring != "")
            {
                //connectie naar Toets database
                ToetsSql.connect();
                //check of de toets bestaat
                if (ToetsSql.ToetsExists(inputstring))
                {
                    Zk_Error.Text = "";
                    Toets toets = null;
                    //checked of de aantal toets jaren niet 0 zijn
                    if(ToetsSql.getToetsJaren(inputstring).Count != 0)
                    {
                        //verkrijgt de toets met het recentse jaar
                        toets = ToetsSql.getToets(inputstring, ToetsSql.getToetsJaren(inputstring)[0]);
                    }
                    else
                    {
                        //verkrijgt de toets zonder ingevuld jaar
                        toets = ToetsSql.getToets(inputstring, "");
                    }

                    List<string> dat = new List<string>();
                    dat.Add(zk_combo.SelectedItem.ToString());
                    dat.Add(inputstring);
                    //opent de toetsview voor de net geladen toets
                    this.changeWindow(toets,dat);
                }
                else
                {
                    //geeft error message
                    Zk_Error.Text = "Deze Toets bestaat niet";
                }
            }
            //error message wordt op niks gezet
            else
            {
                Zk_Error.Text = "";
            }

            
        }
        //indruk event voor de zoekknop
        private void Zk_Bx_KeyPress(object sender, KeyPressEventArgs e)
        {
            //checkt of er op enter gedrukt wordt
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //voer de zoekknop uit
                Zk_btn.PerformClick();
            }
        }
        //visual verandering window
        private void changeWindow(Toets q,List<string> b)
        {
            //visuale aanpassingen aan het scherm
            this.Enabled = false;
            this.Visible = false;
            MainWindow a = new MainWindow(q,b);
            
            a.ClientSize = Parent.ClientSize;
            a.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            a.Visible = true;
            Parent.Controls.Add(a);
            this.Dispose();
        }
    }
}
