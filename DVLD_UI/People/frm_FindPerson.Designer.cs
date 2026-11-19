namespace DVLD_UI
{
    partial class frm_FindPerson
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbAddnewPerson = new System.Windows.Forms.Label();
            this.guna2ImageButton7 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.uctrl_PersonCardWithFilter1 = new DVLD_UI.uctrl_PersonCardWithFilter();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 35;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockForm = false;
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
            this.guna2ControlBox1.Location = new System.Drawing.Point(1111, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(40, 40);
            this.guna2ControlBox1.TabIndex = 9;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("MV Boli", 10F);
            this.lbTitle.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTitle.Location = new System.Drawing.Point(57, 12);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(180, 26);
            this.lbTitle.TabIndex = 54;
            this.lbTitle.Text = "Find Person Form";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbAddnewPerson
            // 
            this.lbAddnewPerson.AutoSize = true;
            this.lbAddnewPerson.BackColor = System.Drawing.Color.Transparent;
            this.lbAddnewPerson.Font = new System.Drawing.Font("MV Boli", 25F, System.Drawing.FontStyle.Bold);
            this.lbAddnewPerson.ForeColor = System.Drawing.Color.Blue;
            this.lbAddnewPerson.Location = new System.Drawing.Point(436, 52);
            this.lbAddnewPerson.Name = "lbAddnewPerson";
            this.lbAddnewPerson.Size = new System.Drawing.Size(313, 65);
            this.lbAddnewPerson.TabIndex = 53;
            this.lbAddnewPerson.Text = "Find Person";
            // 
            // guna2ImageButton7
            // 
            this.guna2ImageButton7.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton7.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2ImageButton7.Image = global::DVLD_UI.Properties.Resources.icons8_iphone_spinner_50;
            this.guna2ImageButton7.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton7.ImageRotate = 0F;
            this.guna2ImageButton7.ImageSize = new System.Drawing.Size(25, 25);
            this.guna2ImageButton7.Location = new System.Drawing.Point(15, 12);
            this.guna2ImageButton7.Name = "guna2ImageButton7";
            this.guna2ImageButton7.PressedState.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2ImageButton7.Size = new System.Drawing.Size(45, 26);
            this.guna2ImageButton7.TabIndex = 55;
            // 
            // uctrl_PersonCardWithFilter1
            // 
            this.uctrl_PersonCardWithFilter1.BackColor = System.Drawing.Color.Transparent;
            this.uctrl_PersonCardWithFilter1.Location = new System.Drawing.Point(15, 160);
            this.uctrl_PersonCardWithFilter1.Name = "uctrl_PersonCardWithFilter1";
            this.uctrl_PersonCardWithFilter1.Size = new System.Drawing.Size(1166, 545);
            this.uctrl_PersonCardWithFilter1.TabIndex = 56;
            // 
            // frm_FindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1193, 729);
            this.Controls.Add(this.uctrl_PersonCardWithFilter1);
            this.Controls.Add(this.guna2ImageButton7);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbAddnewPerson);
            this.Controls.Add(this.guna2ControlBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_FindPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_FindPerson";
            this.Load += new System.EventHandler(this.frm_FindPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton7;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbAddnewPerson;
        private uctrl_PersonCardWithFilter uctrl_PersonCardWithFilter1;
    }
}