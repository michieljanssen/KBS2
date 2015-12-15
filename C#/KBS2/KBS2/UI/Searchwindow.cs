using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS2.UI
{
    public partial class Searchwindow : UserControl
    {
        public Searchwindow()
        {
            InitializeComponent();
        }

        private void Zk_btn_Click(object sender, EventArgs e)
        {
            String inputstring = this.Zk_Bx.Text;
            //TODO Perform Query;

            
            this.Enabled = false;
            this.Visible = false;
            MainWindow a = new MainWindow();
            a.LoadData("QueryData");
            a.ClientSize = Parent.ClientSize;
            a.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            a.Visible = true;
            Parent.Controls.Add(a);
            this.Dispose();
        }
    }
}
