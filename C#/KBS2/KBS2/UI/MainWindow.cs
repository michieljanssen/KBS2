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
using KBS2.data;

namespace KBS2.UI
{
    public partial class lbl_avg : UserControl
    {
        Toets toets;
        public lbl_avg(Toets toets, List<string> data)
        {

            InitializeComponent();
            LoadData(toets, data);
            cb_jaar.DataSource = ToetsSql.getToetsJaren(toets.Naam);
            cb_datum.DataSource = ToetsSql.toetsData(toets.Naam, (string)cb_jaar.SelectedValue);

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
            this.progressBar1.Value = toets.percentageVold();
            this.dgv_toets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_toets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //Fill gridview
            DataGridViewCellStyle dgvcs = new DataGridViewCellStyle();
            dgvcs.NullValue = null;
            this.dgv_toets.AlternatingRowsDefaultCellStyle = dgvcs;
            DataGridViewTextBoxColumn Studentnr = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn naam = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Cijfer = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn datum = new DataGridViewTextBoxColumn();
            dgv_toets.Columns.AddRange(new DataGridViewColumn[] {
            Studentnr,
            naam,
            Cijfer,
            datum});
            //Cijfer
            Cijfer.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 16F);
            Cijfer.DefaultCellStyle = dgvcs;
            Cijfer.HeaderText = "Cijfer";
            Cijfer.Name = "Cijfer";
            Cijfer.ReadOnly = true;
            Cijfer.Width = (int)(0.1 * dgv_toets.Width);

            //Leerlingnr
            Studentnr.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 16F);
            Studentnr.DefaultCellStyle = dgvcs;
            Studentnr.HeaderText = "Studentnr";
            Studentnr.Name = "Studentnr";
            Studentnr.ReadOnly = true;
            Studentnr.Width = (int)(0.2 * dgv_toets.Width);

            //naam
            naam.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 16F);
            naam.DefaultCellStyle = dgvcs;
            naam.HeaderText = "Naam";
            naam.Name = "naam";
            naam.ReadOnly = true;
            naam.Width = (int)(0.2 * dgv_toets.Width);



            //datum
            datum.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 16F);
            datum.DefaultCellStyle = dgvcs;
            datum.HeaderText = "Datum van Afname";
            datum.Name = "datum";
            datum.ReadOnly = true;
            datum.Width = (int)(dgv_toets.Width-naam.Width-Studentnr.Width-Cijfer.Width);

            if (toets.Cijfers.Count > 0)
            {
                //gaat door alle cijfers heen
                for (int i = 0; i < toets.Cijfers.Count; i++)
                {
                    //zet de cijfers in de tabel
                    object[] row = { toets.Cijfers[i].ID, toets.Cijfers[i].Naam, toets.Cijfers[i].Cijfer, toets.Cijfers[i].Datum };
                    this.dgv_toets.Rows.Add(row);

                    //verandert de kleur van de text als voldoende is of niet
                    if (toets.Cijfers[i].isVoldoende())
                    {
                        //groen voor voldoende
                        this.dgv_toets.Rows[i].Cells[2].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        //rood voor onvoldoende
                        this.dgv_toets.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                //anders laat een melding zien
                var result = MessageBox.Show("Deze toets heeft geen cijfers.", "Geen cijfers", MessageBoxButtons.OK);
            }
        }


    }

}


