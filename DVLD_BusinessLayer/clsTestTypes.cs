using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

    public class clsTestTypes
    {

         public enum Mode
    {
        AddNew = 1,
        Update = 2
    }
    public int TestTypeID { get; set; }
    public string TestTypeTitle { get; set; }
    public string TestTypeDescription { get; set; }
    public decimal TestTypeFees { get; set; }
    public Mode _Mode { get; set; }
    public clsTestTypes()
    {
        TestTypeID = -1;
        TestTypeTitle = "";
        TestTypeDescription = "";
        TestTypeFees = 0.00m;
        _Mode = Mode.AddNew;
    }



    private bool _AddNewTestType()
    {
        this.TestTypeID = clsTestTypesDAL.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        return this.TestTypeID != -1;
    }

    private bool _UpdateTestType()
    {
        return clsTestTypesDAL.UpdateTestType(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees      );
    }



    private clsTestTypes(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
    {
        this.TestTypeID = TestTypeID;
        this.TestTypeTitle = TestTypeTitle;
        this.TestTypeDescription = TestTypeDescription;
        this.TestTypeFees = TestTypeFees;
        this._Mode = Mode.Update;
    }

    public static clsTestTypes FindByID(int TestTypeID)
    {
        string TestTypeTitle = "";
        string TestTypeDescription = "";
        decimal TestTypeFees = 0;

        if (clsTestTypesDAL.GetTestTypeByID(TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
        {
            return new clsTestTypes(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);

        }
        return null;
    }


    public static DataTable GetAllTestTypes()
    {
        return clsTestTypesDAL.GetAllTestTypes();
    }

    public static bool IsTestTypeExists(int TestTypeID)
    {
        return clsTestTypesDAL.IsTestTypeExists(TestTypeID);
    }


    public static bool DeleteTestType(int TestTypeID)
    {
        return clsTestTypesDAL.DeleteTestType(TestTypeID);
    }


    public bool Save()
    {
        switch (this._Mode)
        {
            case Mode.AddNew:
                if (this._AddNewTestType())
                {
                    this._Mode = Mode.Update;
                    return true;
                }
                else
                {
                    return false;
                }
            case Mode.Update:
                return _UpdateTestType();
                break;

        }
        return false;
    }
    }

