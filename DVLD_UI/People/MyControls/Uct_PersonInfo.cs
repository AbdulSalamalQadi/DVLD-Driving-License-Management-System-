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
using System.Drawing;
using MyFileStorage;
using System.IO;

namespace DVLD_UI
{
    public partial class Uct_PersonInfo : UserControl
    {
        
        public Uct_PersonInfo()
        {
            InitializeComponent();
        }

       private bool _IsUpDatePersonFromPersonCard=false;

        public bool IsUpDatePersonFromPersonCard { 

            get { return _IsUpDatePersonFromPersonCard; } 
        }

         
        private int _PersonID;
       private clsPeople _CurrentPerson;

        public clsPeople Person
        {
            get { return _CurrentPerson; }
        }

        public int PersonID
        {
            get { return _PersonID; }
        }
       public void  LoadPersonInfo(int ID)

        {
          
            _CurrentPerson = clsPeople.Find(ID);
            if (_CurrentPerson == null)
            {
                RestPersonInfo();
                MessageBox.Show($"Person with {ID} is not found ", " Can`t Find", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
            

        }
        public void  LoadPersonInfo(string NationalNO)

        {
            
            _CurrentPerson = clsPeople.Find(NationalNO);
            if (_CurrentPerson == null)
            {
                RestPersonInfo();
                MessageBox.Show($"Person with {NationalNO} is not found ", " Can`t Find", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
          

        }
        private void _FillPersonInfo()
        {
            lbPerson_ID.Text = _CurrentPerson.PersonID.ToString();
            _PersonID=_CurrentPerson.PersonID;
            lbPerson_FullName.Text = _CurrentPerson.FullName();
            lbPerson_NationalNo.Text = _CurrentPerson.NationalNo;

            if (_CurrentPerson.Gendor == 0)
            {
                lbPerson_Gender.Text = "Male";
            }
            else
                lbPerson_Gender.Text = "Female";
            lbPerson_Email.Text = _CurrentPerson.Email;
            lbPerson_Phone.Text = _CurrentPerson.Phone;
            lbPerson_DateOfBirth.Text = _CurrentPerson.DateOfBirth.ToString("MM/dd/yyyy");
            lbPerson_Address.Text = _CurrentPerson.Address;

            _loadPersonImage();


            lbPerson_Country.Text = _CurrentPerson.ConutryInfo.CountryName;
            lnlbEditPersoneInfo.Visible = true;
        }
        private void RestPersonInfo()
        {

            lbPerson_ID.Text = "[????]";
            lbPerson_FullName.Text = "[????]";
            lbPerson_NationalNo.Text= "[????]";
            lbPerson_Gender.Text= "[????]";
            lbPerson_Email.Text= "[????]";
            lbPerson_Address.Text= "[????]";
            lbPerson_Phone.Text= "[????]";
            lbPerson_DateOfBirth.Text= "[????]";
            lbPerson_Country.Text= "[????]";
            lnlbEditPersoneInfo.Visible = false;
            pcb_personImage.Image = Properties.Resources.icons8_administrator_male_48;
        }
       private void _loadPersonImage()
        {

            if (_CurrentPerson.Gendor == 0)
            {
                pcb_personImage.Image = Properties.Resources.icons8_administrator_male_48;

            }
            else
            {
                pcb_personImage.Image = Properties.Resources.icons8_businesswoman_48;
            }

            string ImagePath = _CurrentPerson.ImagePath;
            if (File.Exists(ImagePath))
            {
                pcb_personImage.ImageLocation = ImagePath;
            }
            else
            {/*
                MessageBox.Show($"Could not find this image = {ImagePath}", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
            }
        }

        private void PersonUpdated(int PersonID)
        {
            _IsUpDatePersonFromPersonCard = true;
            LoadPersonInfo(PersonID);
        }
        private void lnlbEditPersoneInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _IsUpDatePersonFromPersonCard=false;
            frm_AddNewPerson frmAddNewPerson=new frm_AddNewPerson(_PersonID);
            frmAddNewPerson.DataBack+= PersonUpdated;
           // LoadPersonInfo(_PersonID);
            frmAddNewPerson.ShowDialog();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
