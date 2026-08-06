namespace DVLD.Person
{
    partial class AllPeopleList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvPeoples = new System.Windows.Forms.DataGridView();
            this.cmsPeople = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phoneCallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbFilterBy = new System.Windows.Forms.ComboBox();
            this.lblCountRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPeoples)).BeginInit();
            this.cmsPeople.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvPeoples
            // 
            this.DgvPeoples.AllowUserToAddRows = false;
            this.DgvPeoples.AllowUserToDeleteRows = false;
            this.DgvPeoples.BackgroundColor = System.Drawing.Color.White;
            this.DgvPeoples.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPeoples.ContextMenuStrip = this.cmsPeople;
            this.DgvPeoples.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgvPeoples.Location = new System.Drawing.Point(12, 290);
            this.DgvPeoples.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DgvPeoples.MultiSelect = false;
            this.DgvPeoples.Name = "DgvPeoples";
            this.DgvPeoples.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPeoples.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvPeoples.RowHeadersWidth = 51;
            this.DgvPeoples.RowTemplate.Height = 24;
            this.DgvPeoples.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPeoples.Size = new System.Drawing.Size(1501, 384);
            this.DgvPeoples.TabIndex = 0;
            this.DgvPeoples.TabStop = false;
            //
            // cmsPeople
            // 
            this.cmsPeople.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsPeople.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuDetails,
            this.toolStripSeparator2,
            this.MenuAdd,
            this.MenuUpdate,
            this.MenuDelete,
            this.toolStripSeparator1,
            this.sendEmailToolStripMenuItem,
            this.phoneCallToolStripMenuItem});
            this.cmsPeople.Name = "contextMenuStrip1";
            this.cmsPeople.Size = new System.Drawing.Size(212, 292);
            // 
            // MenuDetails
            // 
            this.MenuDetails.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.MenuDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuDetails.Name = "MenuDetails";
            this.MenuDetails.Size = new System.Drawing.Size(211, 46);
            this.MenuDetails.Text = "&Show Details";
            this.MenuDetails.Click += new System.EventHandler(this.MenuDetails_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(208, 6);
            // 
            // MenuAdd
            // 
            this.MenuAdd.Image = global::DVLD.Properties.Resources.Add_Person_40;
            this.MenuAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuAdd.Name = "MenuAdd";
            this.MenuAdd.Size = new System.Drawing.Size(211, 46);
            this.MenuAdd.Text = "Add &New Person";
            this.MenuAdd.Click += new System.EventHandler(this.MenuAdd_Click);
            // 
            // MenuUpdate
            // 
            this.MenuUpdate.Image = global::DVLD.Properties.Resources.edit_32;
            this.MenuUpdate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuUpdate.Name = "MenuUpdate";
            this.MenuUpdate.Size = new System.Drawing.Size(211, 46);
            this.MenuUpdate.Text = "&Edit";
            this.MenuUpdate.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // MenuDelete
            // 
            this.MenuDelete.Image = global::DVLD.Properties.Resources.Delete_32;
            this.MenuDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MenuDelete.Name = "MenuDelete";
            this.MenuDelete.Size = new System.Drawing.Size(211, 46);
            this.MenuDelete.Text = "&Delete";
            this.MenuDelete.Click += new System.EventHandler(this.MenuDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.Image = global::DVLD.Properties.Resources.Email_32;
            this.sendEmailToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(211, 46);
            this.sendEmailToolStripMenuItem.Text = "Send E&mail";
            // 
            // phoneCallToolStripMenuItem
            // 
            this.phoneCallToolStripMenuItem.Image = global::DVLD.Properties.Resources.Phone_32;
            this.phoneCallToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.phoneCallToolStripMenuItem.Name = "phoneCallToolStripMenuItem";
            this.phoneCallToolStripMenuItem.Size = new System.Drawing.Size(211, 46);
            this.phoneCallToolStripMenuItem.Text = "Phone &Call";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(731, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Peoples";
            // 
            // CmbFilterBy
            // 
            this.CmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFilterBy.FormattingEnabled = true;
            this.CmbFilterBy.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "National No",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Nationality",
            "Gendor",
            "Phone",
            "Email"});
            this.CmbFilterBy.Location = new System.Drawing.Point(138, 258);
            this.CmbFilterBy.Name = "CmbFilterBy";
            this.CmbFilterBy.Size = new System.Drawing.Size(201, 24);
            this.CmbFilterBy.TabIndex = 4;
            this.CmbFilterBy.SelectedIndexChanged += new System.EventHandler(this.CmbFilterBy_SelectedIndexChanged);
            // 
            // lblCountRecords
            // 
            this.lblCountRecords.AutoSize = true;
            this.lblCountRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRecords.Location = new System.Drawing.Point(152, 683);
            this.lblCountRecords.Name = "lblCountRecords";
            this.lblCountRecords.Size = new System.Drawing.Size(27, 29);
            this.lblCountRecords.TabIndex = 5;
            this.lblCountRecords.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Order By : ";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(363, 261);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(256, 22);
            this.txtFilterValue.TabIndex = 8;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 683);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "record =>";
            // 
            // button2
            // 
            this.button2.Image = global::DVLD.Properties.Resources.Close_32;
            this.button2.Location = new System.Drawing.Point(1441, 683);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 36);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.People_400;
            this.pictureBox1.Location = new System.Drawing.Point(700, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btnAdd.Image = global::DVLD.Properties.Resources.Add_Person_40;
            this.btnAdd.Location = new System.Drawing.Point(1422, 204);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 79);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AllPeopleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1535, 766);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCountRecords);
            this.Controls.Add(this.CmbFilterBy);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.DgvPeoples);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AllPeopleList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AllPeapleList";
            this.Load += new System.EventHandler(this.AllPeopleList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPeoples)).EndInit();
            this.cmsPeople.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPeoples;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox CmbFilterBy;
        private System.Windows.Forms.Label lblCountRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip cmsPeople;
        private System.Windows.Forms.ToolStripMenuItem MenuDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuAdd;
        private System.Windows.Forms.ToolStripMenuItem MenuUpdate;
        private System.Windows.Forms.ToolStripMenuItem MenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phoneCallToolStripMenuItem;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label2;
    }
}