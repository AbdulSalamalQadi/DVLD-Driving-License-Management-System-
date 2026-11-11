using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DVLD_DataAccessLayer;

    public class clsTestAppointmentsDAL
    {
        public static bool GetTestAppointmentByID(int TestAppointmentID,ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, 
        ref DateTime TestAppointmentDate, ref decimal PaidFees, ref bool isLocked,
         ref int CreatedByUserID, ref int RetakeTestApplicationID)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string sql = @"SELECT
                          * FROM TestAppointments
                           WHERE TestAppointmentID=@TestAppointmentID";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    TestTypeID = Convert.ToInt32(dr["TestTypeID"]);
                    LocalDrivingLicenseApplicationID = Convert.ToInt32(dr["LocalDrivingLicenseApplicationID"]);
                    TestAppointmentDate = Convert.ToDateTime(dr["TestAppointmentDate"]);
                    PaidFees = Convert.ToDecimal(dr["PaidFees"]);
                isLocked = Convert.ToBoolean(dr["Locked"]);
                    CreatedByUserID = Convert.ToInt32(dr["CreatedByUserID"]);
                    RetakeTestApplicationID = (dr["RetakeTestApplicationID"] == DBNull.Value )? -1 : Convert.ToInt32(dr["RetakeTestApplicationID"]);

                    result = true;
                }
            }
            catch (Exception )
            {
            
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime TestAppointmentDate, decimal PaidFees,
        bool  IsLocked, int CreatedByUserID, int RetakeTestApplication)
        {
            int NewTestAppointmentID = -1;
            SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string sql = @"INSERT INTO TestAppointments
            (                     TestTypeID, 
                                  LocalDrivingLicenseApplicationID,
                                  TestAppointmentDate, 
                                  PaidFees, 
                                  Locked, 
                                  CreatedByUserID,
                                  RetakeTestApplicationID     )
             VALUES 
                (
                                  @TestTypeID,
                                  @LocalDrivingLicenseApplicationID,
                                  @TestAppointmentDate,
                                  @PaidFees, 
                                  @Locked,
                                  @CreatedByUserID,
                                  @RetakeTestApplicationID
                                );
                           SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@TestAppointmentDate", TestAppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@Locked", IsLocked);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            
            if(RetakeTestApplication <= 0)
            {
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplication);
            }
       
            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    NewTestAppointmentID = id;
                }
            }
            catch (Exception )
            {
            
            }
            finally
            {
                con.Close();
            }
            return NewTestAppointmentID;
        }

     public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime TestAppointmentDate, decimal PaidFees,
        bool IsLocked, int CreatedByUserID, int RetakeTestApplicationID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string sql = @"UPDATE TestAppointments
                           SET TestTypeID                        = @TestTypeID,
                               LocalDrivingLicenseApplicationID  = @LocalDrivingLicenseApplicationID,
                               TestAppointmentDate               =@TestAppointmentDate,
                               PaidFees                          =@PaidFees,
                               Locked                            =@Locked,
                               CreatedByUserID                   =@CreatedByUserID,
                               RetakeTestApplicationID           =@RetakeTestApplicationID
                           WHERE TestAppointmentID               =@TestAppointmentID";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@TestAppointmentDate", TestAppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@Locked", IsLocked);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if(RetakeTestApplicationID <= 0)
            {
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            }
          

            try
            {
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                result = (rowsAffected > 0);
            }
            catch (Exception )
            {
            
            }
            finally
            {
                con.Close();
            }
            return result;
        }
    }

