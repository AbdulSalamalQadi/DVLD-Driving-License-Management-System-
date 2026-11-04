using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class clsLocalDrivingLicenseApplications
 {
    private enum Mode { AddNew=0, Update=1}
    public int LocalDrivingLicenseApplicationID { get; set; }
    public int ApplicationID { get; set; }
    public int LicenseClassID { get; set; }
    private Mode _Mode=Mode.AddNew;

    private bool _AddNewLDLA()
    {
        this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsADL.AddNewLocalDrivingLiceseApplication(this.ApplicationID, this.LicenseClassID);
        return (this.LocalDrivingLicenseApplicationID > 0);
    }

      private clsLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID,int ApplicationID ,int LicenseClassID)
      {
        this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        this.ApplicationID = ApplicationID;
        this.LicenseClassID = LicenseClassID;
        _Mode = Mode.Update;
    }


       public clsLocalDrivingLicenseApplications()
    {
        this.LocalDrivingLicenseApplicationID = -1;
        this.ApplicationID = -1;
        this.LicenseClassID = -1;
        _Mode = Mode.AddNew;
    }
       
       public clsLocalDrivingLicenseApplications Find(int ID)
       {
        int ApplicationID = -1;
        int LicenseClassID = -1;
        if(clsLocalDrivingLicenseApplicationsADL.GetLocalDrivingLiceseApplication(ID,ref ApplicationID,ref LicenseClassID))
        {
            return new clsLocalDrivingLicenseApplications(ID,ApplicationID,LicenseClassID);
        }
        else
        {
            return null;
        }

       }


    public bool Save()
    {
        switch (_Mode)
        {
            case Mode.AddNew:
                if(_AddNewLDLA())
                {
                    _Mode = Mode.Update;
                    return true;
                }
                break;
            case Mode.Update:

                return false;
                break;
           
        }
        return false;
    }

}
