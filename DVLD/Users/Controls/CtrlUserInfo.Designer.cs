namespace DVLD.Users.Controls
{
    partial class CtrlUserInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlDetails1 = new DVLD.Person.Controls.CtrlDetails();
            this.userControlFind1 = new DVLD.Users.Controls.UserControlFind();
            this.SuspendLayout();
            // 
            // ctrlDetails1
            // 
            this.ctrlDetails1.AutoSize = true;
            this.ctrlDetails1.Location = new System.Drawing.Point(8, 14);
            this.ctrlDetails1.Name = "ctrlDetails1";
            this.ctrlDetails1.Size = new System.Drawing.Size(889, 282);
            this.ctrlDetails1.TabIndex = 0;
            this.ctrlDetails1.Load += new System.EventHandler(this.ctrlDetails1_Load);
            // 
            // userControlFind1
            // 
            this.userControlFind1.Location = new System.Drawing.Point(8, 302);
            this.userControlFind1.Name = "userControlFind1";
            this.userControlFind1.Size = new System.Drawing.Size(894, 95);
            this.userControlFind1.TabIndex = 1;
            this.userControlFind1.Load += new System.EventHandler(this.userControlFind1_Load);
            // 
            // CtrlUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControlFind1);
            this.Controls.Add(this.ctrlDetails1);
            this.Name = "CtrlUserInfo";
            this.Size = new System.Drawing.Size(906, 406);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Person.Controls.CtrlDetails ctrlDetails1;
        private UserControlFind userControlFind1;
    }
}
