using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using KBS2.model;
using KBS2.data;

namespace KBS2.views
{
    class ToetsView : Panel
    {
        //Nieuwe toets aanmaken
        private Toets toets;
        private Form form;

        //UI componenten
        private Label lbl_toetsnaam;
        private Label lbl_aantalbehaald;
        private Label lbl_aantalnietbehaald;
        private Label lbl_percentage;
        private ProgressBar prb_behaald;
        private Label lbl_gemiddelde;
        private Label lbl_toetsType;
        private ComboBox cb_datum;
        private ComboBox cb_jaar;
        private DataGridView dgv_toets;
        private DataGridViewTextBoxColumn Leerlingnr;
        private DataGridViewTextBoxColumn naam;
        private DataGridViewTextBoxColumn Cijfer;
        private DataGridViewTextBoxColumn datum;

        public ToetsView(Toets toets, Form form)
            : base()
        {
            this.form = form;
            this.Parent = form;
            this.toets = toets;
            init();
            cb_jaar.DataSource = ToetsSql.getToetsJaren(toets.Naam);
            cb_datum.DataSource = ToetsSql.toetsData(toets.Naam, (String)cb_jaar.SelectedValue);
            load(toets);
        }
        //laad de teots
        public void load(Toets toets)
        {
            this.toets = toets;
            //checkt of de toets gemaakt is
            if (toets != null)
            {
                //zet alle variabelen in de UI elementen
                this.lbl_toetsnaam.Text = "Toets: " + toets.Naam;
                this.lbl_aantalnietbehaald.Text = "Niet behaald: " + toets.onvoldoendes();
                this.lbl_percentage.Text = "Percentages behaald: " + toets.percentageVold() + "%";
                this.lbl_aantalbehaald.Text = "Behaald: " + toets.voldoendes();
                this.lbl_toetsType.Text = "Toetstype: " + toets.Type;
                this.prb_behaald.Value = toets.percentageVold();
                this.lbl_gemiddelde.Text = "Gemiddelde: " + toets.gemiddelde().ToString("0.0");
                //checked of er cijfers instaan
                dgv_toets.Rows.Clear();
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
            else
            {
                //als de toets niet gemaakt is worden de standaard waardes in de UI elementen gezet
                this.lbl_toetsnaam.Text = "Behaald:";
                this.lbl_aantalnietbehaald.Text = "Niet Behaald:";
                this.lbl_percentage.Text = "Percentagesnaam";
                this.lbl_aantalbehaald.Text = "behaald: %";
                this.lbl_toetsType.Text = "Toetstype:";
                this.prb_behaald.Value = 0;
                this.lbl_gemiddelde.Text = "Gemiddelde:";
                object[] rows = { "1", "2", "3" };
                this.dgv_toets.Rows.Add(rows);
            }

        }

        //maakt UI aan
        public void init()
        {
            this.lbl_toetsnaam = new Label();
            this.lbl_aantalbehaald = new Label();
            this.lbl_aantalnietbehaald = new Label();
            this.lbl_percentage = new Label();
            this.prb_behaald = new ProgressBar();
            this.lbl_gemiddelde = new Label();
            this.lbl_toetsType = new Label();
            this.dgv_toets = new DataGridView();
            this.Leerlingnr = new DataGridViewTextBoxColumn();
            this.naam = new DataGridViewTextBoxColumn();
            this.Cijfer = new DataGridViewTextBoxColumn();
            this.datum = new DataGridViewTextBoxColumn();
            this.cb_datum = new ComboBox();
            this.cb_jaar = new ComboBox();
            this.SuspendLayout();

            //cb_jaar
            this.cb_jaar.Size = new Size(150, 30);
            this.cb_jaar.Location = new Point(879, 200);
            this.cb_jaar.SelectionChangeCommitted += Cb_jaar_SelectionChangeCommitted;

            //cb_datum
            this.cb_datum.Size = new Size(150, 30);
            this.cb_datum.Location = new Point(1039, 200);
            this.cb_datum.SelectionChangeCommitted += Cb_datum_SelectionChangeCommitted;

            //lbl_toetsnaam
            this.lbl_toetsnaam.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this.lbl_toetsnaam.AutoSize = true;
            this.lbl_toetsnaam.Font = new Font("Microsoft Sans Serif", 24F);
            this.lbl_toetsnaam.Location = new Point(560, 70);
            this.lbl_toetsnaam.Name = "lbl_toetsnaam";
            this.lbl_toetsnaam.Size = new Size(178, 37);
            this.lbl_toetsnaam.TabIndex = 2;

            //lbl_aantalbehaald
            this.lbl_aantalbehaald.AutoSize = true;
            this.lbl_aantalbehaald.Font = new Font("Microsoft Sans Serif", 16F);
            this.lbl_aantalbehaald.Location = new Point(95, 127);
            this.lbl_aantalbehaald.Name = "lbl_aantalbehaald";
            this.lbl_aantalbehaald.Size = new Size(197, 26);
            this.lbl_aantalbehaald.TabIndex = 3;

            //lbl_aantalnietbehaald
            this.lbl_aantalnietbehaald.AutoSize = true;
            this.lbl_aantalnietbehaald.Font = new Font("Microsoft Sans Serif", 16F);
            this.lbl_aantalnietbehaald.Location = new Point(532, 127);
            this.lbl_aantalnietbehaald.Name = "lbl_aantalnietbehaald";
            this.lbl_aantalnietbehaald.Size = new Size(221, 26);
            this.lbl_aantalnietbehaald.TabIndex = 4;

            //lbl_percentage
            this.lbl_percentage.AutoSize = true;
            this.lbl_percentage.Font = new Font("Microsoft Sans Serif", 16F);
            this.lbl_percentage.Location = new Point(910, 127);
            this.lbl_percentage.Name = "lbl_percentage";
            this.lbl_percentage.Size = new Size(238, 26);
            this.lbl_percentage.TabIndex = 5;

            //prb_behaald
            this.prb_behaald.ForeColor = Color.Lime;
            this.prb_behaald.Location = new Point(100, 156);
            this.prb_behaald.Name = "prb_behaald";
            this.prb_behaald.Size = new Size(1089, 23);
            this.prb_behaald.TabIndex = 6;

            //lbl_gemiddelde
            this.lbl_gemiddelde.AutoSize = true;
            this.lbl_gemiddelde.Font = new Font("Microsoft Sans Serif", 16F);
            this.lbl_gemiddelde.Location = new Point(95, 204);
            this.lbl_gemiddelde.Name = "lbl_gemiddelde";
            this.lbl_gemiddelde.Size = new Size(136, 26);
            this.lbl_gemiddelde.TabIndex = 7;

            //lbl_toetsType
            this.lbl_toetsType.AutoSize = true;
            this.lbl_toetsType.Font = new Font("Microsoft Sans Serif", 16F);
            this.lbl_toetsType.Location = new Point(448, 204);
            this.lbl_toetsType.Name = "testlbl_toetsType";
            this.lbl_toetsType.Size = new Size(112, 26);
            this.lbl_toetsType.TabIndex = 8;

            //dgv_toets
            DataGridViewCellStyle dgvcs = new DataGridViewCellStyle();
            dgvcs.NullValue = null;
            this.dgv_toets.AlternatingRowsDefaultCellStyle = dgvcs;
            this.dgv_toets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_toets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_toets.AllowUserToAddRows = false;
            this.dgv_toets.CellDoubleClick += dgv_toets_CellDoubleClick;

            this.dgv_toets.Columns.AddRange(new DataGridViewColumn[] {
            this.Leerlingnr,
            this.naam,
            this.Cijfer, this.datum});

            this.dgv_toets.Location = new Point(100, 246);
            this.dgv_toets.Name = "dgv_toets";
            this.dgv_toets.Size = new Size(1089, 454);
            this.dgv_toets.TabIndex = 0;

            //Leerlingnr
            this.Leerlingnr.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 16F);
            this.Leerlingnr.DefaultCellStyle = dgvcs;
            this.Leerlingnr.HeaderText = "Leerlingnr";
            this.Leerlingnr.Name = "Leerlingnr";
            this.Leerlingnr.ReadOnly = true;

            //naam
            this.naam.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 16F);
            this.naam.DefaultCellStyle = dgvcs;
            this.naam.HeaderText = "Naam";
            this.naam.Name = "naam";
            this.naam.ReadOnly = true;

