using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using System.Data.SqlClient;
using System.Data;


     public class clsTestsResultDAL
    {

    public static bool GetTestResultByID(int TestID ,ref int TestAppointmentID,ref short TestResult ,ref string Notes,ref int CreateByUserID)
    {
        bool _Find = false;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = "Select * from Tests Where TestID=@TestID";
        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@TestID", TestID);

        try
        {
            connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                _Find = true;

                TestAppointmentID = (int)reader["TestAppointmentID"];
                Notes = (reader["Notes"]!=DBNull.Value) ? (string)reader["Notes"] :"";
                TestResult = Convert.ToInt16(reader["TestResult"]);
                CreateByUserID = (int)reader["CreatedByUserID"];

            }
            else
            {
                _Find = false;
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
        return _Find;

    }



    public static int AddNewTestsResult(int TestAppointmentID, short TestResult, string Notes, int CreatedByUserID)
    {
        int NewTestsResultID = -1;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"Insert into Tests (TestAppointmentID,TestResult,Notes,CreatedByUserID) 
                                          values
                                                      (@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID)  
                                                     SELECT SCOPE_IDENTITY();";

        SqlCommand cmd = new SqlCommand(Query, connection);

        cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
        cmd.Parameters.AddWithValue("@TestResult", TestResult);

        if(Notes!="")
        cmd.Parameters.AddWithValue("@Notes", Notes);
        else
            cmd.Parameters.AddWithValue("@Notes", DBNull.Value);


        cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
        try
        {
            connection.Open();

            object result = cmd.ExecuteScalar();
            if (result != null && int.TryParse(result.ToString(), out int newID))
            {
                NewTestsResultID = newID;
            }

        }
        catch (Exception)
        {

        }
        finally
        {
            connection.Close();
        }

        return NewTestsResultID;
    }

    public static bool UpdateTestsResult(int TestID,short TestResult, string Notes, int CreatedByUserID)
    {
        int rowsAffected = -1;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"Update Tests
                   set 
                       TestResult =@TestResult,
                       Notes=@Notes,
                       CreatedByUserID = @CreatedByUserID
                              where 
                      TestsID=@TestID";
        SqlCommand cmd = new SqlCommand(Query, connection);

        cmd.Parameters.AddWithValue("@TestID", TestID);
        cmd.Parameters.AddWithValue("@TestResult", TestResult);

        if (Notes != "")
            cmd.Parameters.AddWithValue("@Notes", Notes);
        else
            cmd.Parameters.AddWithValue("@Notes", DBNull.Value);


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

    public static DataTable GetAllTestsResultes()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"Select * from Tests";
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

    public static bool IsTestsResultExists(int TestsResultID)
    {
        bool _Find = false;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"Select found=1 from Tests
                                            Where 
                                    TestID=@TestsResultID";

        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@TestsResultID", TestsResultID);

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

}
