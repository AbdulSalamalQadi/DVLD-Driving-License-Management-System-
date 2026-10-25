using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


public class clsApplicationTypes
{
    public enum Mode
    {
        AddNew = 1,
        Update = 2
    }
    public int ApplicationTypeID { get; set; }
    public string ApplicationTypeTitle { get; set; }
    public decimal ApplicationFees { get; set; }
    public Mode _Mode { get; set; }
    public clsApplicationTypes()
    {
        ApplicationTypeID = -1;
        ApplicationTypeTitle = "";
        ApplicationFees = 0.00m;
        _Mode = Mode.AddNew;
    }



    private bool _AddNewApplicationType()
    {
        this.ApplicationTypeID = clsApplicationTypesDAL.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationFees);
        return this.ApplicationTypeID != -1;
    }

    private bool _UpdateApplicationType()
    {
        return clsApplicationTypesDAL.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
    }



    private clsApplicationTypes(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
    {
        this.ApplicationTypeID = ApplicationTypeID;
        this.ApplicationTypeTitle = ApplicationTypeTitle;
        this.ApplicationFees = ApplicationFees;
        this._Mode = Mode.Update;
    }

    public static clsApplicationTypes FindByID(int ApplicationTypeID)
    {
        string ApllicationTypeTitle = "";
        decimal ApplicationFees = 0;

        if (clsApplicationTypesDAL.GetApplicationTypeByID(ApplicationTypeID, ref ApllicationTypeTitle, ref ApplicationFees))
        {
            return new clsApplicationTypes(ApplicationTypeID, ApllicationTypeTitle, ApplicationFees);

        }
        return null;
    }


    public static DataTable GetAllApplicationTypes()
    {
        return clsApplicationTypesDAL.GetAllApplicationTypes();
    }

    public static bool IsApplicationExists(int ApplicationTypeID)
    {
        return clsApplicationTypesDAL.IsApplictionExists(ApplicationTypeID);
    }


    public static bool DeleteApplicationType(int ApplicationTypeID)
    {
        return clsApplicationTypesDAL.DeleteApplicationType(ApplicationTypeID);
    }


    public bool Save()
    {
        switch (this._Mode)
        {
            case Mode.AddNew:
                if (this._AddNewApplicationType())
                {
                    this._Mode = Mode.Update;
                    return true;
                }
                else
                {
                    return false;
                }
            case Mode.Update:
                return _UpdateApplicationType();
                break;

        }
        return false;
    }
}

