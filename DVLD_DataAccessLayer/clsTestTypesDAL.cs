using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using System.Data.SqlClient;
using System.Data;


    public class clsTestTypesDAL
    {
        public static bool GetTestTypeByID(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref decimal TestTypeFees)
    {
        bool _Find = false;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = "Select * from TestTypes Where TestTypeID=@TestTypeID";
        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

        try
        {
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                _Find = true;

                TestTypeTitle = (string)reader["TestTypeTitle"];
                TestTypeDescription = (string)reader["TestTypeDescription"];
                TestTypeFees = (decimal)reader["TestTypeFees"];

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


    public static int AddNewTestType(string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
    {
        int NewTestTypeID = -1;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = "Insert into TestTypes(TestTypeTitle,TestTypeDescription,TestTypeFees) values(@TestTypeTitle,@TestTypeDescription,@TestTypeFees) SELECT SCOPE_IDENTITY();";
        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
        cmd.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
        cmd.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

        try
        {
            connection.Open();

            object result = cmd.ExecuteScalar();
            if (result != null && int.TryParse(result.ToString(), out int newID))
            {
                NewTestTypeID=newID;
            }
          
        }
        catch (Exception ex)
        {
           
        }
        finally
        {
            connection.Close();
        }

        return NewTestTypeID;
    }

    public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
    {
         int rowsAffected = -1;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = "Update TestTypes set TestTypeTitle=@TestTypeTitle,TestTypeDescription=@TestTypeDescription,TestTypeFees=@TestTypeFees where TestTypeID=@TestTypeID";
        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
        cmd.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
        cmd.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);   
        cmd.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

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

    public static DataTable GetAllTestTypes()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = "Select * from TestTypes";
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

    public static bool IsTestTypeExists (int TestTypeID)
    {
        bool _Find = false;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = "Select * from TestTypes Where TestTypeID=@TestTypeID";
        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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
    
    public static bool DeleteTestType(int TestTypeID)
    {
        int rowsAffected = -1;
        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = "Delete from TestTypes Where TestTypeID=@TestTypeID";
        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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
