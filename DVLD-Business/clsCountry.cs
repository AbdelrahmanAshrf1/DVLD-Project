using System;
using System.Data;
using System.Data.SqlClient;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsCountry
    {
        public int ID { set; get; }
        public string CountryName { set; get; }
        public string CountryISO { set; get; }
        public clsCountry()

        {
            this.ID = -1;
            this.CountryName = "";
            this.CountryISO = "";
        }

        private clsCountry(int ID, string CountryName,string CountryISO)

        {
            this.ID = ID;
            this.CountryName = CountryName;
            this.CountryISO = CountryISO;
        }

        public static DataTable GetAllCountries()
        {
            return CountryData.GetAllCountries();
        }
        public static clsCountry Find(int CountryID)
        {
            string CountryName = "", CountryISO = "";

            if (CountryData.GetCountryInfoByID(CountryID,ref CountryName, ref CountryISO))
                return new clsCountry(CountryID , CountryName, CountryISO);
            else
                return null;
        }
        public static clsCountry Find(string CountryName)
        {
            int CountryID = -1;
            string CountryISO = "";

            if (CountryData.GetCountryInfoByName(CountryName , ref CountryID , ref CountryISO))
                return new clsCountry(CountryID, CountryName, CountryISO);
           else
                return null;
        }
    }
}
