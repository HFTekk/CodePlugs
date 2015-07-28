namespace NetworkGoS
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
            this.components = new System.ComponentModel.Container();
            this.lbl_GoS = new System.Windows.Forms.Label();
            this.tmr_updateGoS = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_test = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_GoS
            // 
            this.lbl_GoS.AutoSize = true;
            this.lbl_GoS.Font = new System.Drawing.Font("Courier New", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GoS.Location = new System.Drawing.Point(307, 153);
            this.lbl_GoS.Name = "lbl_GoS";
            this.lbl_GoS.Size = new System.Drawing.Size(337, 110);
            this.lbl_GoS.TabIndex = 0;
            this.lbl_GoS.Text = "0.010";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(354, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Grade of Service:";
            // 
            // lbl_test
            // 
            this.lbl_test.AutoSize = true;
            this.lbl_test.Location = new System.Drawing.Point(38, 13);
            this.lbl_test.Name = "lbl_test";
            this.lbl_test.Size = new System.Drawing.Size(35, 13);
            this.lbl_test.TabIndex = 2;
            this.lbl_test.Text = "label2";
            this.lbl_test.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 420);
            this.Controls.Add(this.lbl_test);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_GoS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Network Grade of Service";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_GoS;
        private System.Windows.Forms.Timer tmr_updateGoS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_test;
    }
}

