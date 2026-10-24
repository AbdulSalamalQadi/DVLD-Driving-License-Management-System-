using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DVLD_DataAccessLayer;
using System.Data;


public class clsUsersDAL
    {
         public  static bool GetUserByID(int UserID,  ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
          {
        bool IsFoud = false;
        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
        string query = @"select *from Users
                             where UserID=@UserID";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue(@"UserID", UserID);

        try
        {
            connection.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            if (sqlDataReader.Read())
            {
                IsFoud = true;
                PersonID = (int)sqlDataReader["PersonID"];
                UserName = (string)sqlDataReader["UserName"];

                Password =(string)sqlDataReader["Password"];
                IsActive = (bool)sqlDataReader["IsActive"];
               



            }
            sqlDataReader.Close();

        }
        catch (SqlException ex)
        {


              
        }
        finally
        {
            connection.Close();
        }
        return IsFoud;
    }

        public static bool GetUserByName(ref int UserID, ref int PersonID, string UserName, ref string Password, ref bool IsActive)
    {
        bool IsFoud = false;
        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
        string query = @"select *from Users
                             where UserName=@UserName";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue(@"UserName", UserName);

        try
        {
            connection.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            if (sqlDataReader.Read())
            {
                IsFoud = true;
                UserID = (int)sqlDataReader["PersonID"];
                PersonID = (int)sqlDataReader["PersonID"];
                Password = (string)sqlDataReader["Password"];
                IsActive = (bool)sqlDataReader["IsActive"];




            }
            sqlDataReader.Close();

        }
        catch (SqlException ex)
        {



        }
        finally
        {
            connection.Close();
        }
        return IsFoud;
    }

    public static int AddNewUser(int PersonID, string UserName,  string Password, bool IsActive)
    {

        int NewAddedPersonID = -1;
        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"
INSERT INTO Users
           (PersonID
           ,UserName
           ,Password
           ,IsActive)
     VALUES
           (@PersonID
           ,@UserName
           ,@Password
           ,@IsActive)
           select SCOPE_IDENTITY();"
                                     ;
        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue(@"PersonID", PersonID);
        command.Parameters.AddWithValue(@"UserName", UserName);
        command.Parameters.AddWithValue(@"Password", Password);
        command.Parameters.AddWithValue(@"IsActive", IsActive);

        try
        {
            connection.Open();

            object newId = command.ExecuteScalar();
            if (newId != null && int.TryParse(newId.ToString(), out int ID))
            {
                NewAddedPersonID = ID;
            }




        }
        catch (Exception)
        {


        }
        finally
        {
            connection.Close();
        }

        return NewAddedPersonID;
    }


    public static bool UpdateUser(int UserID,int PersonID, string UserName, string Password, bool IsActive)
    {

        int RowEfficted = -1;
        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"
                                       UPDATE Users
                                          SET PersonID = @PersonID
                                             ,UserName = @UserName
                                             ,Password = @Password
                                             ,IsActive = @IsActive
                                        WHERE UserID=@UserID
                                       "
                                           ;
        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue(@"UserID", UserID);
        command.Parameters.AddWithValue(@"PersonID", PersonID);
        command.Parameters.AddWithValue(@"UserName", UserName);
        command.Parameters.AddWithValue(@"Password", Password);
        command.Parameters.AddWithValue(@"IsActive", IsActive);

        try
        {
            connection.Open();

            RowEfficted = command.ExecuteNonQuery();
        }
        catch (Exception)
        {


        }
        finally
        {
            connection.Close();
        }

        return (RowEfficted > 0);
    }
      public static bool IsUserByUserIDExist(int UserID)
    {

        bool IsFound = false;
        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"select found=1 from Users
                                        WHERE UserID=@UserID
                                       "
                                           ;
        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue(@"UserID", UserID);
      
        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            IsFound = reader.HasRows;

            reader.Close();
        }
        catch (Exception)
        {


        }
        finally
        {
            connection.Close();
        }

        return IsFound;
    }

    public static bool IsUserByUserNameAndPasswordExistForLogin(string UserName,string Password)
    {

        bool IsFound = false;
        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"select found=1 from Users
                                        WHERE UserName=@UserName  and Password=@Password  
                                       "
                                           ;
        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue(@"Password", Password);
         command.Parameters.AddWithValue(@"UserName", UserName);

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            IsFound = reader.HasRows;

            reader.Close();
        }
        catch (Exception)
        {


        }
        finally
        {
            connection.Close();
        }

        return IsFound;
    }
    public static bool DeleteUserByID(int UserID)
    {

        int RowEffc = -1;
        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @" delete from Users
                                        WHERE UserID=@UserID
                                       "
                                           ;
        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue(@"UserID", UserID);
      
        try
        {
            connection.Open();

           RowEffc = command.ExecuteNonQuery();

           
        }
        catch (Exception)
        {


        }
        finally
        {
            connection.Close();
        }

        return ( RowEffc > 0 );
    }

    public static DataTable GetAllUsers()
    {

        DataTable dataTable = new DataTable();

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
        string Query = @"select * from Users ";
        SqlCommand cmd = new SqlCommand(Query, connection);



        try
        {
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                dataTable.Load(reader);
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
        return dataTable;
    }


}
