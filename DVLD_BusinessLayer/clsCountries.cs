using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

public class clsCountries
{
    enum Mode { Addnew = 1, Update = 2 };
    public int CountryID { get; set; }
    public string CountryName { get; set; }
    Mode _Mode { get; set; }
    public clsCountries()
    {
        CountryID = -1;
        CountryName = "";
        _Mode = Mode.Addnew; ;
    }

    private clsCountries(int ID,string CountryName)
    {
         this.CountryID = ID;
         this.CountryName = CountryName;
        _Mode = Mode.Update; 
    }

    public static clsCountries FindByID(int CountryID )
    {
      
        string CountryName = "";

        if(clsCountriesDAL.GetCountryByID(CountryID,ref CountryName))
        {
            return new clsCountries(CountryID, CountryName);
        }
        else
        {
            return null;
        }
    }
    public static clsCountries FindByCountryName(string CountryName)
    {

        int CountryID= -1;

        if (clsCountriesDAL.GetCountryByName(ref CountryID,  CountryName))
        {
            return new clsCountries(CountryID, CountryName);
        }
        else
        {
            return null;
        }
    }

    public static DataTable AllCountries()
    {
        return clsCountriesDAL.GetAllCountries();
    }


}