            //Cijfer
            this.Cijfer.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 16F);
            this.Cijfer.DefaultCellStyle = dgvcs;
            this.Cijfer.HeaderText = "Cijfer";
            this.Cijfer.Name = "Cijfer";
            this.Cijfer.ReadOnly = true;

            //datum
            this.datum.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 16F);
            this.datum.DefaultCellStyle = dgvcs;
            this.datum.HeaderText = "Datum van Afname";
            this.datum.Name = "datum";
            this.datum.ReadOnly = true;

            //Alles toevoegen
            this.ClientSize = new Size(1264, 761);
            this.Controls.Add(this.dgv_toets);
            this.Controls.Add(this.lbl_toetsType);
            this.Controls.Add(this.lbl_gemiddelde);
            this.Controls.Add(this.prb_behaald);
            this.Controls.Add(this.lbl_percentage);
            this.Controls.Add(this.lbl_aantalnietbehaald);
            this.Controls.Add(this.lbl_aantalbehaald);
            this.Controls.Add(this.lbl_toetsnaam);
            this.Controls.Add(this.cb_datum);
            this.Controls.Add(this.cb_jaar);
        }

        private void Cb_jaar_SelectionChangeCommitted(object sender, EventArgs e)
        {
           cb_datum.DataSource = ToetsSql.toetsData(toets.Naam, (String)cb_jaar.SelectedValue);
           if (!cb_datum.SelectedValue.Equals("beste resultaten"))
           {
               Toets t = ToetsSql.getToets(this.toets.Naam, (String)cb_datum.SelectedValue, (String)cb_jaar.SelectedValue);
               load(t);
           }
           else
           {
               Toets t = ToetsSql.getToets(this.toets.Naam, (String)cb_jaar.SelectedValue);
               load(t);
           }
        }

        private void Cb_datum_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            Console.WriteLine("Clicked = " + c.SelectedValue );
            if (!c.SelectedValue.Equals("beste resultaten"))
            {
                Toets t = ToetsSql.getToets(this.toets.Naam, (String)c.SelectedValue, (String)cb_jaar.SelectedValue);
                load(t);
            }
            else {
                Toets t = ToetsSql.getToets(this.toets.Naam,(String) cb_jaar.SelectedValue);
                load(t);
            }
        }
        private void dgv_toets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                int id = Convert.ToInt32(dgv_toets.Rows[row].Cells[0].Value);
                if (StudentSql.studentExists(id))
                {
                    Student student = StudentSql.getStudent(id);
                    Form form = new Form();
                    StudentView view = new StudentView(student, form);
                    form.SetBounds(this.form.Bounds.X + 100, this.form.Bounds.Y + 100, this.form.Bounds.Width, this.form.Bounds.Height);
                    form.Show();
                }
            }
        }
    }
}



