namespace DVLD.Peoples.Users
{
    partial class AllUsersList
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCountRecords = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbFilterBy = new System.Windows.Forms.ComboBox();
            this.cmbisactive = new System.Windows.Forms.ComboBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmsUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePasswordtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmsUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(437, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage Users";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUsers.ColumnHeadersHeight = 29;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsers.ContextMenuStrip = this.cmsUsers;
            this.dgvUsers.GridColor = System.Drawing.Color.Black;
            this.dgvUsers.Location = new System.Drawing.Point(43, 324);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.Size = new System.Drawing.Size(981, 382);
            this.dgvUsers.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 724);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "record =>";
            // 
            // lblCountRecords
            // 
            this.lblCountRecords.AutoSize = true;
            this.lblCountRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountRecords.Location = new System.Drawing.Point(169, 724);
            this.lblCountRecords.Name = "lblCountRecords";
            this.lblCountRecords.Size = new System.Drawing.Size(27, 29);
            this.lblCountRecords.TabIndex = 10;
            this.lblCountRecords.Text = "1";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(390, 295);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(256, 24);
            this.txtFilterValue.TabIndex = 14;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Order By : ";
            // 
            // CmbFilterBy
            // 
            this.CmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFilterBy.FormattingEnabled = true;
            this.CmbFilterBy.Items.AddRange(new object[] {
            "None",
            "User ID",
            "Person ID",
            "Full Name",
            "User Name",
            "Is Active"});
            this.CmbFilterBy.Location = new System.Drawing.Point(170, 294);
            this.CmbFilterBy.Name = "CmbFilterBy";
            this.CmbFilterBy.Size = new System.Drawing.Size(201, 24);
            this.CmbFilterBy.TabIndex = 12;
            this.CmbFilterBy.SelectedIndexChanged += new System.EventHandler(this.CmbFilterBy_SelectedIndexChanged);
            // 
            // cmbisactive
            // 
            this.cmbisactive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbisactive.FormattingEnabled = true;
            this.cmbisactive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cmbisactive.Location = new System.Drawing.Point(390, 294);
            this.cmbisactive.Name = "cmbisactive";
            this.cmbisactive.Size = new System.Drawing.Size(121, 24);
            this.cmbisactive.TabIndex = 104;
            this.cmbisactive.Visible = false;
            this.cmbisactive.SelectedIndexChanged += new System.EventHandler(this.cmbisactive_SelectedIndexChanged);
            // 
            // BtnClose
            // 
            this.BtnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.BtnClose.Location = new System.Drawing.Point(952, 717);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(72, 36);
            this.BtnClose.TabIndex = 16;
            this.BtnClose.UseVisualStyleBackColor = true;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btnAddUser.Image = global::DVLD.Properties.Resources.Add_Person_40;
            this.btnAddUser.Location = new System.Drawing.Point(933, 235);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(91, 79);
            this.btnAddUser.TabIndex = 15;
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Users_2_400;
            this.pictureBox1.Location = new System.Drawing.Point(446, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 214);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cmsUsers
            // 
            this.cmsUsers.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.ChangePasswordtoolStripMenuItem,
            this.toolStripSeparator4,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.cmsUsers.Name = "contextMenuStrip1";
            this.cmsUsers.Size = new System.Drawing.Size(227, 310);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.showDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.showDetailsToolStripMenuItem.Text = "&Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(223, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::DVLD.Properties.Resources.Add_New_User_32;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(226, 38);
            this.toolStripMenuItem1.Text = "Add &New User";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_32;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLD.Properties.Resources.Delete_32;
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.deleteToolStripMenuItem.Text = "&Delete";
            // 
            // ChangePasswordtoolStripMenuItem
            // 
            this.ChangePasswordtoolStripMenuItem.Image = global::DVLD.Properties.Resources.Password_32;
            this.ChangePasswordtoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ChangePasswordtoolStripMenuItem.Name = "ChangePasswordtoolStripMenuItem";
            this.ChangePasswordtoolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.ChangePasswordtoolStripMenuItem.Text = "Change &Password";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(223, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::DVLD.Properties.Resources.send_email_32;
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(226, 38);
            this.toolStripMenuItem2.Text = "Send E&mail";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::DVLD.Properties.Resources.call_32;
            this.toolStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(226, 38);
            this.toolStripMenuItem3.Text = "Phone &Call";
            // 
            // AllUsersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 772);
            this.Controls.Add(this.cmbisactive);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCountRecords);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AllUsersList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AllUsersList";
            this.Load += new System.EventHandler(this.AllUsersList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmsUsers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCountRecords;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbFilterBy;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.ComboBox cmbisactive;
        private System.Windows.Forms.ContextMenuStrip cmsUsers;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangePasswordtoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}