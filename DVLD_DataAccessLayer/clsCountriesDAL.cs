using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using System.Data.SqlClient;
using System.Data;


    public static class clsCountriesDAL
    {
    public static bool GetCountryByID(int CountryID, ref string CountryName)
    {
        bool IsFound = false;
        SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString);
        string Query = @"select *From Countries
                          Where CountryID=@CountryID";
        SqlCommand cmd = new SqlCommand(Query, con);
        cmd.Parameters.AddWithValue(@"CountryID", CountryID);


        try
        {
          con.Open();
             SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                IsFound = true;
                CountryName = (string)reader["CountryName"];

            }
             reader.Close();
            con.Close();
        }
        catch (Exception)
        {
            IsFound=false;
            con.Close();
        }
        return IsFound;
    }



    public static bool GetCountryByName(ref int CountryID,  string CountryName)
    {
        bool IsFound = false;
        SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString);
        string Query = @"select *From Countries
                          Where CountryName=@CountryName";
        SqlCommand cmd = new SqlCommand(Query, con);
        cmd.Parameters.AddWithValue(@"CountryName", CountryName);


        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                IsFound = true;
                CountryID = (int)reader["CountryID"];

            }
            reader.Close();
            con.Close();
        }
        catch (Exception)
        {
            IsFound = false;
            con.Close();
        }
        return IsFound;
    }

    public static DataTable GetAllCountries()
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(clsDataAccessSetting.ConnectionString);
        string Query = @"select *From Countries
                          ";
        SqlCommand cmd = new SqlCommand(Query, con);

        try
        {
            con.Open();
            SqlDataReader reader =cmd.ExecuteReader();
            if(reader.HasRows)
            {
                dt.Load(reader);
            }
           reader.Close() ;
            
            con.Close();
        }
        
        catch (Exception)
        {
            con.Close() ;
            
        }
        return dt;
    }
}
