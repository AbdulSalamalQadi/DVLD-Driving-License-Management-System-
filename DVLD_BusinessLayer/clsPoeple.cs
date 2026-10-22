using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsPeople
    {
        enum Mode { AddNew=1,Update}

        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
         public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gendor { get; set; }
        public  string   Address { get; set; }
        public string  Phone { get; set; }
        public string Email { get; set; }
        public  int NationalityCountryID { get; set; }
        public  string ImagePath { get; set; }
        Mode _Mode;

        public string FullName()
        {
            return FirstName+ " "+SecondName+" "+ThirdName+" "+LastName;
        }
        public clsPeople()
        {
            PersonID = -1;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            NationalNo = "";
            DateOfBirth = DateTime.Now;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = -1;
            ImagePath = "";
                    
            _Mode = Mode.AddNew;
        }




        private bool _AddNewPerson()
        {
         
            this.PersonID = clsPeopleDataAccessLayer.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNo, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
         
           return (this.PersonID!=-1);

        }

        private clsPeople(int PersonID ,string FirstName,string SecondName ,string ThirdName ,string LastName,
            string NationalNo,DateTime DateOfBirth,short Gendor,string Address ,string Phone ,string Email, int NationalityCountryID
            ,string ImagePath)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.DateOfBirth = DateOfBirth;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;

            this.ImagePath = ImagePath;
            this.Gendor= Gendor;

            _Mode = Mode.Update;


        }
        public static clsPeople Find(int PersonID)
        {
         int ID = -1;
         string FirstName = "";
         string SecondName = "";
         string ThirdName = "";
         string LastName = "";
         string NationalNo = "";
           DateTime DateOfBirth = DateTime.Now;
         string Address = "";
         string Phone = "";
         string Email = "";
         int NationalityCountryID = -1;
         string ImagePath = "";
            short Gendor = 0;

            if(clsPeopleDataAccessLayer.GetPersonByID(PersonID, ref  FirstName, ref  SecondName, ref  ThirdName, ref  LastName,
           ref  NationalNo, ref  DateOfBirth, ref  Gendor, ref  Address, ref  Phone, ref  Email, ref  NationalityCountryID
            , ref  ImagePath))
            {
                return new clsPeople(PersonID, FirstName, SecondName, ThirdName, LastName,
             NationalNo, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID
            , ImagePath);
            }
            else
            {
                return null;
            }
        }


        public static clsPeople Find(string NationaltNumber)
        {
            int ID = -1;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
          
            DateTime DateOfBirth = DateTime.Now;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = -1;
            string ImagePath = "";
            short Gendor = 0;

            if (clsPeopleDataAccessLayer.GetPersonByNationalNo(ref ID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
            NationaltNumber, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID
            , ref ImagePath))
            {
                return new clsPeople(ID, FirstName, SecondName, ThirdName, LastName,
             NationaltNumber, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID
            , ImagePath);
            }
            else
            {
                return null;
            }
        }


        public bool Save()
        {
            switch (_Mode)
            {
                case Mode.AddNew:
                    if(_AddNewPerson())
                    {
                        _Mode=Mode.Update;
                        return true;

                    }
                    else
                    {
                        return false;

                    }
                    break;
                case Mode.Update:
                    this._Mode = Mode.Update;
                    return true;
                    break;
                default:
                    break;
            }

            return false;
        }
    }
}
