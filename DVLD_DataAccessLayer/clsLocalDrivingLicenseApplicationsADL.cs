using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DVLD_DataAccessLayer;


  public class clsLocalDrivingLicenseApplicationsADL
  {

    public static bool GetLocalDrivingLiceseApplicationByID(int ID, ref int ApplicationID,ref int LicenseClassID)
    {
        bool IsFound = false;

        SqlConnection sqlConnection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Quer = @"select 
                     ApplicationID,
                       LicenseClassID 
                  from LocalDrivingLicenseApplications
               where LocalDrivingLicenseApplicationID=@LDLA";
        SqlCommand command=new SqlCommand(Quer,sqlConnection);
        command.Parameters.AddWithValue("@LDLA", ID);



        try
        {
            sqlConnection.Open();
            SqlDataReader dr = command.ExecuteReader();

            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    ApplicationID = Convert.ToInt32(dr["ApplicationID"]);
                    LicenseClassID = Convert.ToInt32(dr["LicenseClassID"]);

                   
                    IsFound = true;
                }
            }
        }
        catch (Exception)
        {
        }
        finally
        {
            sqlConnection.Close();
        }
        return IsFound;

    }


    public static int  AddNewLocalDrivingLiceseApplication(int ApplicationID,  int LicenseClassID)
    {



        int NewApplicationID = -1;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Quer = @"INSERT INTO LocalDrivingLicenseApplications
           (ApplicationID
           ,LicenseClassID)
     VALUES
           (@ApplicationID)
           ,@LicenseClassID)
                   select SCOPE_IDENTITY() ";
        SqlCommand cmd = new SqlCommand(Quer, connection);
        cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
         cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

    public static bool UpdataLocalDrivingLiceseApplication(int ID, int ApplicationID, int LicenseClassID)
    {
        int rowsAffected = -1;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"UPDATE LocalDrivingLicenseApplications
                                 SET ApplicationID  = @ApplicationID
                                ,LicenseClassID = @LicenseClassID 
                             WHERE LocalDrivingLicenseApplicationID =@ID";


        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
        cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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
