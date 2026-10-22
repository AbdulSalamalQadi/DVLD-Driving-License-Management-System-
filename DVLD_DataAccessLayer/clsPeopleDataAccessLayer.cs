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



        public static bool GetPersonByNationalNo(ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
          string NationalNo, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID
          , ref string ImagePath)

        {
            bool IsFoud = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = @"select *from People
                             where NationalNo=@NationalNo";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue(@"NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    IsFoud = true;

                    PersonID=(int)sqlDataReader["PersonID"];
                    FirstName = (string)sqlDataReader["FirstName"];
                    SecondName = (string)sqlDataReader["SecondName"];

                    ThirdName = (sqlDataReader["ThirdName"] != DBNull.Value) ? (string)sqlDataReader["ThirdName"] : "";
                    Email = (sqlDataReader["Email"] != DBNull.Value) ? (string)sqlDataReader["Email"] : "";
                    ImagePath = (sqlDataReader["ImagePath"] != DBNull.Value) ? (string)sqlDataReader["ImagePath"] : "";

                    LastName = (string)sqlDataReader["LastName"];
                    
                    Address = (string)sqlDataReader["Address"];
                    Phone = (string)sqlDataReader["Phone"];
                    DateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
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



        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName,
            string NationalNo, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, int NationalityCountryID
            , string ImagePath)

        {
            int NewAddedPersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string Query = @"INSERT INTO People
           (NationalNo
           ,FirstName
           ,SecondName
           ,ThirdName
           ,LastName
           ,DateOfBirth
           ,Gender
           ,Address
           ,Phone
           ,Email
           ,NationalityCountryID
           ,ImagePath)
     VALUES
           (@NationalNo 
           ,@FirstName
           ,@SecondName
           ,@ThirdName
           ,@LastName
           ,@DateOfBirth
           ,@Gender
           ,@Address
           ,@Phone
           ,@Email
           ,@NationalityCountryID
           ,@ImagePath)
              select SCOPE_IDENTITY()";

            SqlCommand command =new SqlCommand(Query, connection);

            command.Parameters.AddWithValue(@"FirstName", FirstName);
            command.Parameters.AddWithValue(@"SecondName",SecondName);
             command.Parameters.AddWithValue(@"LastName", LastName);
            command.Parameters.AddWithValue(@"Address", Address);
            command.Parameters.AddWithValue(@"DateOfBirth", DateOfBirth);
             command.Parameters.AddWithValue(@"Gender", Gendor);
             command.Parameters.AddWithValue(@"Phone", Phone);
               command.Parameters.AddWithValue(@"NationalityCountryID", NationalityCountryID);
              command.Parameters.AddWithValue(@"NationalNo", NationalNo);
             



            if (ThirdName != "")
            {
                command.Parameters.AddWithValue(@"ThirdName", ThirdName);
            }
            else 
            { command.Parameters.AddWithValue(@"ThirdName", DBNull.Value); }

            if (Email != "")

            {
                command.Parameters.AddWithValue(@"Email", Email);
            }
            else
            { command.Parameters.AddWithValue(@"Email", DBNull.Value);
            }

            if (ImagePath != "")

            {
                command.Parameters.AddWithValue(@"ImagePath", ImagePath);
            }
            else
            { command.Parameters.AddWithValue(@"ImagePath", DBNull.Value); }

            try
            {
                connection.Open();

                object newId=command.ExecuteScalar();
                if (newId != null&&int.TryParse(newId.ToString(),out int ID))
                {
                     NewAddedPersonID=ID;
                }
                

                connection.Close();

            }
            catch (Exception)
            {

                connection.Close();
            }

            return NewAddedPersonID;
        }
    }
}
