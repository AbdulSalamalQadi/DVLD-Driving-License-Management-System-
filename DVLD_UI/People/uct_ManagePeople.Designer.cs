namespace DVLD_UI
{
    partial class uct_ManagePeople
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.CmbFilterMode = new System.Windows.Forms.ComboBox();
            this.LbRowsCounts = new System.Windows.Forms.Label();
            this.ImgBtnAddNewPerson = new Guna.UI2.WinForms.Guna2ImageButton();
            this.txbFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbFilter = new System.Windows.Forms.Label();
            this.lbManagePeople = new System.Windows.Forms.Label();
            this.lbRecordsCounts = new System.Windows.Forms.Label();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvPeopelInfo = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ctxmstMangePeople = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phoneCallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeopelInfo)).BeginInit();
            this.ctxmstMangePeople.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.Controls.Add(this.CmbFilterMode);
            this.guna2Panel1.Controls.Add(this.LbRowsCounts);
            this.guna2Panel1.Controls.Add(this.ImgBtnAddNewPerson);
            this.guna2Panel1.Controls.Add(this.txbFilter);
            this.guna2Panel1.Controls.Add(this.lbFilter);
            this.guna2Panel1.Controls.Add(this.lbManagePeople);
            this.guna2Panel1.Controls.Add(this.lbRecordsCounts);
            this.guna2Panel1.Controls.Add(this.guna2GradientButton1);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Padding = new System.Windows.Forms.Padding(20);
            this.guna2Panel1.Size = new System.Drawing.Size(1600, 983);
            this.guna2Panel1.TabIndex = 0;
            // 
            // CmbFilterMode
            // 
            this.CmbFilterMode.FormattingEnabled = true;
            this.CmbFilterMode.Items.AddRange(new object[] {
            "Noun",
            "Person ID",
            "National No",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Country",
            "Email",
            "Phone"});
            this.CmbFilterMode.Location = new System.Drawing.Point(163, 272);
            this.CmbFilterMode.Name = "CmbFilterMode";
            this.CmbFilterMode.Size = new System.Drawing.Size(217, 27);
            this.CmbFilterMode.TabIndex = 32;
            this.CmbFilterMode.SelectedIndexChanged += new System.EventHandler(this.CmbFilterMode_SelectedIndexChanged_1);
            // 
            // LbRowsCounts
            // 
            this.LbRowsCounts.AutoSize = true;
            this.LbRowsCounts.BackColor = System.Drawing.Color.Transparent;
            this.LbRowsCounts.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Bold);
            this.LbRowsCounts.ForeColor = System.Drawing.Color.Red;
            this.LbRowsCounts.Location = new System.Drawing.Point(179, 943);
            this.LbRowsCounts.Name = "LbRowsCounts";
            this.LbRowsCounts.Size = new System.Drawing.Size(27, 26);
            this.LbRowsCounts.TabIndex = 31;
            this.LbRowsCounts.Text = "0";
            // 
            // ImgBtnAddNewPerson
            // 
            this.ImgBtnAddNewPerson.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ImgBtnAddNewPerson.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.ImgBtnAddNewPerson.Image = global::DVLD_UI.Properties.Resources.icons8_add_user_male_50;
            this.ImgBtnAddNewPerson.ImageOffset = new System.Drawing.Point(0, 0);
            this.ImgBtnAddNewPerson.ImageRotate = 0F;
            this.ImgBtnAddNewPerson.ImageSize = new System.Drawing.Size(50, 50);
            this.ImgBtnAddNewPerson.Location = new System.Drawing.Point(1471, 212);
            this.ImgBtnAddNewPerson.Name = "ImgBtnAddNewPerson";
            this.ImgBtnAddNewPerson.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ImgBtnAddNewPerson.Size = new System.Drawing.Size(96, 94);
            this.ImgBtnAddNewPerson.TabIndex = 30;
            this.ImgBtnAddNewPerson.Click += new System.EventHandler(this.ImgBtnAddNewPerson_Click);
            // 
            // txbFilter
            // 
            this.txbFilter.AutoRoundedCorners = true;
            this.txbFilter.BorderColor = System.Drawing.Color.SteelBlue;
            this.txbFilter.BorderRadius = 14;
            this.txbFilter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbFilter.DefaultText = "";
            this.txbFilter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txbFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txbFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbFilter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbFilter.FocusedState.BorderColor = System.Drawing.Color.Red;
            this.txbFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbFilter.ForeColor = System.Drawing.Color.Black;
            this.txbFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbFilter.IconRight = global::DVLD_UI.Properties.Resources.icons8_search_50;
            this.txbFilter.Location = new System.Drawing.Point(436, 270);
            this.txbFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbFilter.Name = "txbFilter";
            this.txbFilter.PlaceholderText = "";
            this.txbFilter.SelectedText = "";
            this.txbFilter.Size = new System.Drawing.Size(255, 30);
            this.txbFilter.TabIndex = 29;
            this.txbFilter.Visible = false;
            this.txbFilter.TextChanged += new System.EventHandler(this.txbFilter_TextChanged);
            this.txbFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbFilter_KeyPress);
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.BackColor = System.Drawing.Color.Transparent;
            this.lbFilter.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Bold);
            this.lbFilter.ForeColor = System.Drawing.Color.Black;
            this.lbFilter.Location = new System.Drawing.Point(35, 270);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(105, 26);
            this.lbFilter.TabIndex = 27;
            this.lbFilter.Text = "Filter By";
            // 
            // lbManagePeople
            // 
            this.lbManagePeople.AutoSize = true;
            this.lbManagePeople.BackColor = System.Drawing.Color.Transparent;
            this.lbManagePeople.Font = new System.Drawing.Font("MV Boli", 30F, System.Drawing.FontStyle.Bold);
            this.lbManagePeople.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbManagePeople.Image = global::DVLD_UI.Properties.Resources.icons8_administrator_male_501;
            this.lbManagePeople.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbManagePeople.Location = new System.Drawing.Point(540, 53);
            this.lbManagePeople.Name = "lbManagePeople";
            this.lbManagePeople.Size = new System.Drawing.Size(449, 158);
            this.lbManagePeople.TabIndex = 7;
            this.lbManagePeople.Text = "\r\nManage people";
            // 
            // lbRecordsCounts
            // 
            this.lbRecordsCounts.AutoSize = true;
            this.lbRecordsCounts.BackColor = System.Drawing.Color.Transparent;
            this.lbRecordsCounts.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Bold);
            this.lbRecordsCounts.ForeColor = System.Drawing.Color.Red;
            this.lbRecordsCounts.Location = new System.Drawing.Point(23, 943);
            this.lbRecordsCounts.Name = "lbRecordsCounts";
            this.lbRecordsCounts.Size = new System.Drawing.Size(158, 26);
            this.lbRecordsCounts.TabIndex = 26;
            this.lbRecordsCounts.Text = "# Records  : ";
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.BorderColor = System.Drawing.Color.Yellow;
            this.guna2GradientButton1.BorderRadius = 10;
            this.guna2GradientButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor = System.Drawing.Color.MidnightBlue;
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.Firebrick;
            this.guna2GradientButton1.FocusedColor = System.Drawing.Color.MidnightBlue;
            this.guna2GradientButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.Location = new System.Drawing.Point(1421, 930);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.PressedColor = System.Drawing.Color.Yellow;
            this.guna2GradientButton1.Size = new System.Drawing.Size(176, 39);
            this.guna2GradientButton1.TabIndex = 7;
            this.guna2GradientButton1.Text = "close";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel2.BorderRadius = 30;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.dgvPeopelInfo);
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(20, 327);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Padding = new System.Windows.Forms.Padding(20);
            this.guna2Panel2.Size = new System.Drawing.Size(1567, 588);
            this.guna2Panel2.TabIndex = 0;
            // 
            // dgvPeopelInfo
            // 
            this.dgvPeopelInfo.AllowUserToAddRows = false;
            this.dgvPeopelInfo.AllowUserToResizeColumns = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvPeopelInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPeopelInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPeopelInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPeopelInfo.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPeopelInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPeopelInfo.ColumnHeadersHeight = 30;
            this.dgvPeopelInfo.ContextMenuStrip = this.ctxmstMangePeople;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeopelInfo.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPeopelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeopelInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPeopelInfo.Location = new System.Drawing.Point(20, 20);
            this.dgvPeopelInfo.Name = "dgvPeopelInfo";
            this.dgvPeopelInfo.ReadOnly = true;
            this.dgvPeopelInfo.RowHeadersVisible = false;
            this.dgvPeopelInfo.RowHeadersWidth = 62;
            this.dgvPeopelInfo.RowTemplate.Height = 29;
            this.dgvPeopelInfo.Size = new System.Drawing.Size(1527, 548);
            this.dgvPeopelInfo.TabIndex = 0;
            this.dgvPeopelInfo.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPeopelInfo.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgvPeopelInfo.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPeopelInfo.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvPeopelInfo.ThemeStyle.ReadOnly = true;
            this.dgvPeopelInfo.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPeopelInfo.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgvPeopelInfo.ThemeStyle.RowsStyle.Height = 29;
            this.dgvPeopelInfo.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            this.dgvPeopelInfo.DoubleClick += new System.EventHandler(this.dgvPeopelInfo_DoubleClick);
            // 
            // ctxmstMangePeople
            // 
            this.ctxmstMangePeople.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ctxmstMangePeople.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator2,
            this.addNewPersonToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.sendEmailToolStripMenuItem,
            this.phoneCallToolStripMenuItem});
            this.ctxmstMangePeople.Name = "ctxmstMangePeople";
            this.ctxmstMangePeople.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.ctxmstMangePeople.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.ctxmstMangePeople.RenderStyle.ColorTable = null;
            this.ctxmstMangePeople.RenderStyle.RoundedEdges = true;
            this.ctxmstMangePeople.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.ctxmstMangePeople.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.ctxmstMangePeople.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.ctxmstMangePeople.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.ctxmstMangePeople.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.ctxmstMangePeople.Size = new System.Drawing.Size(235, 208);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(231, 6);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.icons8_resume_website_501;
            this.showDetailsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(234, 32);
            this.showDetailsToolStripMenuItem.Text = "  Show Details";
            this.showDetailsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showDetailsToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(231, 6);
            // 
            // addNewPersonToolStripMenuItem
            // 
            this.addNewPersonToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.icons8_add_user_male_50;
            this.addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            this.addNewPersonToolStripMenuItem.Size = new System.Drawing.Size(234, 32);
            this.addNewPersonToolStripMenuItem.Text = "  Add New Person";
            this.addNewPersonToolStripMenuItem.Click += new System.EventHandler(this.addNewPersonToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.icons8_synchronize_50;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(234, 32);
            this.editToolStripMenuItem.Text = "  Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.icons8_trash_500;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(234, 32);
            this.deleteToolStripMenuItem.Text = "  Delete ";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.icons8_gmail_48;
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(234, 32);
            this.sendEmailToolStripMenuItem.Text = "  Send Email";
            this.sendEmailToolStripMenuItem.Click += new System.EventHandler(this.sendEmailToolStripMenuItem_Click);
            // 
            // phoneCallToolStripMenuItem
            // 
            this.phoneCallToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.icons8_call_48;
            this.phoneCallToolStripMenuItem.Name = "phoneCallToolStripMenuItem";
            this.phoneCallToolStripMenuItem.Size = new System.Drawing.Size(234, 32);
            this.phoneCallToolStripMenuItem.Text = "  Phone Call";
            this.phoneCallToolStripMenuItem.Click += new System.EventHandler(this.phoneCallToolStripMenuItem_Click);
            // 
            // uct_ManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "uct_ManagePeople";
            this.Size = new System.Drawing.Size(1600, 983);
            this.Load += new System.EventHandler(this.uct_ManagePeople_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeopelInfo)).EndInit();
            this.ctxmstMangePeople.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private System.Windows.Forms.Label lbRecordsCounts;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPeopelInfo;
        private System.Windows.Forms.Label lbManagePeople;
        private System.Windows.Forms.Label lbFilter;
        private Guna.UI2.WinForms.Guna2TextBox txbFilter;
        private Guna.UI2.WinForms.Guna2ImageButton ImgBtnAddNewPerson;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip ctxmstMangePeople;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phoneCallToolStripMenuItem;
        private System.Windows.Forms.Label LbRowsCounts;
        private System.Windows.Forms.ComboBox CmbFilterMode;
    }
}
