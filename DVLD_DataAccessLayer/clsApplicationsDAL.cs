using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using System.Data.SqlClient;
using System.Data;

    public class clsApplicationsDAL
    {

        public static bool GetApplicationByID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID, ref short ApplicationStatus,
            ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection sqlConn = new SqlConnection(clsDataAccessSetting.ConnectionString);
               string sQuery = @"SELECT * FROM Applications
                       WHERE ApplicationID = @ApplicationID";

                       SqlCommand cmmd = new SqlCommand(sQuery, sqlConn);
                       cmmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                sqlConn.Open();
                SqlDataReader dr = cmmd.ExecuteReader();

                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        ApplicantPersonID = Convert.ToInt32(dr["ApplicantPersonID"]);
                        ApplicationDate     = Convert.ToDateTime(dr["ApplicationDate"]);
                        ApplicationTypeID   = Convert.ToInt32(dr["ApplicationTypeID"]);
                        ApplicationStatus   = Convert.ToInt16(dr["ApplicationStatus"]);
                        LastStatusDate      = Convert.ToDateTime(dr["LastStatusDate"]);
                        PaidFees            = Convert.ToDecimal(dr["PaidFees"]);
                        CreatedByUserID     = Convert.ToInt32(dr["CreatedByUserID"]);

                        IsFound = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                sqlConn.Close();
            }
         return IsFound;
           
        }







          public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, short ApplicationStatus,
            DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
          {
                         int NewApplicationID    = -1;
                        
                         SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
                        
                         string Query = @"Insert into Applications   (ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID) 
                                          values
                                                      (@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,@ApplicationStatus,@LastStatusDate,@PaidFees,@CreatedByUserID)  
                                                     SELECT SCOPE_IDENTITY();";
                        
                         SqlCommand cmd = new SqlCommand(Query, connection);

                         cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                         cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                         cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                         cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                         cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                         cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
                         cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        
                         try
                         {
                             connection.Open();
                        
                             object result = cmd.ExecuteScalar();
                             if (result != null && int.TryParse(result.ToString(), out int newID))
                             {
                                 NewApplicationID = newID;
                             }
                           
                         }
                         catch (Exception)
                         {
                            
                         }
                         finally
                         {
                             connection.Close();
                         }

        return NewApplicationID;
    }

    public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
        int ApplicationTypeID, short ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
    {
         int rowsAffected = -1;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"Update Applications 
                   set ApplicantPersonID=@ApplicantPersonID,
                       ApplicationDate=@ApplicationDate,
                       ApplicationTypeID=@ApplicationTypeID,
                       ApplicationStatus=@ApplicationStatus,
                       LastStatusDate=@LastStatusDate,
                       PaidFees=@PaidFees,
                       CreatedByUserID=@CreatedByUserID
                              where 
                      ApplicationID=@ApplicationID";
        SqlCommand cmd = new SqlCommand(Query, connection);


        cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
        cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
        cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
        cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
        cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
        cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
        cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
        cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

        try
        {
            connection.Open();

            rowsAffected = cmd.ExecuteNonQuery();

        }
        catch (Exception)
        {

        }
        finally
        {
            connection.Close();
        }

        return (rowsAffected > 0);
    }

    public static DataTable GetAllApplications()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"Select * from Applications";
        SqlCommand cmd = new SqlCommand(Query, connection);

        try
        {
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                dt.Load(reader);
            }

            reader.Close();
        }
        catch (Exception)
        {

        }
        finally
        {
            connection.Close();
        }

        return dt;
    }

    public static bool IsApplicationExists(int ApplicationID)
    {
        bool _Find = false;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"Select found=1 from Applications
                    Where ApplicationID=@ApplicationID";

        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

        try
        {
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            _Find = reader.HasRows;
            reader.Close();

        }
        catch (Exception)
        {

        }
        finally
        {
            connection.Close();
        }


        return _Find;
    }



    
    public static bool DeleteApplication(int ApplicationID)
    {
        int rowsAffected = -1;
        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"Delete from Applications 
                          Where ApplicationID=@ApplicationID";
        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

        try
        {
            connection.Open();

           rowsAffected = cmd.ExecuteNonQuery();
          

        }
        catch (Exception)
        {
           
        }
        finally
        {
            connection.Close();
        }
        return (rowsAffected > 0);
    }


    }


