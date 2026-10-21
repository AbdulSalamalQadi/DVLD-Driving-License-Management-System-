using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public static class clsPeopleDataAccessLayer
    {
        public static bool GetPersonByID( int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
           ref string NationalNo, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID
            , ref string ImagePath)

        {
            bool IsFoud = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString) ;
            string query = @"select *from People
                             where PersonID=@PersonID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue(@"PersonID", PersonID);

            try
            {
                connection.Open();
               SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if(sqlDataReader.Read())
                {
                    IsFoud=true;
                    FirstName = (string)sqlDataReader["FirstName"];
                    SecondName= (string)sqlDataReader["SecondName"];

                    ThirdName = (sqlDataReader["ThirdName"] != DBNull.Value) ? (string)sqlDataReader["ThirdName"] : "";
                    Email = (sqlDataReader["Email"] != DBNull.Value) ? (string)sqlDataReader["Email"] : "";
                    ImagePath = (sqlDataReader["ImagePath"] != DBNull.Value) ?(string)sqlDataReader["ImagePath"] : "";

                    LastName = (string)sqlDataReader["LastName"];
                    NationalNo= (string)sqlDataReader["NationalNo"];
                     Address= (string)sqlDataReader["Address"];
                     Phone= (string)sqlDataReader["Phone"];
                     DateOfBirth= (DateTime)sqlDataReader["DateOfBirth"];
                    Gendor = (byte)sqlDataReader["Gender"];
                       NationalityCountryID = (int)sqlDataReader["NationalityCountryID"];



                }
                sqlDataReader.Close();
                connection.Close();
            }
            catch (SqlException ex)
            {

                connection.Close();
                IsFoud = false;
            }
            return IsFoud;
        }

    }
}
