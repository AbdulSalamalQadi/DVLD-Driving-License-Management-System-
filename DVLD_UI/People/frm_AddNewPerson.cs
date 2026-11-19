using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD_BusinessLayer;
using System.Drawing;
using Guna.UI2.WinForms;
using clsMyValidation;
using MyFileStorage;
namespace DVLD_UI
{
    public partial class frm_AddNewPerson : Form
    {

        // Declare a delegate
       // public delegate void DataBackEventHandler(int PersonID);
        //public delegate void RefershDataEventHandler();
        // Declare an event using the delegate
       
        public event Action<int> DataBack;
        public event Action RefershData;
        enum Mode { AddNewPerson = 0, UpdatePerson = 1 };
        Mode _Mode = Mode.AddNewPerson;

        int _PersonID = -1;   
        clsPeople _CurrentPerson;

        private enum enGender {Male=0,Female=1};
   
        public frm_AddNewPerson()
        {
           
            InitializeComponent();
            _Mode = Mode.AddNewPerson;
       
        }
        public frm_AddNewPerson(int ID)
        {
            InitializeComponent();

           
            if (ID > 0)
            {
                _Mode = Mode.UpdatePerson;
                _PersonID = ID;
            }
        }

        private void _LoadPersonInfo()
        {
            _CurrentPerson = clsPeople.Find(_PersonID);

            if (_CurrentPerson == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
                lbPerson_ID.Text = _CurrentPerson.PersonID.ToString();
                txbFirstName.Text = _CurrentPerson.FirstName.Trim();
                txbSeconName.Text = _CurrentPerson.SecondName.Trim();

                txbThirdName.Text = (!clsValidation.Empty(_CurrentPerson.ThirdName)) ? _CurrentPerson.ThirdName : "";
                dtpDateOfbirth.Value = _CurrentPerson.DateOfBirth;
                txbLastName.Text = _CurrentPerson.LastName.Trim();
                txbNationNo.Text = _CurrentPerson.NationalNo;
                txbPhone.Text = _CurrentPerson.Phone.Trim();
                txbEmail.Text = (clsValidation.Empty(_CurrentPerson.Email)) ? _CurrentPerson.Email : "";
                txbAddress.Text = _CurrentPerson.Address.Trim();
                _GetPersonGender();              
             cmbCountries.SelectedIndex = cmbCountries.FindString(_CurrentPerson.ConutryInfo.CountryName);
               
                _GetPersoImage();
                _ChangeLablesToUpdate();
            
        }
        private void _loadCountriesIntoComoboBox()
        {
            DataTable tb = clsCountries.AllCountries();

            foreach (DataRow dr in tb.Rows)
            {
                cmbCountries.Items.Add(dr["CountryName"]);
            }
        }
        private void _loadDefaultPersonData(string DefaultCountry = "Yemen")
        {
            if(_Mode==Mode.AddNewPerson)
            {
                _CurrentPerson = new clsPeople();
            }
            _loadCountriesIntoComoboBox();
            dtpDateOfbirth.MaxDate = (DateTime.Now.AddYears(-18));
            dtpDateOfbirth.MinDate = (DateTime.Now.AddYears(-100));
            dtpDateOfbirth.Value = dtpDateOfbirth.MaxDate;
            cmbCountries.SelectedIndex = cmbCountries.FindString(DefaultCountry);
            _GetImageForGender();

            radbuMale.Checked = true;
            txbFirstName.Text = string.Empty;
            txbLastName.Text = string.Empty;
            txbSeconName.Text = string.Empty;
            txbThirdName.Text= string.Empty;
            txbNationNo.Text= string.Empty;
            txbPhone.Text = string.Empty;
            txbAddress.Text= string.Empty;
            txbEmail.Text = string.Empty;
            lnklbRemoveImage.Visible = false; ;
       
        }
        private void frmAddNewPerson_Load(object sender, EventArgs e)
        {
                _loadDefaultPersonData();
            if (_Mode == Mode.UpdatePerson)
            {
                _LoadPersonInfo();
            }

        }



        private bool _SavePersonInfoIntoDataBase(clsPeople Person)
        {

            try
            {
                Person.NationalityCountryID = clsCountries.FindByCountryName(cmbCountries.Text).CountryID;
                Person.FirstName = txbFirstName.Text.Trim();
                Person.SecondName = txbSeconName.Text.Trim();
                Person.ThirdName = txbThirdName.Text.Trim();
                Person.LastName = txbLastName.Text.Trim();

                Person.NationalNo = txbNationNo.Text.Trim();

                if (radbuFemale.Checked)
                {
                    Person.Gendor = Convert.ToInt16(enGender.Female);
                }
                else
                {
                    Person.Gendor = Convert.ToInt16(enGender.Male);
                }


                Person.Email = (!clsValidation.Empty(txbEmail.Text)) ? txbEmail.Text.Trim() : string.Empty;

                Person.Address = txbAddress.Text.Trim();
                Person.Phone = txbPhone.Text.Trim();
                Person.DateOfBirth = dtpDateOfbirth.Value; 



                //  _CopyImage();

                if (pcb_personImage.ImageLocation != null)
                {
                    Person.ImagePath = pcb_personImage.ImageLocation;
                }
                else
                {
                    Person.ImagePath = "";

                }

                if (Person.Save())
                {
                    _CurrentPerson.PersonID = Person.PersonID;
                    Person.ImagePath = pcb_personImage.ImageLocation;
                   
                    return true;
                }
                else
                {

                    return false;
                }
            }catch (Exception ex)
            {
                return false;
            }

        }
        private void butSave_Click(object sender, EventArgs e)
      {
            //IsVal = !_ValidationEmptyValue();

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if(!_HandlePersonImage())
            {
                return;
            }

            if (_Mode == Mode.UpdatePerson)
                {
                    if (_UpDatePerson())
                    {
                        MessageBox.Show($"Updated Person Sucessfuly = Id {_CurrentPerson.PersonID}");
                    DataBack?.Invoke(_CurrentPerson.PersonID);
                    RefershData?.Invoke();
                }
                    else
                    {
                        MessageBox.Show($"Updated Person Faild ");
                    }
            }

               if (_Mode == Mode.AddNewPerson)
                {

                    if (_AddNewPerson())
                    {
                        _Mode = Mode.UpdatePerson;
                        _ChangeLablesToUpdate();
                        MessageBox.Show($"Added Person Sucessfuly = Id {_CurrentPerson.PersonID}");
                    DataBack?.Invoke(_CurrentPerson.PersonID);
                    RefershData?.Invoke();
                }
                    else
                    {
                        MessageBox.Show($"Added Person Faild ");
                    }
                  
                }
           
          
            
       }


        private bool _AddNewPerson()
        {
           
            return _SavePersonInfoIntoDataBase(_CurrentPerson);
        }
        private bool _UpDatePerson()
        {
            return _SavePersonInfoIntoDataBase(_CurrentPerson);
        }



        void _ChangeLablesToUpdate()
        {
            lbAddnewPerson.Text = "Update Person";
            _ShowRemoveLinkLab();
            lnklbAddImage.Text = (lnklbRemoveImage.Visible)?"Edit Image":"Set Image";
            lbPerson_ID.Text = _CurrentPerson.PersonID.ToString();


        }
        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_CurrentPerson.ImagePath != pcb_personImage.ImageLocation)
            {
                //if (_CurrentPerson.ImagePath != ""&&_CurrentPerson.ImagePath!=null)
                if (!clsValidation.Empty(_CurrentPerson.ImagePath))
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        FileStorage.DeleteFile(_CurrentPerson.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pcb_personImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string DestionImagePath = "C:\\DVlD-Peopel Images";
                    string SourceImageFile = pcb_personImage.ImageLocation.ToString();
                    SourceImageFile = FileStorage.MoveFileWithGuidName(SourceImageFile, DestionImagePath);

                    if (!clsValidation.Empty(SourceImageFile))
                    {
                        pcb_personImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }
        void _ShowRemoveLinkLab()
        {
            if (!clsValidation.Empty(_CurrentPerson.ImagePath))
            {
                lnklbRemoveImage.Visible = true;
            }
            else
            {
                lnklbRemoveImage.Visible = false;


            }

        }




        private void _GetPersonGender()
        {
            if (_CurrentPerson.Gendor == Convert.ToInt16(enGender.Male))
            {
                radbuMale.Checked = true;
                return;
            }

            if (_CurrentPerson.Gendor == Convert.ToInt16(enGender.Female))
                radbuFemale.Checked = true;
        }
        private void _GetImageForGender()
        {
            if (radbuMale.Checked)
            {
                pcb_personImage.Image = Properties.Resources.icons8_administrator_male_48;
               
            }
           else if (radbuFemale.Checked)
            {
                pcb_personImage.Image = Properties.Resources.icons8_businesswoman_48;
              
            }


            /*if (_CurrentPerson.Gendor == Convert.ToInt16(clsPeople.Gender.Female))
            {
                pcb_personImage.Image = Properties.Resources.icons8_businesswoman_48;
                return;
            }*/
        }
        private void _GetDefualtPersonImage()
        {
            if (clsValidation.Empty(_CurrentPerson.ImagePath)|| !File.Exists(_CurrentPerson.ImagePath))
            {
               
                _GetImageForGender();
            }
        }
        private void _GetPersoImage()
        {
            if (clsValidation.Empty(_CurrentPerson.ImagePath))
            {
                _GetDefualtPersonImage();
                return;
            }

            if (File.Exists(_CurrentPerson.ImagePath))
            {
                pcb_personImage.ImageLocation = _CurrentPerson.ImagePath;
            }
            else
            {
                _GetDefualtPersonImage();
            }
        }


        private void ValidateTextBox(Guna2TextBox texB, CancelEventArgs e, bool IsError, string ErrorMessage = "")
        {
            if (IsError)
            {
                e.Cancel = true;
                texB.Focus();
                errorProvider1.SetError(texB, ErrorMessage);
            }
            else
            {
                e.Cancel = false;

                errorProvider1.SetError(texB, "");
            }
        }
        private bool CkeckPersonExistforValiding(string Nat)
        {

            if (clsValidation.Empty(Nat))
            {
                return true;
            }
            if (Nat.Trim()!=_CurrentPerson.NationalNo.Trim() && clsPeople.IsPersonByNationalNoExist(Nat.Trim()))
            {

                return true;
            }
            return false;
        }
       

        //Events Validation  Text box
        private void txbEmail_Validating(object sender, CancelEventArgs e)
        {
            string Email= ((Guna2TextBox)sender).Text.Trim();
            bool pas =(!clsValidation.Empty(Email))?!clsValidation.ValidateEmail(Email): false;
            ValidateTextBox(txbEmail, e, pas, "Must Email Contains @ and .");
                    }
        private void txbNationNo_Validating(object sender, CancelEventArgs e)
        {
            bool pas = CkeckPersonExistforValiding(((Guna2TextBox)sender).Text);
            ValidateTextBox(txbNationNo, e, pas, "This National number is exists or empty");
        }
        private void txbFirstName_Validating(object sender, CancelEventArgs e)
        {
            bool pas = clsValidation.Empty(((Guna2TextBox)sender).Text);
            ValidateTextBox(txbFirstName, e, pas, "First Name is Requirement");
        }
        private void txbSeconName_Validating(object sender, CancelEventArgs e)
            {

            bool pas = clsValidation.Empty(((Guna2TextBox)sender).Text);
            ValidateTextBox(txbSeconName, e, pas, "Second Namw is Requirement");
        }
        private void txbLastName_Validating(object sender, CancelEventArgs e)
        {

            bool pas = clsValidation.Empty(((Guna2TextBox)sender).Text);
            ValidateTextBox(txbLastName, e, pas, "Last Name is Requirement");
        }
        private void txbAddress_Validating(object sender, CancelEventArgs e)
        {

            bool pas = clsValidation.Empty(((Guna2TextBox)sender).Text);
            ValidateTextBox(txbAddress, e, pas, "it is Requirement");
        }
        private void txbPhone_Validating(object sender, CancelEventArgs e)
        {

            bool pas = !clsValidation.ValidatePhoneNumber(txbPhone.Text.Trim());

            ValidateTextBox(txbPhone, e, pas, "it is Requirement");
        }


       


        private void lnklbRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pcb_personImage.ImageLocation=null;
            _GetImageForGender();
            lnklbRemoveImage.Visible = false;
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lnklbAddImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files | *.jpg; *.jpeg; *.png";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                pcb_personImage.ImageLocation=selectedFilePath;

                lnklbRemoveImage.Visible = true;
                lnklbAddImage.Text = "Edit Image";
            }
        }
        private void radbuMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pcb_personImage.ImageLocation == null)
                _GetImageForGender();
        }
        private void radbuFemale_CheckedChanged(object sender, EventArgs e)
        {
            if(pcb_personImage.ImageLocation ==null)
            _GetImageForGender();
        }
    }
}
