using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using KBS2.model.cijfer;
using KBS2.model;
using System.Drawing;

namespace KBS2.views
{
    class StudentView : Panel
    {
        //Student variabelen
        private Student student;
        
        //UI variablenen
        private Label lbl_naam;
        private Label lbl_id;
        private Label lbl_GemisteEC;
        private Label lbl_BehaaldeEC;
        private ProgressBar testprb_behaald;
        private Label lbl_totaalEC;
        private DataGridView dgv_vakken;
        private DataGridViewTextBoxColumn vak;
        private DataGridViewTextBoxColumn vakcijfer;
        private DataGridViewTextBoxColumn behaald;
        private DataGridViewTextBoxColumn EC;

        private DataGridView dgv_toetsen;
        private DataGridViewTextBoxColumn toets;
        private DataGridViewTextBoxColumn cijfer;
        private DataGridViewTextBoxColumn toetsBehaald;

        private Label lbl_toets;
        private Label lbl_vak;

        public StudentView(Student student, Form form)
            : base()
        {
            this.Parent = form;
            this.student = student;
            init();
            
            //checkt of het student niet null is
            if (student != null)
            {
                //zet alle variablen in de UI elementen
                this.lbl_naam.Text = student.Naam;
                this.lbl_id.Text = student.ID;
                this.lbl_GemisteEC.Text = "Gemiste EC\'s: " + student.gemisteEC();
                this.lbl_BehaaldeEC.Text = "Behaalde EC\'s dit jaar:" + student.gehaaldeEC();
                if (student.totaalEC() != 0)
                {
                    this.testprb_behaald.Value = student.gehaaldeEC() * 100 / student.totaalEC();
                }
                else {
                    this.testprb_behaald.Value = 0;
                }
                this.lbl_totaalEC.Text = "Van: " + student.totaalEC();
                //gaat door alle cijfers heen
                for (int i = 0; i < student.Cijfers.Count; i++)
                {
                    VakCijfer vak = student.Cijfers[i];

                    if (vak.isVoldoende() == false)
                    {
                        object[] obj = { vak.VakNaam, "", "Niet Behaald", vak.EC };

                        this.dgv_vakken.Rows.Add(obj);                
                    } else
                    {
                        object[] obj = { vak.VakNaam, vak.gemiddelde(), "Behaald", vak.EC };

                        this.dgv_vakken.Rows.Add(obj);
                    }
                }

            }
            else
            {
                //als Student null is: zet standaard waardes in de UI
                this.lbl_naam.Text = "Naam";
                this.lbl_id.Text = "ID";
                this.lbl_GemisteEC.Text = "Gemiste EC\'s:";
                this.lbl_BehaaldeEC.Text = "Behaalde EC\'s dit jaar:";
                this.testprb_behaald.Value = 0;
                this.lbl_totaalEC.Text = "Van:";
            }
        }
        
