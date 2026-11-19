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
using clsMyValidation;
using MyFileStorage;


namespace DVLD_UI
{
    public partial class uct_ManagePeople : UserControl
    {
        private static DataTable _dtAllPeople= clsPeople.AllPerson();
        private DataTable _DataTablePeople= _dtAllPeople.DefaultView.ToTable(false,"PersonID","NationalNo","FirstName","SecondName","ThirdName","LastName", "GendorCaption", "DateOfBirth", "CountryName","Phone","Email");
        DataView DataViewPeopleForfilter;
     
        public uct_ManagePeople()
        {
            InitializeComponent();
        }



        //My Funf
        private void _RefreshPeoplListData()
        {
            _dtAllPeople = clsPeople.AllPerson();
            _DataTablePeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName", "GendorCaption", "DateOfBirth", "CountryName", "Phone", "Email");
           
            DataViewPeopleForfilter = new DataView(_DataTablePeople);
            dgvPeopelInfo.DataSource = DataViewPeopleForfilter;
            _UpdateRowsCount();
        }
        void _LoadAddNewPerson_Form()
        {
            frm_AddNewPerson frmAddNewPerson = new frm_AddNewPerson(-1);
            frmAddNewPerson.RefershData += _RefreshPeoplListData;
            frmAddNewPerson.ShowDialog();
        }
        private void _DesginDataGridVievColumns()
        {
            if (dgvPeopelInfo.Rows.Count <= 0)
                return;
            dgvPeopelInfo.ScrollBars= ScrollBars.Both;
            dgvPeopelInfo.Columns["PersonID"].HeaderText = "Person ID";
           // dgvPeopelInfo.Columns["PersonID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPeopelInfo.Columns["PersonID"].Width = 70;

            dgvPeopelInfo.Columns["NationalNo"].HeaderText = "National No";
           // dgvPeopelInfo.Columns["NationalNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPeopelInfo.Columns["NationalNo"].Width = 70;

            dgvPeopelInfo.Columns["FirstName"].HeaderText = "First Name";
            // dgvPeopelInfo.Columns["FirstName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPeopelInfo.Columns["FirstName"].Width =80;

            dgvPeopelInfo.Columns["SecondName"].HeaderText = "Second Name";
            //dgvPeopelInfo.Columns["SecondName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPeopelInfo.Columns["SecondName"].Width = 80;


            dgvPeopelInfo.Columns["ThirdName"].HeaderText = "Third Name";
            dgvPeopelInfo.Columns["ThirdName"].Width = 70;
           // dgvPeopelInfo.Columns["ThirdName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvPeopelInfo.Columns["LastName"].HeaderText = "Last Name";
           // dgvPeopelInfo.Columns["LastName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPeopelInfo.Columns["LastName"].Width = 80;

            dgvPeopelInfo.Columns["GendorCaption"].HeaderText = "Gender";
          //  dgvPeopelInfo.Columns["GendorCaption"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPeopelInfo.Columns["GendorCaption"].Width = 50;

           // dgvPeopelInfo.Columns["DateOfBirth"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPeopelInfo.Columns["DateOfBirth"].HeaderText = "Date Of Birth";
            dgvPeopelInfo.Columns["DateOfBirth"].Width = 80;

           // dgvPeopelInfo.Columns["CountryName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPeopelInfo.Columns["CountryName"].HeaderText = "Country";
            dgvPeopelInfo.Columns["CountryName"].Width = 70;
//
            //dgvPeopelInfo.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPeopelInfo.Columns["Phone"].HeaderText = "Phone";
            dgvPeopelInfo.Columns["Phone"].Width =70;

            dgvPeopelInfo.Columns["Email"].HeaderText = "Email";
            //dgvPeopelInfo.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPeopelInfo.Columns["Email"].Width = 100;

            // dgvPeopelInfo.Columns["Phone"].HeaderText = "Phone ";

         

          // dgvPeopelInfo.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        private void _UpdateRowsCount()
        {
            if(DataViewPeopleForfilter == null)
            {
                LbRowsCounts.Text = "0";
            }
            else
                LbRowsCounts.Text =(DataViewPeopleForfilter.Count.ToString().Trim());

        }
      
        private void _FilterAllStringColumns(string FilterBySepcialColumn,string FilterContain)
        {
            if(clsValidation.Empty(FilterBySepcialColumn) || clsValidation.Empty(FilterContain))
            {
                return;
            }
            else
            {
                DataViewPeopleForfilter.RowFilter = $"[{FilterBySepcialColumn}]like '{FilterContain}*'";
                _UpdateRowsCount();
            }

        }
        private void _FilterAllIntColumns(string FilterBySepcialColumn, string FilterContain)
        {
            if (clsValidation.Empty(FilterBySepcialColumn) || clsValidation.Empty(FilterContain))
            {
                return;
            }

            if (clsValidation.ValidateInteger(FilterContain.Trim()))
            {
                DataViewPeopleForfilter.RowFilter = $"[{FilterBySepcialColumn}] ={FilterContain}";
                _UpdateRowsCount();
            }
        }
        private void _FilterData()
        {

            string txbContant = txbFilter.Text.Trim();
            string ComoBoxSelectedItem = CmbFilterMode.SelectedItem.ToString();

            if (ComoBoxSelectedItem == "Person ID")
            {
                _FilterAllIntColumns("PersonID", txbContant);
                return;
            }


            if (ComoBoxSelectedItem == "Phone")
            {
                _FilterAllStringColumns("Phone", txbContant);

                return;
            }

            if (ComoBoxSelectedItem == "First Name")
            {
                _FilterAllStringColumns("FirstName", txbContant);

                return;
            }

            if (ComoBoxSelectedItem == "Second Name")
            {
                _FilterAllStringColumns("SecondName", txbContant);

                return;
            }


            if (ComoBoxSelectedItem == "Third Name")
            {
                _FilterAllStringColumns("ThirdName", txbContant);

                return;
            }

             if (ComoBoxSelectedItem == "Last Name")
             {
                _FilterAllStringColumns("LastName", txbContant);

                return;
             }

            if (ComoBoxSelectedItem == "National No")
            {
                _FilterAllStringColumns("NationalNo", txbContant);

                return;
            }

            if (ComoBoxSelectedItem == "Country")
            {
                _FilterAllStringColumns("CountryName", txbContant);

                return;
            }

            if (ComoBoxSelectedItem == "Email")
            {
                _FilterAllStringColumns("Email", txbContant);

                return;
            }

             if (ComoBoxSelectedItem == "Gender")
            {
                _FilterAllStringColumns("GendorCaption", txbContant);

                return;
            }

        }

      

        //Events Func
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          int ID= Convert.ToInt32(dgvPeopelInfo.CurrentRow.Cells["PersonID"].Value);
            frm_ShowPersonInfo frm_Liecens2 = new frm_ShowPersonInfo(ID);
            frm_Liecens2.DataBackForRefersh += _RefreshPeoplListData;
            frm_Liecens2.ShowDialog();
           // _RefreshPeoplListDats();


        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvPeopelInfo.CurrentRow.Cells["PersonID"].Value);
            frm_AddNewPerson frmAddNewPerson = new frm_AddNewPerson(ID);

