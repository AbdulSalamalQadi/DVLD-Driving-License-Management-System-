using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using System.Data.SqlClient;
using System.Data;


    public class clsLicenseClassesDAL
    {



           public static bool GetLicenseClassID(int LicesneClassID, ref string ClassName, ref string ClassDescription,ref 
                  short  MinimumAllowedAge,ref short DefaultValidityLength, ref decimal ClassFees)
           { 
                     bool _Find = false;
                    
                     SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
                    
                     string Query = @"Select * from LicenseClasses 
                                      Where LicenseClassID=@LicenseClassID";
                    
                     SqlCommand cmd = new SqlCommand(Query, connection);

                     cmd.Parameters.AddWithValue("@LicenseClassID", LicesneClassID);
                    
                     try
                     {
                         connection.Open();
                    
                         SqlDataReader reader = cmd.ExecuteReader();
                    
                         if (reader.Read())
                         {
                             _Find = true;
                    
                             ClassName = (string)reader["ClassName"];
                             ClassDescription = (string)reader["ClassDescription"];
                             MinimumAllowedAge = (short)reader["MinimumAllowedAge"];
                             DefaultValidityLength = (short)reader["DefaultValidityLength"];
                             ClassFees = (decimal)reader["ClassFees"];
                    
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


           public static int AddNewLicenseClass(string ClassName, string ClassDescription, short MinimumAllowedAge, short DefaultValidityLength, decimal ClassFees)
          {
                         int NewLicenseClassID = -1;
                        
                         SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
                        
                         string Query = @"Insert into LicenseClasses (ClassName,ClassDescription,MinimumAllowedAge,DefaultValidityLength,ClassFees) 
                                          values
                                                      (@ClassName,@ClassDescription,@MinimumAllowedAge,@DefaultValidityLength,@ClassFees)  
                                                     SELECT SCOPE_IDENTITY();";
                        
                         SqlCommand cmd = new SqlCommand(Query, connection);

                         cmd.Parameters.AddWithValue("@ClassName", ClassName);
                         cmd.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                         cmd.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
                         cmd.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
                         cmd.Parameters.AddWithValue("@ClassFees", ClassFees);
                        
                         try
                         {
                             connection.Open();
                        
                             object result = cmd.ExecuteScalar();
                             if (result != null && int.TryParse(result.ToString(), out int newID))
                             {
                                 NewLicenseClassID = newID;
                             }
                           
                         }
                         catch (Exception)
                         {
                            
                         }
                         finally
                         {
                             connection.Close();
                         }

        return NewLicenseClassID;
    }

    public static bool UpdateLicenseClass(int LicenseClassID, string ClassName, string ClassDescription, short MinimumAllowedAge, short DefaultValidityLength, decimal ClassFees)
    {
         int rowsAffected = -1;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"Update LicenseClasses 
                   set ClassName=@ClassName,
                       ClassDescription=@ClassDescription,
                       MinimumAllowedAge=@MinimumAllowedAge,
                       DefaultValidityLength=@DefaultValidityLength,
                     ClassFees=@ClassFees 
                              where 
                      LicenseClassID=@LicenseClassID";
        SqlCommand cmd = new SqlCommand(Query, connection);


        cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
        cmd.Parameters.AddWithValue("@ClassName", ClassName);
        cmd.Parameters.AddWithValue("@ClassDescription", ClassDescription);
        cmd.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
        cmd.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
        cmd.Parameters.AddWithValue("@ClassFees", ClassFees);

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

    public static DataTable GetAllLicenseClasses()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"Select * from LicenseClasses";
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

    public static bool IsLicenseClassExists (int LicenseClassID)
    {
        bool _Find = false;

        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

                      string Query = @"Select * from LicenseClasses
                    Where LicenseClassID=@LicenseClassID";

        SqlCommand cmd = new SqlCommand(Query, connection);
        cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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
    
    public static bool DeleteLicenseClass(int LicenseClassID)
    {
        int rowsAffected = -1;
        SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

        string Query = @"Delete from LicenseClasses 
                          Where LicenseClassID=@LicenseClassID";
        SqlCommand cmd = new SqlCommand(Query, connection);
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

