namespace DVLD_UI
{
    partial class uctrl_PersonCardWithFilter
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
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.pcb_personSearch = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pcb_AddnewPerson = new Guna.UI2.WinForms.Guna2PictureBox();
            this.CmbFindPerson = new System.Windows.Forms.ComboBox();
            this.txbFilter = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbFilter = new System.Windows.Forms.Label();
            this.lbPersonInfo = new System.Windows.Forms.Label();
            this.uctPersonCardInfo = new DVLD_UI.Uct_PersonInfo();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_personSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_AddnewPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilter.BorderRadius = 27;
            this.pnlFilter.Controls.Add(this.pcb_personSearch);
            this.pnlFilter.Controls.Add(this.pcb_AddnewPerson);
            this.pnlFilter.Controls.Add(this.CmbFindPerson);
            this.pnlFilter.Controls.Add(this.txbFilter);
            this.pnlFilter.Controls.Add(this.lbFilter);
            this.pnlFilter.Controls.Add(this.lbPersonInfo);
            this.pnlFilter.FillColor = System.Drawing.Color.White;
            this.pnlFilter.Location = new System.Drawing.Point(5, 3);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.ShadowDecoration.BorderRadius = 38;
            this.pnlFilter.ShadowDecoration.Depth = 10;
            this.pnlFilter.ShadowDecoration.Enabled = true;
            this.pnlFilter.Size = new System.Drawing.Size(1146, 97);
            this.pnlFilter.TabIndex = 1;
            this.pnlFilter.UseTransparentBackground = true;
            // 
            // pcb_personSearch
            // 
            this.pcb_personSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcb_personSearch.Image = global::DVLD_UI.Properties.Resources.icons8_search_50;
            this.pcb_personSearch.ImageRotate = 0F;
            this.pcb_personSearch.InitialImage = null;
            this.pcb_personSearch.Location = new System.Drawing.Point(763, 26);
            this.pcb_personSearch.Name = "pcb_personSearch";
            this.pcb_personSearch.Size = new System.Drawing.Size(46, 44);
            this.pcb_personSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb_personSearch.TabIndex = 55;
            this.pcb_personSearch.TabStop = false;
            this.pcb_personSearch.Click += new System.EventHandler(this.pcb_personSearch_Click);
            // 
            // pcb_AddnewPerson
            // 
            this.pcb_AddnewPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcb_AddnewPerson.Image = global::DVLD_UI.Properties.Resources.icons8_add_user_male_50;
            this.pcb_AddnewPerson.ImageRotate = 0F;
            this.pcb_AddnewPerson.InitialImage = null;
            this.pcb_AddnewPerson.Location = new System.Drawing.Point(837, 26);
            this.pcb_AddnewPerson.Name = "pcb_AddnewPerson";
            this.pcb_AddnewPerson.Size = new System.Drawing.Size(46, 44);
            this.pcb_AddnewPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcb_AddnewPerson.TabIndex = 33;
            this.pcb_AddnewPerson.TabStop = false;
            this.pcb_AddnewPerson.Click += new System.EventHandler(this.pcb_AddnewPerson_Click);
            // 
            // CmbFindPerson
            // 
            this.CmbFindPerson.FormattingEnabled = true;
            this.CmbFindPerson.Items.AddRange(new object[] {
            "Person ID",
            "National No"});
            this.CmbFindPerson.Location = new System.Drawing.Point(225, 39);
            this.CmbFindPerson.Name = "CmbFindPerson";
            this.CmbFindPerson.Size = new System.Drawing.Size(217, 27);
            this.CmbFindPerson.TabIndex = 54;
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
            this.txbFilter.IconRight = global::DVLD_UI.Properties.Resources.Filter_Icon;
            this.txbFilter.Location = new System.Drawing.Point(490, 39);
            this.txbFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbFilter.Name = "txbFilter";
            this.txbFilter.PlaceholderText = "";
            this.txbFilter.SelectedText = "";
            this.txbFilter.Size = new System.Drawing.Size(255, 31);
            this.txbFilter.TabIndex = 53;
            this.txbFilter.TextChanged += new System.EventHandler(this.txbFilter_TextChanged);
            // 
            // lbFilter
            // 
            this.lbFilter.AutoSize = true;
            this.lbFilter.BackColor = System.Drawing.Color.Transparent;
            this.lbFilter.Font = new System.Drawing.Font("MV Boli", 10F, System.Drawing.FontStyle.Bold);
            this.lbFilter.ForeColor = System.Drawing.Color.Black;
            this.lbFilter.Location = new System.Drawing.Point(96, 39);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(105, 26);
            this.lbFilter.TabIndex = 52;
            this.lbFilter.Text = "Filter By";
            // 
            // lbPersonInfo
            // 
            this.lbPersonInfo.AutoSize = true;
            this.lbPersonInfo.BackColor = System.Drawing.Color.Transparent;
            this.lbPersonInfo.Font = new System.Drawing.Font("Myanmar Text", 10F, System.Drawing.FontStyle.Bold);
            this.lbPersonInfo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbPersonInfo.Location = new System.Drawing.Point(26, 4);
            this.lbPersonInfo.Name = "lbPersonInfo";
            this.lbPersonInfo.Size = new System.Drawing.Size(64, 36);
            this.lbPersonInfo.TabIndex = 51;
            this.lbPersonInfo.Text = "Filter";
            // 
            // uctPersonCardInfo
            // 
            this.uctPersonCardInfo.BackColor = System.Drawing.Color.Transparent;
            this.uctPersonCardInfo.Location = new System.Drawing.Point(3, 114);
            this.uctPersonCardInfo.Name = "uctPersonCardInfo";
            this.uctPersonCardInfo.Size = new System.Drawing.Size(1158, 415);
            this.uctPersonCardInfo.TabIndex = 0;
            // 
            // uctrl_PersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.uctPersonCardInfo);
            this.Name = "uctrl_PersonCardWithFilter";
            this.Size = new System.Drawing.Size(1170, 541);
            this.Load += new System.EventHandler(this.uctrl_PersonCardWithFilter_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_personSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_AddnewPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Uct_PersonInfo uctPersonCardInfo;
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private System.Windows.Forms.Label lbPersonInfo;
        private System.Windows.Forms.ComboBox CmbFindPerson;
        private Guna.UI2.WinForms.Guna2TextBox txbFilter;
        private System.Windows.Forms.Label lbFilter;
        private Guna.UI2.WinForms.Guna2PictureBox pcb_personSearch;
        private Guna.UI2.WinForms.Guna2PictureBox pcb_AddnewPerson;
    }
}
