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
        internal void init()    //additional GUI setup
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

        internal void LoadData(Toets toets) // load in toetsdata
        {
            this.toets = toets;
            dgv_toets.Rows.Clear();
            if (toets != null)
            {
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
                    chrtreset(toets.Cijfers);   //refresh the grades diagram
                    for (int i = 0; i < toets.Cijfers.Count; i++)
                    {
                        object[] row = { toets.Cijfers[i].ID, toets.Cijfers[i].Naam, toets.Cijfers[i].Cijfer, toets.Cijfers[i].Datum };
                        this.dgv_toets.Rows.Add(row);   //add new rows to the table
                        this.dgv_toets.Rows[i].Cells[2].Style.ForeColor = Color.Red; // default color is red
                                                                                     //verandert de kleur van de text als voldoende is of niet
                        if (toets.Cijfers[i].ECsBehaald())
                        {
                            this.dgv_toets.Rows[i].Cells[2].Style.ForeColor = Color.Green; // acceptable grades are green
                        }
                    }
                }
                else
                {
                    //anders laat een melding zien
                    this.lbl_err.Text = "Deze toets heeft geen cijfers";
                    chrtreset(null);
                }
            }
        }
        internal void txbx_zoek_refresh(List<String> data)
        {
            this.txbx_zoek.Text = data[1];          // fils in the textbox
            this.cb_Zoek.SelectedItem = data[0];  // get's the selected item
        }
        internal void chrtreset(List<model.cijfer.ToetsCijfer> Cijferlijst)
        {
            chrt_.Series[0].Points.Clear();                 // clear old data
            if (Cijferlijst != null)
            {
                List<double> ccijfers = new List<Double>();
                foreach (ToetsCijfer tc in Cijferlijst)         //round grades down to .5 increments
                {
                    double a = tc.Cijfer;
                    double b = topointfiveincrement(a);
                    ccijfers.Add(b);
                }
                ccijfers.Sort();
                int yval = 0;
                for (double xval = 2; xval < 21; xval++)
                {
                    yval = 0;
                    foreach (double cijfer in ccijfers)
                    {
                        if (xval / 2 == cijfer)
                        {
                            yval++;
                        }
                    }
                    chrt_.Series[0].Points.AddXY(xval / 2, yval);
                }
            }
        }
        internal double topointfiveincrement(double a) //rounds grades to .5 incements
        {
            double b = a * 2;           //for a = 2.7 b = 5.4
            double c = Math.Floor(b);   // c = 5.4 => 5.0
            double d = c / 2;           // d = 2.5
            return d;
        }

        private void cb_datum_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            Console.WriteLine("Clicked = " + c.SelectedValue);
            string datetime = c.GetItemText(c.SelectedItem);
            if (!c.SelectedValue.Equals("beste resultaten"))
            {
                Toets t = ToetsSql.getToets(this.toets.Naam, (String)c.SelectedValue, (String)cb_jaar.SelectedValue);
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
        private void txbx_zoek_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btn_zoek.PerformClick();
            }
        }
        private void Zk_Btn_Click(object sender, EventArgs e)
        {
            String inputstring = this.txbx_zoek.Text;
            //TODO Refine search 
            if (inputstring != "")
            {
                ToetsSql.connect();
                if (ToetsSql.ToetsExists(inputstring))
                {
                    lbl_err.Text = "";
                    Toets toets = null;
                    if (ToetsSql.getToetsJaren(inputstring).Count != 0)
                    {
                        toets = ToetsSql.getToets(inputstring, ToetsSql.getToetsJaren(inputstring)[0]);
                    }
                    else
                    {
                        toets = ToetsSql.getToets(inputstring, "");
                    }
                    List<string> dat = new List<string>();
                    dat.Add(cb_Zoek.SelectedItem.ToString());
                    dat.Add(inputstring);

                    this.LoadData(toets);
                }
                else
                {
                    lbl_err.Text = "Deze Toets bestaat niet";
                }
            }
            else
            {
                lbl_err.Text = "";
            }
        }
        private void dgv_toets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                int id = Convert.ToInt32(dgv_toets.Rows[row].Cells[0].Value);
                StudentSql.connect();
                if (StudentSql.studentExists(id))
                {
                    Student student = StudentSql.getStudent(id);
                    Form form = new Form();
                    StudentView view = new StudentView(student, form);
                    form.SetBounds(form.Bounds.X + 100,form.Bounds.Y + 100, 1280, 800);
                    form.Show();
                }
            }
        }
    }

}


