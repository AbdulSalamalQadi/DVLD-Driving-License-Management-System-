using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

  public class clsTestsResults
    {

    public enum Mode { AddNew=1,Update=2};

    public int TestID { get; set; }
    public int TestAppointmentID { get; set; }

    public  short TestResult { get; set; }

    public string Notes { get; set; }
    public int CreateByUserID { get; set; }


    public Mode _Mode = Mode.AddNew;

    private bool _AddNewTest()

    {   
        this.TestID=clsTestsResultDAL.AddNewTestsResult(this.TestAppointmentID,this.TestResult,this.Notes,this.CreateByUserID); 

        return (this.TestID > 0); 
    }


    private bool _UpdateTest()
    {
        return clsTestsResultDAL.UpdateTestsResult(this.TestID,this.TestResult,this.Notes,this.CreateByUserID);
    }
    public clsTestsResults()
    {
        TestID = -1;
        TestAppointmentID = -1;
        TestResult = -1;
        Notes = "";
        CreateByUserID = -1;
        _Mode = Mode.AddNew;
    }


    private clsTestsResults(int TestID ,int TestAppointmentID ,short TestResult ,string Nots, int CreatByUserID)
    {
        this.TestID = TestID;
        this.TestAppointmentID = TestAppointmentID;
        this.TestResult = TestResult;
        this.Notes= Nots;
        this.CreateByUserID = CreatByUserID;
        this._Mode = Mode.Update;
    }

    

    public static clsTestsResults Find(int TestID)
    {
        int TestAppointmentID = -1;
        short TestResult = -1;
        string Notes = "";
        int CreateByUserID = -1;
        
        if(clsTestsResultDAL.GetTestResultByID(TestID,ref TestAppointmentID,ref TestResult,ref Notes,ref CreateByUserID))
        {
            return new clsTestsResults(TestID,TestAppointmentID,TestResult,Notes,CreateByUserID);   
        }
        else
        {
            return null;
        }
    }

    public static DataTable AllTestResult()
    {
        return clsTestsResultDAL.GetAllTestsResultes();
    }

    public static bool IsTestResultExists(int TestID)

    {
        return clsTestsResultDAL.IsTestsResultExists(TestID);
    }

    public bool Save()

    {
        
        switch (_Mode)
        {
            case Mode.AddNew:

                if (_AddNewTest())
                {
                    _Mode = Mode.Update;
                    return true;
                }
                else
                {
                    return false;
                }
          break;
          case Mode.Update:
               return _UpdateTest();
            break;
          
        }
        return false;
    }
}
