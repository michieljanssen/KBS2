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
            InitializeComponent();
            this.Zk_Error.Text = "";
        }

        private void Zk_btn_Click(object sender, EventArgs e)
        {
            String inputstring = this.Zk_Bx.Text;
            //TODO Refine search 
            if (inputstring != "")
            {
                ToetsSql.connect();
                if (ToetsSql.ToetsExists(inputstring))
                {
                    Zk_Error.Text = "";
                    Toets toets = null;
                    if(ToetsSql.getToetsJaren(inputstring).Count != 0)
                    {
                        toets = ToetsSql.getToets(inputstring, ToetsSql.getToetsJaren(inputstring)[0]);
                    }
                    else
                    {
                        toets = ToetsSql.getToets(inputstring, "");
                    }
                    List<string> dat = new List<string>();
                    dat.Add(zk_combo.SelectedItem.ToString());
                    dat.Add(inputstring);
                    this.changeWindow(toets,dat);
                }
                else
                {
                    Zk_Error.Text = "Deze Toets bestaat niet";
                }
            }
            else
            {
                Zk_Error.Text = "";
            }

            
        }

        private void Zk_Bx_KeyPress(object sender, KeyPressEventArgs e)
        {
            //perform search
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Zk_btn.PerformClick();
            }
        }
        
        private void changeWindow(Toets q,List<string> b)
        {
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