        //maakt UI aan
        public void init()
        {
            this.lbl_naam = new Label();
            this.lbl_id = new Label();
            this.lbl_GemisteEC = new Label();
            this.lbl_BehaaldeEC = new Label();
            this.testprb_behaald = new ProgressBar();
            this.lbl_totaalEC = new Label();
            this.dgv_vakken = new DataGridView();
            this.vak = new DataGridViewTextBoxColumn();
            this.vakcijfer = new DataGridViewTextBoxColumn();
            this.EC = new DataGridViewTextBoxColumn();
            this.dgv_toetsen = new DataGridView();
            this.toets = new DataGridViewTextBoxColumn();
            this.cijfer = new DataGridViewTextBoxColumn();
            this.behaald = new DataGridViewTextBoxColumn();
            this.toetsBehaald = new DataGridViewTextBoxColumn();
            this.lbl_toets = new Label();
            this.lbl_vak = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_vakken)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_toetsen)).BeginInit();
            this.SuspendLayout();
            
            //lbl_naam
            this.lbl_naam.AutoSize = true;
            this.lbl_naam.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_naam.Location = new System.Drawing.Point(600, 60);
            this.lbl_naam.Name = "lbl_naam";
            this.lbl_naam.Size = new System.Drawing.Size(57, 26);
            this.lbl_naam.TabIndex = 4;
            
            //lbl_id
            this.lbl_id.AutoSize = true;
            this.lbl_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_id.Location = new System.Drawing.Point(600, 90);
            this.lbl_id.Name = "lbl_naam";
            this.lbl_id.Size = new System.Drawing.Size(57, 26);
            this.lbl_id.TabIndex = 4;
            
            //lbl_gemisteEC
            this.lbl_GemisteEC.AutoSize = true;
            this.lbl_GemisteEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_GemisteEC.Location = new System.Drawing.Point(951, 127);
            this.lbl_GemisteEC.Name = "lbl_gemisteEC";
            this.lbl_GemisteEC.Size = new System.Drawing.Size(152, 26);
            this.lbl_GemisteEC.TabIndex = 5;
            
            //lbl_behaaldeEC
            this.lbl_BehaaldeEC.AutoSize = true;
            this.lbl_BehaaldeEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_BehaaldeEC.Location = new System.Drawing.Point(95, 127);
            this.lbl_BehaaldeEC.Name = "lbl_behaaldeEC";
            this.lbl_BehaaldeEC.Size = new System.Drawing.Size(233, 26);
            this.lbl_BehaaldeEC.TabIndex = 3;
            
            //testprb_behaald
            this.testprb_behaald.ForeColor = System.Drawing.Color.Lime;
            this.testprb_behaald.Location = new System.Drawing.Point(100, 156);
            this.testprb_behaald.Name = "testprb_behaald";
            this.testprb_behaald.Size = new System.Drawing.Size(1089, 23);
            this.testprb_behaald.TabIndex = 6;
            
            //lbl_totaalEC
            this.lbl_totaalEC.AutoSize = true;
            this.lbl_totaalEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_totaalEC.Location = new System.Drawing.Point(600, 127);
            this.lbl_totaalEC.Name = "lbl_totaalEC";
            this.lbl_totaalEC.Size = new System.Drawing.Size(57, 26);
            this.lbl_totaalEC.TabIndex = 4;
            
            //dgv_gemisteEC
            this.dgv_vakken.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_vakken.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgv_vakken.Columns.AddRange(new DataGridViewColumn[] {
            this.vak,
            this.vakcijfer,
            this.behaald,
            this.EC});

            this.dgv_vakken.Location = new System.Drawing.Point(100, 234);
            this.dgv_vakken.Name = "dgv_vakken";
            this.dgv_vakken.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_vakken.Size = new System.Drawing.Size(1089, 230);
            this.dgv_vakken.TabIndex = 7;
            this.dgv_vakken.CellClick += Dgv_vakken_CellClick;
            this.dgv_vakken.AllowUserToAddRows = false;
            //vakgemist
            this.vak.HeaderText = "Vak";
            this.vak.Name = "Vak";
            this.vak.ReadOnly = true;
            
            //Cijfergemist
            this.vakcijfer.HeaderText = "Cijfer";
            this.vakcijfer.Name = "Cijfer";
            this.vakcijfer.ReadOnly = true;

            this.behaald.HeaderText = "Behaald";
            this.behaald.Name = "Behaald";
            this.behaald.ReadOnly = true;

            //ECgemist
            this.EC.HeaderText = "EC\'s";
            this.EC.Name = "EC";
            this.EC.ReadOnly = true;
            
            //dgv_behaaldeEC
            this.dgv_toetsen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_toetsen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgv_toetsen.Columns.AddRange(new DataGridViewColumn[] {
            this.toets,
            this.cijfer,
            this.toetsBehaald});

            this.dgv_toetsen.Location = new System.Drawing.Point(100, 516);
            this.dgv_toetsen.Name = "dgv_behaaldeEC";
            this.dgv_toetsen.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_toetsen.Size = new System.Drawing.Size(1089, 230);
            this.dgv_toetsen.TabIndex = 8;
            this.dgv_toetsen.AllowUserToAddRows = false;
            //vakgehaald
            this.toets.HeaderText = "Toets";
            this.toets.Name = "dataGridViewTextBoxColumn1";
            this.toets.ReadOnly = true;

            //cijfergehaald
            this.cijfer.HeaderText = "Cijfer";
            this.cijfer.Name = "dataGridViewTextBoxColumn2";
            this.cijfer.ReadOnly = true;

            this.toetsBehaald.HeaderText = "Behaald";
            this.toetsBehaald.Name = "Behaald";
            this.toetsBehaald.ReadOnly = true;

            //lbl_gehaald
            this.lbl_toets.AutoSize = true;
            this.lbl_toets.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_toets.Location = new System.Drawing.Point(95, 487);
            this.lbl_toets.Name = "lbl_Toetsen";
            this.lbl_toets.Size = new System.Drawing.Size(144, 26);
            this.lbl_toets.TabIndex = 9;
            this.lbl_toets.Text = "Toetsen";
            
            //lbl_gemist
            this.lbl_vak.AutoSize = true;
            this.lbl_vak.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_vak.Location = new System.Drawing.Point(95, 205);
            this.lbl_vak.Name = "lbl_vak";
            this.lbl_vak.Size = new System.Drawing.Size(132, 26);
            this.lbl_vak.TabIndex = 10;
            this.lbl_vak.Text = "Vakken";
            
            //Alles samenvoegen
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.lbl_naam);
            this.Controls.Add(this.lbl_vak);
            this.Controls.Add(this.lbl_toets);
            this.Controls.Add(this.dgv_toetsen);
            this.Controls.Add(this.dgv_vakken);
            this.Controls.Add(this.testprb_behaald);
            this.Controls.Add(this.lbl_GemisteEC);
            this.Controls.Add(this.lbl_totaalEC);
            this.Controls.Add(this.lbl_BehaaldeEC);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_vakken)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_toetsen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void Dgv_vakken_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                this.dgv_toetsen.Rows.Clear();
                VakCijfer vak = student.getVakCijfer((String)dgv_vakken.Rows[e.RowIndex].Cells[0].Value);

                for (int i = 0; i < vak.Cijfers.Count; i++)
                {
                    ToetsCijfer cijfer = vak.Cijfers[i];
                    //verandert de kleur van de text als voldoende is of niet
                    if (cijfer.isVoldoende() == true)
                    {
                        object[] obj = { cijfer.ToetsNaam, cijfer.Cijfer, "Behaald"};
                        this.dgv_toetsen.Rows.Add(obj);
                        //groen voor voldoende
                        this.dgv_toetsen.Rows[i].Cells[1].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        object[] obj = { cijfer.ToetsNaam, cijfer.Cijfer, "Niet Behaald"};
                        this.dgv_toetsen.Rows.Add(obj);

                        //rood voor onvoldoende
                        this.dgv_toetsen.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                    }
                }
            }
        }
    }
}
