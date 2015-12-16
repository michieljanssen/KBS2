using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KBS2.model;
using KBS2.views;

namespace KBS2.UI
{
    public partial class lbl_avg : UserControl
    {
        Toets toets;
        public lbl_avg(Toets toets,List<string> data)
        {
            
            InitializeComponent();
            LoadData(toets,data);
            
        }

        private void Zk_Btn_Click(object sender, EventArgs e)
        {
            this.lbl_err.Text = "NOT FUNCTIONAL";
        }

        internal void LoadData(Toets toets, List<string> data)
        {
            this.toets = toets;
            this.txbx_zoek.Text = data[1];          // fils in the textbox
            this.comboBox1.SelectedItem = data[0];  // get's the selected item
            this.lbl_name.Text = toets.Naam;        // changes the name label
            this.lbl_behaald.Text = "Behaald: " + toets.voldoendes();   //change the voldoende label
            this.lbl_nietbehaald.Text = "Niet behaald: " + toets.onvoldoendes(); // change the onvoldoende label
            this.lbl_perc.Text = "Percentage: " + toets.percentageVold(); //change the percentage label
            this.lbl_err.Text = ""; 
            this.lbl_gem.Text = "Gemiddelde: " + toets.gemiddelde(); // change the gemiddlede label
            this.lbl_type.Text = "type: " + toets.Type;
        }
    }
}
