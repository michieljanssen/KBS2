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
    public partial class ToetsPanel : UserControl
    {
        Toets toets;
        public ToetsPanel(Toets toets, List<string> data)
        {
            InitializeComponent();
            txbx_zoek_refresh(data);
            init();
            cb_jaar.DataSource = ToetsSql.getToetsJaren(toets.Naam);
            cb_datum.DataSource = ToetsSql.toetsData(toets.Naam, (string)cb_jaar.SelectedValue);
            LoadData(toets);
        }   //constructor
        internal void init()
        {
            //Fill gridview
            DataGridViewCellStyle dgvcs = new DataGridViewCellStyle();
            dgvcs.NullValue = null;
            this.dgv_toets.AlternatingRowsDefaultCellStyle = dgvcs;
            Font gridfont = new Font("Microsoft Sans Serif", 16F);
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
            Cijfer.HeaderCell.Style.Font = gridfont;
            Cijfer.DefaultCellStyle = dgvcs;
            Cijfer.HeaderText = "Cijfer";
            Cijfer.Name = "Cijfer";
            Cijfer.ReadOnly = true;
            Cijfer.Width = (int)(0.1 * dgv_toets.Width);

            //Leerlingnr
            Studentnr.HeaderCell.Style.Font = gridfont;
            Studentnr.DefaultCellStyle = dgvcs;
            Studentnr.HeaderText = "Studentnr";
            Studentnr.Name = "Studentnr";
            Studentnr.ReadOnly = true;
            Studentnr.Width = (int)(0.2 * dgv_toets.Width);

            //naam
            naam.HeaderCell.Style.Font = gridfont;
            naam.DefaultCellStyle = dgvcs;
            naam.HeaderText = "Naam";
            naam.Name = "naam";
            naam.ReadOnly = true;
            naam.Width = (int)(0.2 * dgv_toets.Width);



            //datum
            datum.HeaderCell.Style.Font = gridfont;
            datum.DefaultCellStyle = dgvcs;
            datum.HeaderText = "Datum van Afname";
            datum.Name = "datum";
            datum.ReadOnly = true;
            datum.Width = (int)(dgv_toets.Width - naam.Width - Studentnr.Width - Cijfer.Width);
        }                                //additional GUI setup
        internal void txbx_zoek_refresh(List<String> data)
        {
            this.txbx_zoek.Text = data[1];          // fils in the textbox
            this.cb_Zoek.SelectedItem = data[0];  // get's the selected item
        }  //refres search area info

        internal void LoadData(Toets toets) //loads data
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
            if (toets.Cijfers.Count > 0)    //if grades are found
            {
                chrt_refresh(toets.Cijfers);    //refresh the diagram
                for (int i = 0; i < toets.Cijfers.Count; i++)
                {
                    object[] row = { toets.Cijfers[i].ID, toets.Cijfers[i].Naam, toets.Cijfers[i].Cijfer, toets.Cijfers[i].Datum };
                    this.dgv_toets.Rows.Add(row);   //add the cijfers to the 
                    this.dgv_toets.Rows[i].Cells[2].Style.ForeColor = Color.Red;    //default gradecolor = red
                    if (toets.Cijfers[i].isVoldoende())
                    {
                        this.dgv_toets.Rows[i].Cells[2].Style.ForeColor = Color.Green; //acceptable grades are green
                    }
                }
            }
            else
            {
                this.lbl_err.Text = "Deze toets heeft geen cijfers";    //show an error message when no grades are found
            }
        }   
        internal void chrt_refresh(List<model.cijfer.ToetsCijfer> Cijferlijst)  //refresh the diagram
        {
            chrt_.Series[0].Points.Clear();                 // clear old data
            List<double> ccijfers = new List<Double>();
            foreach (ToetsCijfer tc in Cijferlijst)         //round grades down to .5 increments
            {
                double a = tc.Cijfer;
                double b = roundtopointfiveincrement(a);
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
        internal double roundtopointfiveincrement(double a)  //rounds grades down to point five increments
        {
            double b = a * 2;           //for a = 2.7 gives b = a*2 = 2.7*2 = 5.4
            double c = Math.Floor(b);   //c = 5.4 => 5.0
            double d = c / 2;           //d = c/2 = 5/2 = 2.5
            return d;
        }  

        private void cb_datum_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            Console.WriteLine("Clicked = " + c.SelectedValue);
            string datetime = c.GetItemText(c.SelectedItem);
            if (!c.SelectedValue.Equals("beste resultaten"))
            {
                Toets t = ToetsSql.getToets(this.toets.Naam, (String)c.SelectedValue, (String)cb_jaar.SelectedValue);   //return specific grades by date
                LoadData(t);
            }
            else
            {
                Toets t = ToetsSql.getToets(this.toets.Naam, (String)cb_jaar.SelectedValue);        //return all grades
                LoadData(t);
            }
        }       //handles grades presentation
        private void cb_jaar_SelectionChangeCommitted(object sender, EventArgs e)//handles  grades presentation
        {
            cb_datum.DataSource = ToetsSql.toetsData(toets.Naam, (String)cb_jaar.SelectedValue);
            if (!cb_datum.SelectedValue.Equals("beste resultaten"))
            {
                Toets t = ToetsSql.getToets(this.toets.Naam, (String)cb_datum.SelectedValue, (String)cb_jaar.SelectedValue);    //returns all grades by year
                LoadData(t);
            }
            else
            {
                Toets t = ToetsSql.getToets(this.toets.Naam, (String)cb_jaar.SelectedValue);
                LoadData(t);
            }
        }       
        private void txbx_zoek_KeyPress(object sender, KeyPressEventArgs e)//handles search event
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btn_zoek.PerformClick();    //perform a click on the btn_zoek button (see Zk_Btn_Click)
            }
        }               
        private void dgv_toets_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //handles the gridview event
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
                    form.SetBounds(form.Bounds.X + 100,form.Bounds.Y + 100,form.Bounds.Width,form.Bounds.Height);
                    form.Show();
                }
            }
        }   
        private void Zk_Btn_Click(object sender, EventArgs e) //handles search event
        {
            String inputstring = this.txbx_zoek.Text;       //user input string
            //TODO Refine search 
            if (inputstring != "")          //if string is not empty
            {
                ToetsSql.connect();         //connect to the database
                if (ToetsSql.ToetsExists(inputstring))
                {
                    lbl_err.Text = "";      //clear errors
                    Toets toets = null;
                    if (ToetsSql.getToetsJaren(inputstring).Count != 0)     //check for exsisting test
                    {
                        toets = ToetsSql.getToets(inputstring, ToetsSql.getToetsJaren(inputstring)[0]); //get testdata
                    }
                    else
                    {
                        toets = ToetsSql.getToets(inputstring, "");     //get empty testdata
                    }
                    List<string> dat = new List<string>();      //create list with searchdata
                    dat.Add(cb_Zoek.SelectedItem.ToString());   //add dropdown data
                    dat.Add(inputstring);                       //add input string
                    txbx_zoek_refresh(dat);                     //refresh textbox
                    this.LoadData(toets);                       //load the found data
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

    }

}


