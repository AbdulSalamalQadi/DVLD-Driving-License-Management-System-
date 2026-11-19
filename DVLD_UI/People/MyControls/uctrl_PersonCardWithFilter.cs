using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clsMyValidation;

namespace DVLD_UI
{
    public partial class uctrl_PersonCardWithFilter : UserControl
    {

        private int _PersonID=-1;
        private string _NationalNo = "";

        public uctrl_PersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void uctrl_PersonCardWithFilter_Load(object sender, EventArgs e)
        {
            CmbFindPerson.SelectedIndex = 0;
        }
        private void _SearchPerson()
        {
            if (CmbFindPerson.Text.Trim() == "Person ID")
            {
                if (!clsValidation.Empty(txbFilter.Text.Trim()))
                {
                    this._PersonID = Convert.ToInt32(txbFilter.Text.Trim());
                    uctPersonCardInfo.LoadPersonInfo(_PersonID);
                }
            }

            else if (CmbFindPerson.Text.Trim() == "National No")
            {
                if (!clsValidation.Empty(txbFilter.Text.Trim()))
                {
                    this._NationalNo = txbFilter.Text.Trim();
                    uctPersonCardInfo.LoadPersonInfo(_NationalNo);
                }
            }
        }
        private void pcb_personSearch_Click(object sender, EventArgs e)
        {
            _SearchPerson();
        }

        private void pcb_AddnewPerson_Click(object sender, EventArgs e)
        {
            frm_AddNewPerson frmAddNewPerson = new frm_AddNewPerson();
            frmAddNewPerson.DataBack += uctPersonCardInfo.LoadPersonInfo;
            frmAddNewPerson.ShowDialog();
            txbFilter.Text = (uctPersonCardInfo.PersonID > 0) ? uctPersonCardInfo.PersonID.ToString() : "";
        }

        private void txbFilter_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
