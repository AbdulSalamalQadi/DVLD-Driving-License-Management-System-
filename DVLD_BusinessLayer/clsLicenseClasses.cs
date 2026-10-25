using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

 public class clsLicenseClasses
 {
          public enum Mode { AddNew=1,Update=2};
          
           public int LicesneClassID { get; set; }
           public  string ClassName { get; set; }
          public string  ClassDescription { get; set; }
          public short MinimumAllowedAge { get; set; }
         
         public short DefaultValidityLength { get; set; }
        public  decimal ClassFees { get; set; }
       public Mode _Mode { get; set; }


    public  clsLicenseClasses()
    {
        this.LicesneClassID = -1;
        this.ClassName = "";
        this.ClassDescription = "";
        this.MinimumAllowedAge = -1;
        this.DefaultValidityLength = -1;
        this.ClassFees = 0.00m;

        this._Mode = Mode.AddNew;
    }

  private bool _AddNewLicenseClass()
    {
          this.LicesneClassID = clsLicenseClassesDAL.AddNewLicenseClass(this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
        return (this.LicesneClassID != -1);
    }

    private bool _UpdateLicenseClass()
    {
        return clsLicenseClassesDAL.UpdateLicenseClass(this.LicesneClassID, this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
    }

    private clsLicenseClasses(int LicesneClassID, string ClassName, string ClassDescription,
        short MinimumAllowedAge, short DefaultValidityLength, decimal ClassFees)
    {
        this.LicesneClassID=LicesneClassID;
        this.ClassName=ClassName;
        this.ClassDescription=ClassDescription;
        this.MinimumAllowedAge=MinimumAllowedAge;
        this.DefaultValidityLength=DefaultValidityLength;
        this.ClassFees=ClassFees;

        this._Mode = Mode.Update;
    }






    public static clsLicenseClasses FindByID(int LicesneClassID)
    {
        string ClassName = "";
        string ClassDescription = "";
        short MinimumAllowedAge = -1;
        short DefaultValidityLength = -1;
        decimal ClassFees = 0.00m;

        if (clsLicenseClassesDAL.GetLicenseClassID(LicesneClassID, ref ClassName, ref ClassDescription,ref MinimumAllowedAge,ref DefaultValidityLength, ref ClassFees))
        {
            return new clsLicenseClasses(LicesneClassID, ClassName, ClassDescription,MinimumAllowedAge,DefaultValidityLength, ClassFees);

        }
        return null;
    }

  public static DataTable GetAllLicenseClasses()
    {
        return clsLicenseClassesDAL.GetAllLicenseClasses();
    }

    public static bool IsLicenseClassExists(int LicenseClassID)
        {
            return clsLicenseClassesDAL.IsLicenseClassExists(LicenseClassID);
        }


    public static bool DeleteLicenseClass(int LicenseClassID)
    {
        return clsLicenseClassesDAL.DeleteLicenseClass(LicenseClassID);
    }


    public bool Save()
    {
        switch (this._Mode)
        {
            case Mode.AddNew:
                if (this._AddNewLicenseClass())
                {
                    this._Mode = Mode.Update;
                    return true;
                }
                else
                {
                    return false;
                }
            case Mode.Update:
                return _UpdateLicenseClass();
                break;

        }
        return false;
    }


}

