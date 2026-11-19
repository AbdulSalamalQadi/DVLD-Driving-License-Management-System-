using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class frm_ShowPersonInfo : Form
    {
        public delegate void DataBackEventHandler();
        public event DataBackEventHandler DataBackForRefersh;
        int PersonID = -1;
        //public delegate void DataBackEventHandler(object Sender, string Username, int password);

        //public event DataBackEventHandler DataBack;
        public frm_ShowPersonInfo()
        {
            InitializeComponent();
        }
        public frm_ShowPersonInfo(int ID)
        {
            InitializeComponent();
            PersonID= ID;
        }
      

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show(testUsercontrol1.TextboxMessge);
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
           // int pasew =int.Parse( guna2TextBox2.Text);
           // DataBack?.Invoke(this,guna2TextBox1.Text,pasew);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frm_Liecens2_Load(object sender, EventArgs e)
        {
            if (PersonID > 0)
            {
              uct_CardPersonInfo.LoadPersonInfo(PersonID);
               
                    return;
            }
                    MessageBox.Show($"Person with {PersonID} is not found ", " Can`t Find", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
        }

        private void guna2ControlBox1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void frm_ShowPersonInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (uct_CardPersonInfo.IsUpDatePersonFromPersonCard)
            {
                DataBackForRefersh?.Invoke();
            }
        }
    }
}
