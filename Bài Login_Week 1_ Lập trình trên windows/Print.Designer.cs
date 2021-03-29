
namespace Bài_Login_Week_1__Lập_trình_trên_windows
{
    partial class Print
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCheck = new System.Windows.Forms.Button();
            this.rBAll = new System.Windows.Forms.RadioButton();
            this.rBMale = new System.Windows.Forms.RadioButton();
            this.rBFemale = new System.Windows.Forms.RadioButton();
            this.rBYes = new System.Windows.Forms.RadioButton();
            this.rBNo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dT1 = new System.Windows.Forms.DateTimePicker();
            this.dT2 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnPrinter = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rBFemale);
            this.panel1.Controls.Add(this.rBMale);
            this.panel1.Controls.Add(this.rBAll);
            this.panel1.Controls.Add(this.btnCheck);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 127);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dT2);
            this.panel2.Controls.Add(this.dT1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rBNo);
            this.panel2.Controls.Add(this.rBYes);
            this.panel2.Location = new System.Drawing.Point(231, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(494, 100);
            this.panel2.TabIndex = 1;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(813, 35);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(110, 40);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "CHECK";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // rBAll
            // 
            this.rBAll.AutoSize = true;
            this.rBAll.Location = new System.Drawing.Point(29, 14);
            this.rBAll.Name = "rBAll";
            this.rBAll.Size = new System.Drawing.Size(44, 21);
            this.rBAll.TabIndex = 3;
            this.rBAll.TabStop = true;
            this.rBAll.Text = "All";
            this.rBAll.UseVisualStyleBackColor = true;
            // 
            // rBMale
            // 
            this.rBMale.AutoSize = true;
            this.rBMale.Location = new System.Drawing.Point(29, 54);
            this.rBMale.Name = "rBMale";
            this.rBMale.Size = new System.Drawing.Size(59, 21);
            this.rBMale.TabIndex = 4;
            this.rBMale.TabStop = true;
            this.rBMale.Text = "Male";
            this.rBMale.UseVisualStyleBackColor = true;
            // 
            // rBFemale
            // 
            this.rBFemale.AutoSize = true;
            this.rBFemale.Location = new System.Drawing.Point(29, 93);
            this.rBFemale.Name = "rBFemale";
            this.rBFemale.Size = new System.Drawing.Size(75, 21);
            this.rBFemale.TabIndex = 5;
            this.rBFemale.TabStop = true;
            this.rBFemale.Text = "Female";
            this.rBFemale.UseVisualStyleBackColor = true;
            // 
            // rBYes
            // 
            this.rBYes.AutoSize = true;
            this.rBYes.Location = new System.Drawing.Point(235, 4);
            this.rBYes.Name = "rBYes";
            this.rBYes.Size = new System.Drawing.Size(56, 21);
            this.rBYes.TabIndex = 4;
            this.rBYes.TabStop = true;
            this.rBYes.Text = "YES";
            this.rBYes.UseVisualStyleBackColor = true;
            // 
            // rBNo
            // 
            this.rBNo.AutoSize = true;
            this.rBNo.Location = new System.Drawing.Point(308, 4);
            this.rBNo.Name = "rBNo";
            this.rBNo.Size = new System.Drawing.Size(50, 21);
            this.rBNo.TabIndex = 5;
            this.rBNo.TabStop = true;
            this.rBNo.Text = "NO";
            this.rBNo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Use Date Range";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "BirthDate Between";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "And";
            // 
            // dT1
            // 
            this.dT1.CustomFormat = "yyyy-MM-dd";
            this.dT1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dT1.Location = new System.Drawing.Point(204, 77);
            this.dT1.Name = "dT1";
            this.dT1.Size = new System.Drawing.Size(98, 22);
            this.dT1.TabIndex = 9;
            // 
            // dT2
            // 
            this.dT2.CustomFormat = "yyyy-MM-dd";
            this.dT2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dT2.Location = new System.Drawing.Point(372, 77);
            this.dT2.Name = "dT2";
            this.dT2.Size = new System.Drawing.Size(96, 22);
            this.dT2.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 159);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(955, 260);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(110, 468);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(202, 40);
            this.btnSaveAs.TabIndex = 3;
            this.btnSaveAs.Text = "SAVE TO TEXT FILE";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnPrinter
            // 
            this.btnPrinter.Location = new System.Drawing.Point(429, 468);
            this.btnPrinter.Name = "btnPrinter";
            this.btnPrinter.Size = new System.Drawing.Size(110, 40);
            this.btnPrinter.TabIndex = 4;
            this.btnPrinter.Text = "TO PRINTER";
            this.btnPrinter.UseVisualStyleBackColor = true;
            this.btnPrinter.Click += new System.EventHandler(this.btnPrinter_Click);
            // 
            // Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(976, 535);
            this.Controls.Add(this.btnPrinter);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "Print";
            this.Text = "Print";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rBFemale;
        private System.Windows.Forms.RadioButton rBMale;
        private System.Windows.Forms.RadioButton rBAll;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dT2;
        private System.Windows.Forms.DateTimePicker dT1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rBNo;
        private System.Windows.Forms.RadioButton rBYes;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnPrinter;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}