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
            //TODO Perform Query;
            if (inputstring != "" && ToetsSql.ToetsExists(inputstring)){

            }
            else
            {
                Zk_Error.Text = "Test";
            }

            //this.Enabled = false;
            //this.Visible = false;
            //MainWindow a = new MainWindow();
            //a.LoadData();
            //a.ClientSize = Parent.ClientSize;
            //a.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            //a.Visible = true;
            //Parent.Controls.Add(a);
            //this.Dispose();
        }

        private void Zk_Bx_KeyPress(object sender, KeyPressEventArgs e)
        {
            //perform search
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Zk_btn.PerformClick();
            }
        }
    }
}
