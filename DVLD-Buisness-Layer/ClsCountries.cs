using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access;

namespace DVLD_Buisness_Layer
{
    public class ClsCountries
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public ClsCountries()
        {
            CountryId = 0;
            CountryName= string.Empty;
        }
        public ClsCountries(int CountryId , string CountryName )
        {
            this.CountryId = CountryId ;
            this.CountryName = CountryName ;
        }
        public static DataTable GetAllCountries()
        {
            return DataCountries.AllCountries();
        }

        static public ClsCountries Find(string CountryName)
        {
            int CountryId = -1;
            if (DataCountries.FindCountriesByName(CountryName,ref CountryId))
            {
                return new ClsCountries(CountryId, CountryName);
            }
            else 
                return null;
        }

        static public ClsCountries Find(int CountryId)
        {
            string CountryName = string.Empty;
            if (DataCountries.FindCountriesById(CountryId, ref CountryName))
            {
                return new ClsCountries(CountryId, CountryName);
            }
            else
                return null;
        }
    }
}
