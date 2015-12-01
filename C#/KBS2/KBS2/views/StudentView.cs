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
        private Label lbl_gemisteEC;
        private Label lbl_gehaaldeEC;
        private ProgressBar testprb_gehaald;
        private Label lbl_totaalEC;
        private DataGridView dgv_gemisteEC;
        private DataGridViewTextBoxColumn vakgemist;
        private DataGridViewTextBoxColumn Cijfergemist;
        private DataGridViewTextBoxColumn ECgemist;
        private DataGridView dgv_behaaldeEC;
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
                this.lbl_gemisteEC.Text = "Gemiste EC\'s: " + student.gemisteEC();
                this.lbl_gehaaldeEC.Text = "Behaalde EC\'s dit jaar: " + student.gehaaldeEC();

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
                        object[] c = { student.Cijfers[i].VakNaam, student.Cijfers[i].Cijfer, student.Cijfers[i].EC};
                        dgv_behaaldeEC.Rows.Add(c);
                    }
                    else
                    {
                        //zet het cijfer in het behaalde EC's tabel
                        object[] c = { student.Cijfers[i].VakNaam, student.Cijfers[i].Cijfer, student.Cijfers[i].EC };
                        dgv_gemisteEC.Rows.Add(c);
                    }
                }

            }
            else
            {
                //als Student null is: zet standaard waardes in de UI
                this.lbl_naam.Text = "Naam";
                this.lbl_id.Text = "ID";
                this.lbl_gemisteEC.Text = "Gemiste EC\'s:";
                this.lbl_gehaaldeEC.Text = "Behaalde EC\'s dit jaar:";
                this.testprb_gehaald.Value = 0;
                this.lbl_totaalEC.Text = "Van:";
            }
        }
        
        //maakt UI aan
        public void init()
        {
            this.lbl_naam = new Label();
            this.lbl_id = new Label();
            this.lbl_gemisteEC = new Label();
            this.lbl_gehaaldeEC = new Label();
            this.testprb_gehaald = new ProgressBar();
            this.lbl_totaalEC = new Label();
            this.dgv_gemisteEC = new DataGridView();
            this.vakgemist = new DataGridViewTextBoxColumn();
            this.Cijfergemist = new DataGridViewTextBoxColumn();
            this.ECgemist = new DataGridViewTextBoxColumn();
            this.dgv_behaaldeEC = new DataGridView();
            this.vakgehaald = new DataGridViewTextBoxColumn();
            this.cijfergehaald = new DataGridViewTextBoxColumn();
            this.ECgehaald = new DataGridViewTextBoxColumn();
            this.lbl_gehaald = new Label();
            this.lbl_gemist = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gemisteEC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_behaaldeEC)).BeginInit();
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
            this.lbl_gemisteEC.AutoSize = true;
            this.lbl_gemisteEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_gemisteEC.Location = new System.Drawing.Point(951, 127);
            this.lbl_gemisteEC.Name = "lbl_gemisteEC";
            this.lbl_gemisteEC.Size = new System.Drawing.Size(152, 26);
            this.lbl_gemisteEC.TabIndex = 5;
            
            //lbl_gehaaldeEC
            this.lbl_gehaaldeEC.AutoSize = true;
            this.lbl_gehaaldeEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_gehaaldeEC.Location = new System.Drawing.Point(95, 127);
            this.lbl_gehaaldeEC.Name = "lbl_gehaaldeEC";
            this.lbl_gehaaldeEC.Size = new System.Drawing.Size(233, 26);
            this.lbl_gehaaldeEC.TabIndex = 3;
            
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
            this.dgv_gemisteEC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_gemisteEC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgv_gemisteEC.Columns.AddRange(new DataGridViewColumn[] {
            this.vakgemist,
            this.Cijfergemist,
            this.ECgemist});

            this.dgv_gemisteEC.Location = new System.Drawing.Point(100, 234);
            this.dgv_gemisteEC.Name = "dgv_gemisteEC";
            this.dgv_gemisteEC.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_gemisteEC.Size = new System.Drawing.Size(1089, 230);
            this.dgv_gemisteEC.TabIndex = 7;
            
            //vakgemist
            this.vakgemist.HeaderText = "Vak";
            this.vakgemist.Name = "Vak";
            this.vakgemist.ReadOnly = true;
            
            //Cijfergemist
            this.Cijfergemist.HeaderText = "Cijfer";
            this.Cijfergemist.Name = "Cijfer";
            this.Cijfergemist.ReadOnly = true;
            
            //ECgemist
            this.ECgemist.HeaderText = "EC\'s";
            this.ECgemist.Name = "EC";
            this.ECgemist.ReadOnly = true;
            
            //dgv_behaaldeEC
            this.dgv_behaaldeEC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_behaaldeEC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgv_behaaldeEC.Columns.AddRange(new DataGridViewColumn[] {
            this.vakgehaald,
            this.cijfergehaald,
            this.ECgehaald});

            this.dgv_behaaldeEC.Location = new System.Drawing.Point(100, 516);
            this.dgv_behaaldeEC.Name = "dgv_behaaldeEC";
            this.dgv_behaaldeEC.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_behaaldeEC.Size = new System.Drawing.Size(1089, 230);
            this.dgv_behaaldeEC.TabIndex = 8;
            
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
            this.Controls.Add(this.dgv_behaaldeEC);
            this.Controls.Add(this.dgv_gemisteEC);
            this.Controls.Add(this.testprb_gehaald);
            this.Controls.Add(this.lbl_gemisteEC);
            this.Controls.Add(this.lbl_totaalEC);
            this.Controls.Add(this.lbl_gehaaldeEC);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gemisteEC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_behaaldeEC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
