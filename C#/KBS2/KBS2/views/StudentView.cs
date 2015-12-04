using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using KBS2.model.cijfer;
using KBS2.model;
namespace KBS2.views
{
    class StudentView : Panel
    {
        //Student variabelen
        private Student student;
        
        //UI variablenen
        private Label lbl_naam;
        private Label lbl_id;
        private Label lbl_vakken;
        private Label lbl_toetsen;
        private ProgressBar testprb_gehaald;
        private Label lbl_totaalEC;
        private DataGridView dgv_vakken;
        private DataGridViewTextBoxColumn vak;
        private DataGridViewTextBoxColumn vakcijfer;
        private DataGridViewTextBoxColumn EC;

        private DataGridView dgv_toetsen;
        private DataGridViewTextBoxColumn vakgehaald;
        private DataGridViewTextBoxColumn cijfergehaald;
        private DataGridViewTextBoxColumn ECgehaald;

        private Label lbl_gehaald;
        private Label lbl_gemist;

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
                this.lbl_vakken.Text = "Gemiste EC\'s: " + student.gemisteEC();
                this.lbl_toetsen.Text = "Behaalde EC\'s dit jaar: " + student.gehaaldeEC();

                if (student.totaalEC() != 0)
                {
                    this.testprb_gehaald.Value = student.gehaaldeEC() * 100 / student.totaalEC();
                }
                else {
                    this.testprb_gehaald.Value = 0;
                }
                this.lbl_totaalEC.Text = "Van: " + student.totaalEC();
                
