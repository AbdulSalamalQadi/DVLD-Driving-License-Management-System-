using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
    public class clsTestAppointments
    {
       
        private enum Mode
        {
            AddNew = 0,
            Update = 1,
         
        }
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime TestAppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
       
           
           private Mode _Mode { get; set; }

           public int CreatedByUserID { get; set; }
           public int RetakeTestApplicationID { get; set; }
            public bool IsLocked { get; set; }


           public clsTestAppointments()
           {
            TestAppointmentID=-1;
            TestTypeID=-1;
            LocalDrivingLicenseApplicationID=-1;
            TestAppointmentDate=DateTime.Now;
            PaidFees=0;
            CreatedByUserID=-1;
            RetakeTestApplicationID=-1;
              IsLocked=false;

         _Mode =Mode.AddNew;
               
           }

            private bool _AddNewTestAppointment()
            {
              
                this.TestAppointmentID = clsTestAppointmentsDAL.AddNewTestAppointment(TestTypeID, LocalDrivingLicenseApplicationID, TestAppointmentDate, PaidFees,
                IsLocked, CreatedByUserID, RetakeTestApplicationID);
                return (this.TestAppointmentID > 0);
            }

            private bool _UpdateTestAppointment()
            {
                return clsTestAppointmentsDAL.UpdateTestAppointment(TestAppointmentID,
                 TestTypeID, LocalDrivingLicenseApplicationID, TestAppointmentDate, PaidFees,
                IsLocked, CreatedByUserID, RetakeTestApplicationID);
            }
           private clsTestAppointments(int TestAppointmentID, int TestTypeID, int
           LocalDrivingLicenseApplicationID, DateTime TestAppointmentDate, 
           decimal PaidFees, bool Locked, int CreatedByUserID, int RetakeTestApplicationID)
           {
            this.TestAppointmentID=TestAppointmentID;
            this.TestTypeID=TestTypeID;
            this.LocalDrivingLicenseApplicationID=LocalDrivingLicenseApplicationID;
            this.TestAppointmentDate=TestAppointmentDate;
            this.PaidFees=PaidFees;
            this.IsLocked=Locked;
            this.CreatedByUserID=CreatedByUserID;
            this.RetakeTestApplicationID=RetakeTestApplicationID;

            _Mode=Mode.Update;
           }

       private bool _Validate()
       {
          if(TestTypeID<=0
           || LocalDrivingLicenseApplicationID<=0
           || TestAppointmentDate==null
           || PaidFees<0
           || CreatedByUserID<=0)
            {
            return false;
            }
          else
          {
            return true;
          }
        
       }
           public static clsTestAppointments Find(int TestAppointmentID)
           {



         
              int _TestTypeID = -1;
                  int _LocalDrivingLicenseApplicationID = -1;
              DateTime _TestAppointmentDate = DateTime.Now;
              decimal _PaidFees = 0;
                bool _Locked = false;
                int _CreatedByUserID = -1;
                int _RetakeTestApplicationID = -1;

                if(clsTestAppointmentsDAL.GetTestAppointmentByID(TestAppointmentID, ref _TestTypeID, ref _LocalDrivingLicenseApplicationID, ref _TestAppointmentDate, 
                ref _PaidFees, ref _Locked, ref _CreatedByUserID, ref _RetakeTestApplicationID))
                {
                  return new clsTestAppointments(TestAppointmentID, _TestTypeID, _LocalDrivingLicenseApplicationID, _TestAppointmentDate, 
                    _PaidFees, _Locked, _CreatedByUserID, _RetakeTestApplicationID);
                }
                else
                {
                    return null;
                }
           }


           public bool Save()
           {
            if(!_Validate())
            {
                return false;
            }
            switch(_Mode)
            {
                case Mode.AddNew:
                   if(this._AddNewTestAppointment())
                   {
                    _Mode=Mode.Update;
                    return true;
                   }
                   else
                   {
                    return false;
                   }
                case Mode.Update:
                    return _UpdateTestAppointment();
                default:
                    return false;
            }
           }
  }

