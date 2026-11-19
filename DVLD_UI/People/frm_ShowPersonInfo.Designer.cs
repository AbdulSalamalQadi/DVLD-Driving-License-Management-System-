namespace DVLD_UI
{
    partial class frm_ShowPersonInfo
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
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.uct_CardPersonInfo = new DVLD_UI.Uct_PersonInfo();
            this.lbAddnewPerson = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.guna2ImageButton7 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 30;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.ControlBoxStyle = Guna.UI2.WinForms.Enums.ControlBoxStyle.Custom;
            this.guna2ControlBox1.CustomIconSize = 15F;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.guna2ControlBox1.ForeColor = System.Drawing.Color.Silver;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1088, 9);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(51, 38);
            this.guna2ControlBox1.TabIndex = 8;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click_1);
            // 
            // uct_CardPersonInfo
            // 
            this.uct_CardPersonInfo.BackColor = System.Drawing.Color.Transparent;
            this.uct_CardPersonInfo.Location = new System.Drawing.Point(4, 161);
            this.uct_CardPersonInfo.Name = "uct_CardPersonInfo";
            this.uct_CardPersonInfo.Size = new System.Drawing.Size(1147, 404);
            this.uct_CardPersonInfo.TabIndex = 9;
            // 
            // lbAddnewPerson
            // 
            this.lbAddnewPerson.AutoSize = true;
            this.lbAddnewPerson.BackColor = System.Drawing.Color.Transparent;
            this.lbAddnewPerson.Font = new System.Drawing.Font("MV Boli", 25F, System.Drawing.FontStyle.Bold);
            this.lbAddnewPerson.ForeColor = System.Drawing.Color.Blue;
            this.lbAddnewPerson.Location = new System.Drawing.Point(354, 58);
            this.lbAddnewPerson.Name = "lbAddnewPerson";
            this.lbAddnewPerson.Size = new System.Drawing.Size(494, 65);
            this.lbAddnewPerson.TabIndex = 10;
            this.lbAddnewPerson.Text = "Person Information";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("MV Boli", 10F);
            this.lbTitle.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTitle.Location = new System.Drawing.Point(54, 12);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(177, 26);
            this.lbTitle.TabIndex = 44;
            this.lbTitle.Text = "Person info Form";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // guna2ImageButton7
            // 
            this.guna2ImageButton7.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton7.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2ImageButton7.Image = global::DVLD_UI.Properties.Resources.icons8_communicate_50;
            this.guna2ImageButton7.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton7.ImageRotate = 0F;
            this.guna2ImageButton7.ImageSize = new System.Drawing.Size(25, 25);
            this.guna2ImageButton7.Location = new System.Drawing.Point(12, 12);
            this.guna2ImageButton7.Name = "guna2ImageButton7";
            this.guna2ImageButton7.PressedState.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2ImageButton7.Size = new System.Drawing.Size(45, 26);
            this.guna2ImageButton7.TabIndex = 52;
            // 
            // frm_ShowPersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1162, 573);
            this.Controls.Add(this.guna2ImageButton7);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbAddnewPerson);
            this.Controls.Add(this.uct_CardPersonInfo);
            this.Controls.Add(this.guna2ControlBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_ShowPersonInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Liecens2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_ShowPersonInfo_FormClosed);
            this.Load += new System.EventHandler(this.frm_Liecens2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Uct_PersonInfo uct_CardPersonInfo;
        private System.Windows.Forms.Label lbAddnewPerson;
        private System.Windows.Forms.Label lbTitle;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton7;
    }
}