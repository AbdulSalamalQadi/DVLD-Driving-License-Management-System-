using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using Guna.UI2.WinForms;

namespace DVLD_UI
{
    public partial class frm_MainMenue : Form
    {

        uct_Applications uct_Applications;
        uct_ManagePeople uct_ManagePeole;
        Guna2Panel _panlApplication;
        public frm_MainMenue()
        {
            InitializeComponent();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            frm_ShowPersonInfo frm = new frm_ShowPersonInfo();

           // frm.DataBack += GetDataFromlicensefrom;
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
        private void GetDataFromlicensefrom(object sendrer,string username,int paserwod)
        {
          //  guna2TextBox1.Text=username;
            //guna2TextBox2.Text = paserwod.ToString();
        }

        private void bt_Applications_Click(object sender, EventArgs e)
        {
            if (!pnlContainerMain.Controls.Contains(pnlApplications) ||pnlContainerMain.Controls.Count==0)
            {
                pnlContainerMain.Controls.Clear();

                _panlApplication = pnlApplications;
                _panlApplication.Dock = DockStyle.Fill;
                _panlApplication.Visible=true;
                _panlApplication.Show();
                pnlContainerMain.Controls.Add(_panlApplication);
            }

        }

        private void bt_People_Click(object sender, EventArgs e)
        {
            if (!pnlContainerMain.Controls.Contains(uct_ManagePeole) || pnlContainerMain.Controls.Count == 0)
            {
                uct_ManagePeole = new uct_ManagePeople();
                uct_ManagePeole.Dock = DockStyle.Fill;
                pnlContainerMain.Controls.Clear();
                pnlContainerMain.Controls.Add(uct_ManagePeole);
            }
        }

        private void frm_MainMenue_Load(object sender, EventArgs e)
        {
            pnlContainerMain.Controls.Clear();
            pnlApplications.Hide();
        }
            Form ShowPersonPanl = new frm_ShowPersonInfo(1);

        private void testsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach(Form form in pnlShowAppliction.Controls)
            //{
            //    form.Close();
            //}
            //ShowPersonPanl.Dock = DockStyle.Fill;
            // ShowPersonPanl.Visible=true;
            
            ShowPersonPanl.ShowDialog();
           // ShowPersonPanl.BringToFront();
            //pnlShowAppliction.Controls.Add(ShowPersonPanl);


        }
    }
}
