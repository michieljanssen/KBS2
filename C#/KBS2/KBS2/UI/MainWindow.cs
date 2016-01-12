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
            //init
            InitializeComponent();
            txbx_zoek_refresh(data);
            init();
            //laat toets data
            cb_jaar.DataSource = ToetsSql.getToetsJaren(toets.Naam);
            cb_datum.DataSource = ToetsSql.toetsData(toets.Naam, (string)cb_jaar.SelectedValue);
            LoadData(toets);
        }
        internal void init()    //additional GUI setup
        {
            //vullen gridview
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

        internal void LoadData(Toets toets) // laad toetsdata
        {
            this.toets = toets;
            dgv_toets.Rows.Clear();
            if (toets != null)
            {
                this.lbl_name.Text = toets.Naam;        // verander label naam
                this.lbl_behaald.Text = "Behaald: " + toets.voldoendes();   //aanpassen voldoendes
                this.lbl_nietbehaald.Text = "Niet behaald: " + toets.onvoldoendes(); // aanpassen onvoldoendes
                this.lbl_perc.Text = "Percentage: " + toets.percentageVold(); //aanpassen percentage gehaald
                this.lbl_err.Text = "";
                this.lbl_gem.Text = "Gemiddelde: " + toets.gemiddelde(); //aanpassen gemiddelde cijfer
                this.lbl_type.Text = "type: " + toets.Type;
                this.progressBar1.Value = toets.percentageVold();
                this.dgv_toets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dgv_toets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                if (toets.Cijfers.Count > 0)
                {
                    chrtreset(toets.Cijfers);   //diagram opnieuw tekenen
                    for (int i = 0; i < toets.Cijfers.Count; i++)
                    {
                        object[] row = { toets.Cijfers[i].ID, toets.Cijfers[i].Naam, toets.Cijfers[i].Cijfer, toets.Cijfers[i].Datum };
                        this.dgv_toets.Rows.Add(row);   //niewe rij toevoegen
                        this.dgv_toets.Rows[i].Cells[2].Style.ForeColor = Color.Red; // text kleur rood
                                                                                     //verandert de kleur van de text als voldoende is of niet
                        if (toets.Cijfers[i].ECsBehaald())
                        {
                            this.dgv_toets.Rows[i].Cells[2].Style.ForeColor = Color.Green; // tekst kleur groen als het voldoende is
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
            this.txbx_zoek.Text = data[1];          // vult de textbox 
            this.cb_Zoek.SelectedItem = data[0];  //selecteerd de zichtbaare waarde
        }
        internal void chrtreset(List<model.cijfer.ToetsCijfer> Cijferlijst)
        {
            chrt_.Series[0].Points.Clear();                 // maakt de diagram leeg
            //checked of cijferlijst niet null is
            if (Cijferlijst != null)
            {
                List<double> ccijfers = new List<Double>();
                foreach (ToetsCijfer tc in Cijferlijst)         //rond of op 0.5 punten
                {
                    double a = tc.Cijfer;
                    double b = topointfiveincrement(a);
                    ccijfers.Add(b);
                }
                //sorteerd de lijst
                ccijfers.Sort();
                int yval = 0;
                //gaat door alle x punten heen en vult de punten in
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

        internal double topointfiveincrement(double a) //rond af on 0.5
        {
            double b = a * 2;           //als  a = 2.7 b = 5.4
            double c = Math.Floor(b);   // c = 5.4 => 5.0
            double d = c / 2;           // d = 2.5
            return d;
        }

        //de datum wordt aangepast(event)
        private void cb_datum_SelectionChangeCommitted(object sender, EventArgs e)
        {

            ComboBox c = (ComboBox)sender;
            string datetime = c.GetItemText(c.SelectedItem);
            //checked of "beste resultaten is geselecteerd
            if (!c.SelectedValue.Equals("beste resultaten"))
            {
                //verkrijgt de toets met de beste resultaten van de leerlingen en laad die
                Toets t = ToetsSql.getToets(this.toets.Naam, (String)c.SelectedValue, (String)cb_jaar.SelectedValue);
                LoadData(t);
            }
            //ander laad de resultaten van een bepaalde datum
            else
            {
                //verkijgt en laad de resultaten van een specifieke datum
                Toets t = ToetsSql.getToets(this.toets.Naam, (String)cb_jaar.SelectedValue);
                LoadData(t);
            }
        }
        //jaar selectie verandert(event)
        private void cb_jaar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //verkrijgt de niewe datum lijst 
            cb_datum.DataSource = ToetsSql.toetsData(toets.Naam, (String)cb_jaar.SelectedValue);
            //volgende toets wordt geladen met het niewe gesecteerde jaar
            //checked of "beste resultaten is geselecteerd
            if (!cb_datum.SelectedValue.Equals("beste resultaten"))
            {
                //verkrijgt de toets met de beste resultaten van de leerlingen en laad die
                Toets t = ToetsSql.getToets(this.toets.Naam, (String)cb_datum.SelectedValue, (String)cb_jaar.SelectedValue);
                LoadData(t);
            }
            //ander laad de resultaten van een bepaalde datum
            else
            {
                //verkijgt en laad de resultaten van een specifieke datum
                Toets t = ToetsSql.getToets(this.toets.Naam, (String)cb_jaar.SelectedValue);
                LoadData(t);
            }
        }
        //keypress event voor de zoek textbalk
        private void txbx_zoek_KeyPress(object sender, KeyPressEventArgs e)
        {
            //checked of enter is ingedrukt
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //start met zoeken
                btn_zoek.PerformClick();
            }
        }
        //zoek knop is ingedrukt(event)
        private void Zk_Btn_Click(object sender, EventArgs e)
        {
            String inputstring = this.txbx_zoek.Text;
            //TODO Refine search 
            if (inputstring != "")
            {
                //toetssql connectie
                ToetsSql.connect();
                //checked of de toets bestaat
                if (ToetsSql.ToetsExists(inputstring))
                {
                    lbl_err.Text = "";
                    Toets toets = null;
                    //checked of de aantal toetsjaren niet 0 is
                    if (ToetsSql.getToetsJaren(inputstring).Count != 0)
                    {
                        //verkrijgt de toets met het laaste jaar
                        toets = ToetsSql.getToets(inputstring, ToetsSql.getToetsJaren(inputstring)[0]);
                    }
                    else
                    {
                        //verkrijgt de toets zonder jaar
                        toets = ToetsSql.getToets(inputstring, "");
                    }
                    List<string> dat = new List<string>();
                    dat.Add(cb_Zoek.SelectedItem.ToString());
                    dat.Add(inputstring);
                    //laad de toets
                    this.LoadData(toets);
                }
                //anders geef fout melding
                else
                {
                    lbl_err.Text = "Deze Toets bestaat niet";
                }
            }//zet fout melding  op niks
            else
            {
                lbl_err.Text = "";
            }
        }

        //student row ingedrukt(event)
        private void dgv_toets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            // checked of een rij met data is ingedrukt(invoegrow id is -1)
            if (row >= 0)
            {
                //verkrijg id
                int id = Convert.ToInt32(dgv_toets.Rows[row].Cells[0].Value);
                //connect naar student sql
                StudentSql.connect();
                //checked of de student bestaat
                if (StudentSql.studentExists(id))
                {//open student overzicht voor deze student
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


