namespace KBS2
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.testbtn_zoek = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.testlbl_toetsnaam = new System.Windows.Forms.Label();
            this.testlbl_aantalvoldoendes = new System.Windows.Forms.Label();
            this.testlbl_aantalonvoldoendes = new System.Windows.Forms.Label();
            this.testlbl_percentage = new System.Windows.Forms.Label();
            this.testprb_gehaald = new System.Windows.Forms.ProgressBar();
            this.lbl_gemiddelde = new System.Windows.Forms.Label();
            this.testlbl_toetsType = new System.Windows.Forms.Label();
            this.testlbl_afname = new System.Windows.Forms.Label();
            this.dgv_toets = new System.Windows.Forms.DataGridView();
            this.Leerlingnr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.naam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijfer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_toets)).BeginInit();
            this.SuspendLayout();
            // 
            // testbtn_zoek
            // 
            this.testbtn_zoek.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.testbtn_zoek.Location = new System.Drawing.Point(977, 20);
            this.testbtn_zoek.Name = "testbtn_zoek";
            this.testbtn_zoek.Size = new System.Drawing.Size(72, 32);
            this.testbtn_zoek.TabIndex = 0;
            this.testbtn_zoek.Text = "Zoek";
            this.testbtn_zoek.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.textBox1.Location = new System.Drawing.Point(334, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(628, 32);
            this.textBox1.TabIndex = 1;
            // 
            // testlbl_toetsnaam
            // 
            this.testlbl_toetsnaam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.testlbl_toetsnaam.AutoSize = true;
            this.testlbl_toetsnaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.testlbl_toetsnaam.Location = new System.Drawing.Point(560, 70);
            this.testlbl_toetsnaam.Name = "testlbl_toetsnaam";
            this.testlbl_toetsnaam.Size = new System.Drawing.Size(178, 37);
            this.testlbl_toetsnaam.TabIndex = 2;
            this.testlbl_toetsnaam.Text = "Toetsnaam";
            // 
            // testlbl_aantalvoldoendes
            // 
            this.testlbl_aantalvoldoendes.AutoSize = true;
            this.testlbl_aantalvoldoendes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.testlbl_aantalvoldoendes.Location = new System.Drawing.Point(95, 127);
            this.testlbl_aantalvoldoendes.Name = "testlbl_aantalvoldoendes";
            this.testlbl_aantalvoldoendes.Size = new System.Drawing.Size(197, 26);
            this.testlbl_aantalvoldoendes.TabIndex = 3;
            this.testlbl_aantalvoldoendes.Text = "Aantal voldoendes:";
            // 
            // testlbl_aantalonvoldoendes
            // 
            this.testlbl_aantalonvoldoendes.AutoSize = true;
            this.testlbl_aantalonvoldoendes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.testlbl_aantalonvoldoendes.Location = new System.Drawing.Point(532, 127);
            this.testlbl_aantalonvoldoendes.Name = "testlbl_aantalonvoldoendes";
            this.testlbl_aantalonvoldoendes.Size = new System.Drawing.Size(221, 26);
            this.testlbl_aantalonvoldoendes.TabIndex = 4;
            this.testlbl_aantalonvoldoendes.Text = "Aantal onvoldoendes:";
            // 
            // testlbl_percentage
            // 
            this.testlbl_percentage.AutoSize = true;
            this.testlbl_percentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.testlbl_percentage.Location = new System.Drawing.Point(951, 127);
            this.testlbl_percentage.Name = "testlbl_percentage";
            this.testlbl_percentage.Size = new System.Drawing.Size(238, 26);
            this.testlbl_percentage.TabIndex = 5;
            this.testlbl_percentage.Text = "Percentage gehaald: %";
            // 
            // testprb_gehaald
            // 
            this.testprb_gehaald.ForeColor = System.Drawing.Color.Lime;
            this.testprb_gehaald.Location = new System.Drawing.Point(100, 156);
            this.testprb_gehaald.Name = "testprb_gehaald";
            this.testprb_gehaald.Size = new System.Drawing.Size(1089, 23);
            this.testprb_gehaald.TabIndex = 6;
            this.testprb_gehaald.Value = 80;
            // 
            // lbl_gemiddelde
            // 
            this.lbl_gemiddelde.AutoSize = true;
            this.lbl_gemiddelde.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_gemiddelde.Location = new System.Drawing.Point(95, 204);
            this.lbl_gemiddelde.Name = "lbl_gemiddelde";
            this.lbl_gemiddelde.Size = new System.Drawing.Size(136, 26);
            this.lbl_gemiddelde.TabIndex = 7;
            this.lbl_gemiddelde.Text = "Gemiddelde:";
            // 
            // testlbl_toetsType
            // 
            this.testlbl_toetsType.AutoSize = true;
            this.testlbl_toetsType.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.testlbl_toetsType.Location = new System.Drawing.Point(448, 204);
            this.testlbl_toetsType.Name = "testlbl_toetsType";
            this.testlbl_toetsType.Size = new System.Drawing.Size(112, 26);
            this.testlbl_toetsType.TabIndex = 8;
            this.testlbl_toetsType.Text = "Toetstype:";
            // 
            // testlbl_afname
            // 
            this.testlbl_afname.AutoSize = true;
            this.testlbl_afname.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.testlbl_afname.Location = new System.Drawing.Point(821, 204);
            this.testlbl_afname.Name = "testlbl_afname";
            this.testlbl_afname.Size = new System.Drawing.Size(94, 26);
            this.testlbl_afname.TabIndex = 9;
            this.testlbl_afname.Text = "Afname:";
            // 
            // dgv_toets
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.NullValue = null;
            this.dgv_toets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_toets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_toets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_toets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Leerlingnr,
            this.naam,
            this.Cijfer});
            this.dgv_toets.Location = new System.Drawing.Point(100, 246);
            this.dgv_toets.Name = "dgv_toets";
            this.dgv_toets.Size = new System.Drawing.Size(1089, 454);
            this.dgv_toets.TabIndex = 0;
            this.dgv_toets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Leerlingnr
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Leerlingnr.DefaultCellStyle = dataGridViewCellStyle2;
            this.Leerlingnr.HeaderText = "Leerlingnr.";
            this.Leerlingnr.Name = "Leerlingnr";
            // 
            // naam
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.naam.DefaultCellStyle = dataGridViewCellStyle3;
            this.naam.HeaderText = "Naam";
            this.naam.Name = "naam";
            // 
            // Cijfer
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Cijfer.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cijfer.HeaderText = "Cijfer";
            this.Cijfer.Name = "Cijfer";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.dgv_toets);
            this.Controls.Add(this.testlbl_afname);
            this.Controls.Add(this.testlbl_toetsType);
            this.Controls.Add(this.lbl_gemiddelde);
            this.Controls.Add(this.testprb_gehaald);
            this.Controls.Add(this.testlbl_percentage);
            this.Controls.Add(this.testlbl_aantalonvoldoendes);
            this.Controls.Add(this.testlbl_aantalvoldoendes);
            this.Controls.Add(this.testlbl_toetsnaam);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.testbtn_zoek);
            this.Name = "TestForm";
            this.Text = "TestForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_toets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testbtn_zoek;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label testlbl_toetsnaam;
        private System.Windows.Forms.Label testlbl_aantalvoldoendes;
        private System.Windows.Forms.Label testlbl_aantalonvoldoendes;
        private System.Windows.Forms.Label testlbl_percentage;
        private System.Windows.Forms.ProgressBar testprb_gehaald;
        private System.Windows.Forms.Label lbl_gemiddelde;
        private System.Windows.Forms.Label testlbl_toetsType;
        private System.Windows.Forms.Label testlbl_afname;
        private System.Windows.Forms.DataGridView dgv_toets;
        private System.Windows.Forms.DataGridViewTextBoxColumn Leerlingnr;
        private System.Windows.Forms.DataGridViewTextBoxColumn naam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijfer;
    }
}