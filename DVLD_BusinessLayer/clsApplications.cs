using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

public class clsApplications
{
    public enum Mode
    {
        AddNew = 1,
        Update = 2
    }
    public int ApplicationID { get; set; }
    public int ApplicantPersonID { get; set; }
    public DateTime ApplicationDate { get; set; }
    public int ApplicationTypeID { get; set; }
    public short ApplicationStatus { get; set; }
    public DateTime LastStatusDate { get; set; }
    public decimal PaidFees { get; set; }
    public int CreatedByUserID { get; set; }
    public Mode _Mode { get; set; }


    public clsApplications()
    {
        this.ApplicationID = -1;
        this.ApplicantPersonID = -1;
        this.ApplicationDate = DateTime.MinValue;
        this.ApplicationTypeID = -1;
        this.ApplicationStatus = -1;
        this.LastStatusDate = DateTime.MinValue;
        this.PaidFees = 0.00m;
        this.CreatedByUserID = -1;
        this._Mode = Mode.AddNew;
    }
    private bool _AddNewApplication()
    {
        this.ApplicationID = clsApplicationsDAL.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        return this.ApplicationID != -1;
    }

    private bool _UpdateApplication()
    {
        return clsApplicationsDAL.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
    }



    private clsApplications(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, short ApplicationStatus,
     DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
    {
        this.ApplicationID = ApplicationID;
        this.ApplicantPersonID = ApplicantPersonID;
        this.ApplicationDate = ApplicationDate;
        this.ApplicationTypeID = ApplicationTypeID;
        this.ApplicationStatus = ApplicationStatus;
        this.LastStatusDate = LastStatusDate;
        this.PaidFees = PaidFees;
        this.CreatedByUserID = CreatedByUserID;

        this._Mode = Mode.Update;
    }



    public static clsApplications FindApplicationByID(int ApplicationID)
    {
        int ApplicantPersonID = -1;
        DateTime ApplicationDate = DateTime.MinValue;
        int ApplicationTypeID = -1;
        short ApplicationStatus = -1;
        DateTime LastStatusDate = DateTime.MinValue;
        decimal PaidFees = 0.00m;
        int CreatedByUserID = -1;

        if (clsApplicationsDAL.GetApplicationByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID,
        ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
        {
            return new clsApplications(ApplicationID, ApplicantPersonID, ApplicationDate,
            ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
        }
        else
        {
            return null;
        }
    }


public static DataTable AllApplications()
    {
        return clsApplicationsDAL.GetAllApplications();
    }

    public static bool IsApplicationExists(int ApplicationID)
    {
        return clsApplicationsDAL.IsApplicationExists(ApplicationID);
    }


    public static bool DeleteApplication(int ApplicationID)
    {
        return clsApplicationsDAL.DeleteApplication(ApplicationID);
    }


    public bool Save()
    {
        switch (this._Mode)
        {
            case Mode.AddNew:
                if (this._AddNewApplication())
                {
                    this._Mode = Mode.Update;
                    return true;
                }
                else
                {
                    return false;
                }
            case Mode.Update:
                return _UpdateApplication();
                break;

        }
        return false;
    }


}


