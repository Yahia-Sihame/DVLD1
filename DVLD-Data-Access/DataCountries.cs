using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access
{
    public class DataCountries
    {

        public static DataTable AllCountries()
        {
            DataTable dt = new DataTable();
            string query = "select CountryName from countriesz";
            SqlCommand sqlCommand = new SqlCommand(query,GlobalAccesDataBase.conn);
            try
            {
                GlobalAccesDataBase.conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader != null)
                    dt.Load(reader);
                else
                    dt.Load(null);
                reader.Close();
            }
            finally
            {
                GlobalAccesDataBase.conn.Close();
            }
            return dt;
        }

        public static bool FindCountriesByName(string CountryName , ref int CountryId)
        {
            bool isFound = false; 
            string query = "select CountryId from Countries where CountryName = @CountryName";
            SqlCommand sqlCommand = new SqlCommand(query, GlobalAccesDataBase.conn);
            sqlCommand.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                GlobalAccesDataBase.conn.Open();
                object Result = sqlCommand.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int Id))
                {
                    CountryId = Id; 
                    isFound = true;
                }
                else
                {
                    CountryId = -1;
                    isFound = false;
                }
            }
            catch 
            {

            }
            finally
            {
                GlobalAccesDataBase.conn.Close();
            }
            return isFound;
        }

        public static bool FindCountriesById(int CountryId, ref string CountryName)
        {
            bool isFound = false;
            string query = "select CountryName from Countries where CountryId = @CountryId";
            SqlCommand sqlCommand = new SqlCommand(query, GlobalAccesDataBase.conn);
            sqlCommand.Parameters.AddWithValue("@CountryId", CountryId);

            try
            {
                GlobalAccesDataBase.conn.Open();
                object Result = sqlCommand.ExecuteScalar();

                if (Result != null )
                {
                    CountryName = Result.ToString() ;
                    isFound = true;
                }
                else
                {
                    CountryName = string.Empty;
                    isFound = false;
                }
            }
            catch
            {
                
            }
            finally
            {
                GlobalAccesDataBase.conn.Close();
            }
            return isFound;
        }

    }
}