                //gaat door alle cijfers heen
                for (int i = 0; i < student.Cijfers.Count; i++)
                {
                    //checkt of het voldoende is
                    if (student.Cijfers[i].isVoldoende()) {
                        //zet het cijfer in de behaalde EC's tabel
                       // object[] c = { student.Cijfers[i].VakNaam, student.Cijfers[i].Cijfer, student.Cijfers[i].EC};
                        //dgv_behaaldeEC.Rows.Add(c);
                    }
                    else
                    {
                        //zet het cijfer in het behaalde EC's tabel
                        //object[] c = { student.Cijfers[i].VakNaam, student.Cijfers[i].Cijfer, student.Cijfers[i].EC };
                        //dgv_gemisteEC.Rows.Add(c);
                    }
                }

            }
            else
            {
                //als Student null is: zet standaard waardes in de UI
                this.lbl_naam.Text = "Naam";
                this.lbl_id.Text = "ID";
                this.lbl_vakken.Text = "Gemiste EC\'s:";
                this.lbl_toetsen.Text = "Behaalde EC\'s dit jaar:";
                this.testprb_gehaald.Value = 0;
                this.lbl_totaalEC.Text = "Van:";
            }
        }
        
        //maakt UI aan
        public void init()
        {
            this.lbl_naam = new Label();
            this.lbl_id = new Label();
            this.lbl_vakken = new Label();
            this.lbl_toetsen = new Label();
            this.testprb_gehaald = new ProgressBar();
            this.lbl_totaalEC = new Label();
            this.dgv_vakken = new DataGridView();
            this.vak = new DataGridViewTextBoxColumn();
            this.vakcijfer = new DataGridViewTextBoxColumn();
            this.EC = new DataGridViewTextBoxColumn();
            this.dgv_toetsen = new DataGridView();
            this.vakgehaald = new DataGridViewTextBoxColumn();
            this.cijfergehaald = new DataGridViewTextBoxColumn();
            this.ECgehaald = new DataGridViewTextBoxColumn();
            this.lbl_gehaald = new Label();
            this.lbl_gemist = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_vakken)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_toetsen)).BeginInit();
            this.SuspendLayout();
            
            //lbl_naam
            this.lbl_naam.AutoSize = true;
            this.lbl_naam.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_naam.Location = new System.Drawing.Point(532, 60);
            this.lbl_naam.Name = "lbl_naam";
            this.lbl_naam.Size = new System.Drawing.Size(57, 26);
            this.lbl_naam.TabIndex = 4;
            
            //lbl_id
            this.lbl_id.AutoSize = true;
            this.lbl_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_id.Location = new System.Drawing.Point(532, 90);
            this.lbl_id.Name = "lbl_naam";
            this.lbl_id.Size = new System.Drawing.Size(57, 26);
            this.lbl_id.TabIndex = 4;
            
            //lbl_gemisteEC
            this.lbl_vakken.AutoSize = true;
            this.lbl_vakken.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_vakken.Location = new System.Drawing.Point(951, 127);
            this.lbl_vakken.Name = "lbl_gemisteEC";
            this.lbl_vakken.Size = new System.Drawing.Size(152, 26);
            this.lbl_vakken.TabIndex = 5;
            
            //lbl_gehaaldeEC
            this.lbl_toetsen.AutoSize = true;
            this.lbl_toetsen.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_toetsen.Location = new System.Drawing.Point(95, 127);
            this.lbl_toetsen.Name = "lbl_gehaaldeEC";
            this.lbl_toetsen.Size = new System.Drawing.Size(233, 26);
            this.lbl_toetsen.TabIndex = 3;
            
            //testprb_gehaald
            this.testprb_gehaald.ForeColor = System.Drawing.Color.Lime;
            this.testprb_gehaald.Location = new System.Drawing.Point(100, 156);
            this.testprb_gehaald.Name = "testprb_gehaald";
            this.testprb_gehaald.Size = new System.Drawing.Size(1089, 23);
            this.testprb_gehaald.TabIndex = 6;
            
            //lbl_totaalEC
            this.lbl_totaalEC.AutoSize = true;
            this.lbl_totaalEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_totaalEC.Location = new System.Drawing.Point(532, 127);
            this.lbl_totaalEC.Name = "lbl_totaalEC";
            this.lbl_totaalEC.Size = new System.Drawing.Size(57, 26);
            this.lbl_totaalEC.TabIndex = 4;
            
            //dgv_gemisteEC
            this.dgv_vakken.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_vakken.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgv_vakken.Columns.AddRange(new DataGridViewColumn[] {
            this.vak,
            this.vakcijfer,
            this.EC});

            this.dgv_vakken.Location = new System.Drawing.Point(100, 234);
            this.dgv_vakken.Name = "dgv_gemisteEC";
            this.dgv_vakken.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_vakken.Size = new System.Drawing.Size(1089, 230);
            this.dgv_vakken.TabIndex = 7;
            
            //vakgemist
            this.vak.HeaderText = "Vak";
            this.vak.Name = "Vak";
            this.vak.ReadOnly = true;
            
            //Cijfergemist
            this.vakcijfer.HeaderText = "Cijfer";
            this.vakcijfer.Name = "Cijfer";
            this.vakcijfer.ReadOnly = true;
            
            //ECgemist
            this.EC.HeaderText = "EC\'s";
            this.EC.Name = "EC";
            this.EC.ReadOnly = true;
            
            //dgv_behaaldeEC
            this.dgv_toetsen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_toetsen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgv_toetsen.Columns.AddRange(new DataGridViewColumn[] {
            this.vakgehaald,
            this.cijfergehaald,
            this.ECgehaald});

            this.dgv_toetsen.Location = new System.Drawing.Point(100, 516);
            this.dgv_toetsen.Name = "dgv_behaaldeEC";
            this.dgv_toetsen.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_toetsen.Size = new System.Drawing.Size(1089, 230);
            this.dgv_toetsen.TabIndex = 8;
            
            //vakgehaald
            this.vakgehaald.HeaderText = "Vak";
            this.vakgehaald.Name = "dataGridViewTextBoxColumn1";
            this.vakgehaald.ReadOnly = true;
            
            //cijfergehaald
            this.cijfergehaald.HeaderText = "Cijfer";
            this.cijfergehaald.Name = "dataGridViewTextBoxColumn2";
            this.cijfergehaald.ReadOnly = true;
            
            //ECgehaald
            this.ECgehaald.HeaderText = "EC\'s";
            this.ECgehaald.Name = "dataGridViewTextBoxColumn3";
            this.ECgehaald.ReadOnly = true;
            
            //lbl_gehaald
            this.lbl_gehaald.AutoSize = true;
            this.lbl_gehaald.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_gehaald.Location = new System.Drawing.Point(95, 487);
            this.lbl_gehaald.Name = "lbl_gehaald";
            this.lbl_gehaald.Size = new System.Drawing.Size(144, 26);
            this.lbl_gehaald.TabIndex = 9;
            this.lbl_gehaald.Text = "Gehaalde Ec:";
            
            //lbl_gemist
            this.lbl_gemist.AutoSize = true;
            this.lbl_gemist.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_gemist.Location = new System.Drawing.Point(95, 205);
            this.lbl_gemist.Name = "lbl_gemist";
            this.lbl_gemist.Size = new System.Drawing.Size(132, 26);
            this.lbl_gemist.TabIndex = 10;
            this.lbl_gemist.Text = "Gemiste Ec:";
            
            //Alles samenvoegen
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.lbl_naam);
            this.Controls.Add(this.lbl_gemist);
            this.Controls.Add(this.lbl_gehaald);
            this.Controls.Add(this.dgv_toetsen);
            this.Controls.Add(this.dgv_vakken);
            this.Controls.Add(this.testprb_gehaald);
            this.Controls.Add(this.lbl_vakken);
            this.Controls.Add(this.lbl_totaalEC);
            this.Controls.Add(this.lbl_toetsen);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_vakken)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_toetsen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
