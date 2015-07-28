namespace AntennaCalculator
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCombinerIL = new System.Windows.Forms.TextBox();
            this.txtPolyphaserIL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLineLoss = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLineLength = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAntennaGain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtERP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rbCombinerIL = new System.Windows.Forms.RadioButton();
            this.rbPolyphaserIL = new System.Windows.Forms.RadioButton();
            this.rbLineLoss = new System.Windows.Forms.RadioButton();
            this.rbLineLength = new System.Windows.Forms.RadioButton();
            this.rbAntennaGain = new System.Windows.Forms.RadioButton();
            this.rbERP = new System.Windows.Forms.RadioButton();
            this.gbStraightCalc = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbLineType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTXPower = new System.Windows.Forms.TextBox();
            this.rbTXPower = new System.Windows.Forms.RadioButton();
            this.btnCalc = new System.Windows.Forms.Button();
            this.gbStraightCalc.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Combiner I.L. (dB)";
            // 
            // txtCombinerIL
            // 
            this.txtCombinerIL.Location = new System.Drawing.Point(120, 44);
            this.txtCombinerIL.Name = "txtCombinerIL";
            this.txtCombinerIL.Size = new System.Drawing.Size(100, 20);
            this.txtCombinerIL.TabIndex = 3;
            this.txtCombinerIL.TextChanged += new System.EventHandler(this.txtBoxes_TextChanged);
            // 
            // txtPolyphaserIL
            // 
            this.txtPolyphaserIL.Location = new System.Drawing.Point(120, 69);
            this.txtPolyphaserIL.Name = "txtPolyphaserIL";
            this.txtPolyphaserIL.Size = new System.Drawing.Size(100, 20);
            this.txtPolyphaserIL.TabIndex = 5;
            this.txtPolyphaserIL.TextChanged += new System.EventHandler(this.txtBoxes_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Polyphaser I.L. (dB)";
            // 
            // txtLineLoss
            // 
            this.txtLineLoss.Location = new System.Drawing.Point(120, 94);
            this.txtLineLoss.Name = "txtLineLoss";
            this.txtLineLoss.Size = new System.Drawing.Size(100, 20);
            this.txtLineLoss.TabIndex = 7;
            this.txtLineLoss.TextChanged += new System.EventHandler(this.txtBoxes_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Line Loss (dB/100m):";
            // 
            // txtLineLength
            // 
            this.txtLineLength.Location = new System.Drawing.Point(120, 119);
            this.txtLineLength.Name = "txtLineLength";
            this.txtLineLength.Size = new System.Drawing.Size(100, 20);
            this.txtLineLength.TabIndex = 9;
            this.txtLineLength.TextChanged += new System.EventHandler(this.txtBoxes_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Line Length (m):";
            // 
            // txtAntennaGain
            // 
            this.txtAntennaGain.Location = new System.Drawing.Point(120, 144);
            this.txtAntennaGain.Name = "txtAntennaGain";
            this.txtAntennaGain.Size = new System.Drawing.Size(100, 20);
            this.txtAntennaGain.TabIndex = 11;
            this.txtAntennaGain.TextChanged += new System.EventHandler(this.txtBoxes_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Antenna gain (dBd):";
            // 
            // txtERP
            // 
            this.txtERP.Location = new System.Drawing.Point(120, 169);
            this.txtERP.Name = "txtERP";
            this.txtERP.Size = new System.Drawing.Size(100, 20);
            this.txtERP.TabIndex = 13;
            this.txtERP.TextChanged += new System.EventHandler(this.txtBoxes_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "ERP (dBW):";
            // 
            // rbCombinerIL
            // 
            this.rbCombinerIL.AutoSize = true;
            this.rbCombinerIL.Enabled = false;
            this.rbCombinerIL.Location = new System.Drawing.Point(226, 45);
            this.rbCombinerIL.Name = "rbCombinerIL";
            this.rbCombinerIL.Size = new System.Drawing.Size(14, 13);
            this.rbCombinerIL.TabIndex = 4;
            this.rbCombinerIL.TabStop = true;
            this.rbCombinerIL.UseVisualStyleBackColor = true;
            this.rbCombinerIL.Visible = false;
            this.rbCombinerIL.CheckedChanged += new System.EventHandler(this.rbCombinerIL_CheckedChanged);
            // 
            // rbPolyphaserIL
            // 
            this.rbPolyphaserIL.AutoSize = true;
            this.rbPolyphaserIL.Enabled = false;
            this.rbPolyphaserIL.Location = new System.Drawing.Point(226, 70);
            this.rbPolyphaserIL.Name = "rbPolyphaserIL";
            this.rbPolyphaserIL.Size = new System.Drawing.Size(14, 13);
            this.rbPolyphaserIL.TabIndex = 6;
            this.rbPolyphaserIL.TabStop = true;
            this.rbPolyphaserIL.UseVisualStyleBackColor = true;
            this.rbPolyphaserIL.Visible = false;
            this.rbPolyphaserIL.CheckedChanged += new System.EventHandler(this.rbPolyphaserIL_CheckedChanged);
            // 
            // rbLineLoss
            // 
            this.rbLineLoss.AutoSize = true;
            this.rbLineLoss.Location = new System.Drawing.Point(226, 95);
            this.rbLineLoss.Name = "rbLineLoss";
            this.rbLineLoss.Size = new System.Drawing.Size(14, 13);
            this.rbLineLoss.TabIndex = 8;
            this.rbLineLoss.TabStop = true;
            this.rbLineLoss.UseVisualStyleBackColor = true;
            this.rbLineLoss.CheckedChanged += new System.EventHandler(this.rbLineLoss_CheckedChanged);
            // 
            // rbLineLength
            // 
            this.rbLineLength.AutoSize = true;
            this.rbLineLength.Location = new System.Drawing.Point(226, 120);
            this.rbLineLength.Name = "rbLineLength";
            this.rbLineLength.Size = new System.Drawing.Size(14, 13);
            this.rbLineLength.TabIndex = 10;
            this.rbLineLength.TabStop = true;
            this.rbLineLength.UseVisualStyleBackColor = true;
            this.rbLineLength.CheckedChanged += new System.EventHandler(this.rbLineLength_CheckedChanged);
            // 
            // rbAntennaGain
            // 
            this.rbAntennaGain.AutoSize = true;
            this.rbAntennaGain.Cursor = System.Windows.Forms.Cursors.Default;
            this.rbAntennaGain.Location = new System.Drawing.Point(226, 145);
            this.rbAntennaGain.Name = "rbAntennaGain";
            this.rbAntennaGain.Size = new System.Drawing.Size(14, 13);
            this.rbAntennaGain.TabIndex = 12;
            this.rbAntennaGain.TabStop = true;
            this.rbAntennaGain.UseVisualStyleBackColor = true;
            this.rbAntennaGain.CheckedChanged += new System.EventHandler(this.rbAntennaGain_CheckedChanged);
            // 
            // rbERP
            // 
            this.rbERP.AutoSize = true;
            this.rbERP.Location = new System.Drawing.Point(226, 170);
            this.rbERP.Name = "rbERP";
            this.rbERP.Size = new System.Drawing.Size(14, 13);
            this.rbERP.TabIndex = 14;
            this.rbERP.TabStop = true;
            this.rbERP.UseVisualStyleBackColor = true;
            this.rbERP.CheckedChanged += new System.EventHandler(this.rbERP_CheckedChanged);
            // 
            // gbStraightCalc
            // 
            this.gbStraightCalc.Controls.Add(this.label9);
            this.gbStraightCalc.Controls.Add(this.txtFrequency);
            this.gbStraightCalc.Controls.Add(this.label8);
            this.gbStraightCalc.Controls.Add(this.cbLineType);
            this.gbStraightCalc.Controls.Add(this.label7);
            this.gbStraightCalc.Controls.Add(this.txtTXPower);
            this.gbStraightCalc.Controls.Add(this.rbTXPower);
            this.gbStraightCalc.Controls.Add(this.btnCalc);
            this.gbStraightCalc.Controls.Add(this.label1);
            this.gbStraightCalc.Controls.Add(this.rbERP);
            this.gbStraightCalc.Controls.Add(this.txtCombinerIL);
            this.gbStraightCalc.Controls.Add(this.rbAntennaGain);
            this.gbStraightCalc.Controls.Add(this.label2);
            this.gbStraightCalc.Controls.Add(this.rbLineLength);
            this.gbStraightCalc.Controls.Add(this.txtPolyphaserIL);
            this.gbStraightCalc.Controls.Add(this.rbLineLoss);
            this.gbStraightCalc.Controls.Add(this.label3);
            this.gbStraightCalc.Controls.Add(this.rbPolyphaserIL);
            this.gbStraightCalc.Controls.Add(this.txtLineLoss);
            this.gbStraightCalc.Controls.Add(this.rbCombinerIL);
            this.gbStraightCalc.Controls.Add(this.label4);
            this.gbStraightCalc.Controls.Add(this.txtERP);
            this.gbStraightCalc.Controls.Add(this.txtLineLength);
            this.gbStraightCalc.Controls.Add(this.label6);
            this.gbStraightCalc.Controls.Add(this.label5);
            this.gbStraightCalc.Controls.Add(this.txtAntennaGain);
            this.gbStraightCalc.Location = new System.Drawing.Point(12, 12);
            this.gbStraightCalc.Name = "gbStraightCalc";
            this.gbStraightCalc.Size = new System.Drawing.Size(441, 235);
            this.gbStraightCalc.TabIndex = 18;
            this.gbStraightCalc.TabStop = false;
            this.gbStraightCalc.Text = "Straight Calc";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(344, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Frequency:";
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(347, 94);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(74, 20);
            this.txtFrequency.TabIndex = 22;
            this.txtFrequency.TextChanged += new System.EventHandler(this.txtFrequency_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(256, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Line Type:";
            // 
            // cbLineType
            // 
            this.cbLineType.FormattingEnabled = true;
            this.cbLineType.Location = new System.Drawing.Point(256, 94);
            this.cbLineType.Name = "cbLineType";
            this.cbLineType.Size = new System.Drawing.Size(85, 21);
            this.cbLineType.TabIndex = 20;
            this.cbLineType.SelectedIndexChanged += new System.EventHandler(this.cbLineType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "TX Power (W)";
            // 
            // txtTXPower
            // 
            this.txtTXPower.Location = new System.Drawing.Point(120, 18);
            this.txtTXPower.Name = "txtTXPower";
            this.txtTXPower.Size = new System.Drawing.Size(100, 20);
            this.txtTXPower.TabIndex = 1;
            this.txtTXPower.TextChanged += new System.EventHandler(this.txtBoxes_TextChanged);
            // 
            // rbTXPower
            // 
            this.rbTXPower.AutoSize = true;
            this.rbTXPower.Location = new System.Drawing.Point(226, 19);
            this.rbTXPower.Name = "rbTXPower";
            this.rbTXPower.Size = new System.Drawing.Size(14, 13);
            this.rbTXPower.TabIndex = 2;
            this.rbTXPower.TabStop = true;
            this.rbTXPower.UseVisualStyleBackColor = true;
            this.rbTXPower.CheckedChanged += new System.EventHandler(this.rbTXPower_CheckedChanged);
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(120, 195);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 15;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 552);
            this.Controls.Add(this.gbStraightCalc);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbStraightCalc.ResumeLayout(false);
            this.gbStraightCalc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCombinerIL;
        private System.Windows.Forms.TextBox txtPolyphaserIL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLineLoss;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLineLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAntennaGain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtERP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbCombinerIL;
        private System.Windows.Forms.RadioButton rbPolyphaserIL;
        private System.Windows.Forms.RadioButton rbLineLoss;
        private System.Windows.Forms.RadioButton rbLineLength;
        private System.Windows.Forms.RadioButton rbAntennaGain;
        private System.Windows.Forms.RadioButton rbERP;
        private System.Windows.Forms.GroupBox gbStraightCalc;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTXPower;
        private System.Windows.Forms.RadioButton rbTXPower;
        private System.Windows.Forms.ComboBox cbLineType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.Label label8;
    }
}

