using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using System.Data.SqlClient;
using System.Data;

public class clsApplicationTypesDAL
{

    public static bool GetApplicationTypeByID(int ApplicationTypeID, ref string ApplicationTypeTitle, ref decimal ApplicationFees)
    {
        bool _Find = false;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = "Select * from ApplicationTypes Where ApplicationTypeID=@ApplicationTypeID";
        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

        try
        {
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                _Find = true;

                ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                ApplicationFees = (decimal)reader["ApplicationFees"];

            }
            else
            {
                _Find = false;
            }

            reader.Close();

        }
        catch (Exception ex)
        {
           
        }
        finally
        {
            connection.Close();
        }
        return _Find;
    }


    public static int AddNewApplicationType(string ApplicationTypeTitle, decimal ApplicationFees)
    {
        int NewApplicationTypeID = -1;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = "Insert into ApplicationTypes(ApplicationTypeTitle,ApplicationFees) values(@ApplicationTypeTitle,@ApplicationFees) SELECT SCOPE_IDENTITY();";
        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
        cmd.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

        try
        {
            connection.Open();

            object result = cmd.ExecuteScalar();
            if (result != null && int.TryParse(result.ToString(), out int newID))
            {
                NewApplicationTypeID=newID;
            }
          
        }
        catch (Exception ex)
        {
           
        }
        finally
        {
            connection.Close();
        }

        return NewApplicationTypeID;
    }

    public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
    {
         int rowsAffected = -1;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = "Update ApplicationTypes set ApplicationTypeTitle=@ApplicationTypeTitle,ApplicationFees=@ApplicationFees where ApplicationTypeID=@ApplicationTypeID";
        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
        cmd.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
        cmd.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

        try
        {
            connection.Open();

             rowsAffected = cmd.ExecuteNonQuery();
           
        }
        catch (Exception ex)
        {
           
        }
        finally
        {
            connection.Close();
        }

        return (rowsAffected > 0);
    }

    public static DataTable GetAllApplicationTypes()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = "Select * from ApplicationTypes";
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

    public static bool IsApplictionExists(int ApplicationTypeID)
    {
        bool _Find = false;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = "Select * from ApplicationTypes Where ApplicationTypeID=@ApplicationTypeID";
        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

        try
        {
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            _Find = reader.HasRows;
            reader.Close();

        }
        catch (Exception ex)
        {
           
        }
        finally
        {
            connection.Close();
        }
        return _Find;
    }
    
    public static bool DeleteApplicationType(int ApplicationTypeID)
    {
        int rowsAffected = -1;
        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = "Delete from ApplicationTypes Where ApplicationTypeID=@ApplicationTypeID";
        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

        try
        {
            connection.Open();

           rowsAffected = cmd.ExecuteNonQuery();
          

        }
        catch (Exception ex)
        {
           
        }
        finally
        {
            connection.Close();
        }
        return (rowsAffected > 0);
    }
}
