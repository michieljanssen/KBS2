using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS2.UI
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
            Searchwindow zk_win = new Searchwindow();
            zk_win.ClientSize = this.ClientSize;
            zk_win.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            zk_win.Visible = true;
            this.Controls.Add(zk_win);
            
        }
    }
}
