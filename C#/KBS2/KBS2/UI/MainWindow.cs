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
using KBS2.model.cijfer;

namespace KBS2.UI
{
    public partial class MainWindow : UserControl
    {
        Toets toets;
        public MainWindow(Toets toets, List<string> data)
        {

            InitializeComponent();
            txbx_zoek_refresh(data);
            init();
            cb_jaar.DataSource = ToetsSql.getToetsJaren(toets.Naam);
            cb_datum.DataSource = ToetsSql.toetsData(toets.Naam, (string)cb_jaar.SelectedValue);
            LoadData(toets);
            

        }

        private void Zk_Btn_Click(object sender, EventArgs e)
        {
            this.lbl_err.Text = "NOT FUNCTIONAL";
        }
        internal void txbx_zoek_refresh(List<String> data)
        {
            this.txbx_zoek.Text = data[1];          // fils in the textbox
            this.comboBox1.SelectedItem = data[0];  // get's the selected item
        }
        internal void init()
        {
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
            datum.Width = (int)(dgv_toets.Width - naam.Width - Studentnr.Width - Cijfer.Width);
        }

        internal void LoadData(Toets toets)
        {
            this.toets = toets;
            dgv_toets.Rows.Clear();
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
            if (toets.Cijfers.Count > 0)
            {
                //gaat door alle cijfers heen
                chrtreset(toets.Cijfers);
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
                //
            }
            else
            {
                //anders laat een melding zien
                this.lbl_err.Text = "Deze toets heeft geen cijfers";
            }
        }
        internal void chrtreset(List<model.cijfer.ToetsCijfer> Cijferlijst)
        {
            chrt_.Series[0].Points.Clear();                 // clear old data
            List<double> ccijfers = new List<Double>();
            foreach (ToetsCijfer tc in Cijferlijst)         //round grades down to .5 increments
            {
                double a = tc.Cijfer;
                double b = topoint5(a);
                ccijfers.Add(b);
            }
            ccijfers.Sort();
            int yval = 0;
            for(double xval = 2; xval < 21; xval++)
            {
                yval = 0;
                foreach(double cijfer in ccijfers)
                {
                    if(xval/2 == cijfer)
                    {
                        yval++;
                    }
                }
                chrt_.Series[0].Points.AddXY(xval / 2, yval);
            }
        }

        internal double topoint5(double a)
        {
            double b = a * 2;
            double c = Math.Floor(b);
            double d = c / 2;
            return d;
        }

        private void cb_datum_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cb_datum.DataSource = ToetsSql.toetsData(toets.Naam, (String)cb_jaar.SelectedValue);
            if (!cb_datum.SelectedValue.Equals("beste resultaten"))
            {
                Toets t = ToetsSql.getToets(this.toets.Naam, (String)cb_datum.SelectedValue, (String)cb_jaar.SelectedValue);
                LoadData(t);
            }
            else
            {
                Toets t = ToetsSql.getToets(this.toets.Naam, (String)cb_jaar.SelectedValue);
                LoadData(t);
            }
        }

        private void cb_jaar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cb_datum.DataSource = ToetsSql.toetsData(toets.Naam, (String)cb_jaar.SelectedValue);
            if (!cb_datum.SelectedValue.Equals("beste resultaten"))
            {
                Toets t = ToetsSql.getToets(this.toets.Naam, (String)cb_datum.SelectedValue, (String)cb_jaar.SelectedValue);
                LoadData(t);
            }
            else
            {
                Toets t = ToetsSql.getToets(this.toets.Naam, (String)cb_jaar.SelectedValue);
                LoadData(t);
            }
        }
    }

}