            frmAddNewPerson.RefershData += _RefreshPeoplListData;
            frmAddNewPerson.ShowDialog();
           // _RefreshPeoplListDats();
        }



        private void uct_ManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeoplListData();
            _DesginDataGridVievColumns();
           
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvPeopelInfo.CurrentRow.Cells["PersonID"].Value);
            try
            {
                if (clsPeople.IstPersonByIDExis(ID))
                {
                    string ImagePath = clsPeople.Find(ID).ImagePath;
                    if (MessageBox.Show($"Are you Soure ,Do you want delete this is Person`s ID {ID} ", "Delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                    {
                        if (clsPeople.DeletePerson(ID))
                        {
                            FileStorage.DeleteFile(ImagePath);
                            MessageBox.Show("Person deleted Sucessfuly . ", "Deleted ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            _RefreshPeoplListData();
                        }
                        else
                        {
                            MessageBox.Show("Person was not  deleted because he has data linked to him ", "Deleted ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void txbFilter_TextChanged(object sender, EventArgs e)
        {
            if (clsValidation.Empty(txbFilter.Text))
            {
                DataViewPeopleForfilter.RowFilter = "";
                _UpdateRowsCount();
                return;
            }


            _FilterData();
        }
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LoadAddNewPerson_Form();
        }



        private void ImgBtnAddNewPerson_Click(object sender, EventArgs e)
        {
            _LoadAddNewPerson_Form();
        }
        private void CmbFilterMode_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(CmbFilterMode.SelectedItem.ToString().ToLower() == "noun")
            txbFilter.Visible = false;
            else
                txbFilter.Visible = true;
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dgvPeopelInfo_DoubleClick(object sender, EventArgs e)
        {
            frm_ShowPersonInfo frm = new frm_ShowPersonInfo((int)dgvPeopelInfo.CurrentRow.Cells[0].Value);
            frm.DataBackForRefersh += _RefreshPeoplListData;
            frm.ShowDialog();
        }

        private void txbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(CmbFilterMode.Text.Trim() =="Person ID")
                e.Handled= !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
           
        }
    }
}
