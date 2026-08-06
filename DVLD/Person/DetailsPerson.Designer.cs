namespace DVLD.Person
{
    partial class DetailsPerson
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
            this.ctrlDetails1 = new DVLD.Person.Controls.CtrlDetails();
            this.SuspendLayout();
            // 
            // ctrlDetails1
            // 
            this.ctrlDetails1.AutoSize = true;
            this.ctrlDetails1.Location = new System.Drawing.Point(12, 12);
            this.ctrlDetails1.Name = "ctrlDetails1";
            this.ctrlDetails1.Size = new System.Drawing.Size(889, 282);
            this.ctrlDetails1.TabIndex = 0;
            // 
            // DetailsPerson1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 311);
            this.Controls.Add(this.ctrlDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DetailsPerson1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetailsPerson1";
            this.Load += new System.EventHandler(this.DetailsPerson1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.CtrlDetails ctrlDetails1;
    }
}