using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DVLD_Data_Access
{
    public class DataPerson
    {
        public static DataTable AllPeaplesData()
        {
            DataTable dt = new DataTable();
            string query = @"select personId  , NationalNo
                            , FirstName , SecondName  , ThirdName 
                            , LastName , DateOfBirth  , Gendor , case when p.Gendor=0 then 'Male' else 'Female' end as GendorCaption  ,Phone , Email 
                            , c.CountryName  from people  p inner join Countries c on p.NationalityCountryID = c.CountryId ;";

            SqlCommand cmd = new SqlCommand(query, GlobalAccesDataBase.conn);

            try
            {
                GlobalAccesDataBase.conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader != null)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            finally
            {
                GlobalAccesDataBase.conn.Close();
            }
            return dt;
        }

        
        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName,
                                       string LastName, DateTime DateOfBirth, short Gendor, string Address, string Phone,
                                       string Email, int NationalityCountryID, string ImagePath)
        {
            string query = @"INSERT INTO People
                            ( NationalNo, FirstName, SecondName, ThirdName, LastName,
                             DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
                              VALUES
                            ( @NationalNo, @FirstName, @SecondName, @ThirdName, @LastName,
                             @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                              SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(query, GlobalAccesDataBase.conn);

            
            sqlCommand.Parameters.AddWithValue("@NationalNo", NationalNo);
            sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
            sqlCommand.Parameters.AddWithValue("@SecondName", SecondName);
            if (!string.IsNullOrEmpty(ThirdName))
                sqlCommand.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                sqlCommand.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            sqlCommand.Parameters.AddWithValue("@LastName", LastName);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@Gendor", Gendor);
            sqlCommand.Parameters.AddWithValue("@Address", Address);
            sqlCommand.Parameters.AddWithValue("@Phone", Phone);
            if (!string.IsNullOrEmpty(Email))
                sqlCommand.Parameters.AddWithValue("@Email", Email);
            else
                sqlCommand.Parameters.AddWithValue("@Email", DBNull.Value);

            sqlCommand.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (!string.IsNullOrEmpty(ImagePath))
                sqlCommand.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                sqlCommand.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            int PersonId =-1 ;
            try
            {
                GlobalAccesDataBase.conn.Open();

                object result = sqlCommand.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Id))
                {
                    PersonId = Id;
                }
                else
                {
                    PersonId = -1;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                GlobalAccesDataBase.conn.Close();
            }
            return PersonId;
        }

        public static bool UpdatePerson(int PersonId, string NationalNo, string FirstName, string SecondName, string ThirdName,
                               string LastName, DateTime DateOfBirth, short Gendor, string Address, string Phone,
                               string Email, int NationalityCountryID, string ImagePath)
        {
            int rowsAffected = 0;


        string query = @"UPDATE People 
                     SET NationalNo = @NationalNo,
                         FirstName = @FirstName,
                         SecondName = @SecondName,
                         ThirdName = @ThirdName,
                         LastName = @LastName,
                         DateOfBirth = @DateOfBirth,
                         Gendor = @Gendor,
                         Address = @Address,
                         Phone = @Phone,
                         Email = @Email,
                         NationalityCountryID = @NationalityCountryID,
                         ImagePath = @ImagePath
                     WHERE PersonId = @PersonId";

            SqlCommand command = new SqlCommand(query, GlobalAccesDataBase.conn);

            command.Parameters.AddWithValue("@PersonId", PersonId);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (!string.IsNullOrEmpty(ThirdName))
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (!string.IsNullOrEmpty(Email))
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (!string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                GlobalAccesDataBase.conn.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                GlobalAccesDataBase.conn.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool FindPersonById(int PersonId, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
                                       ref string LastName, ref DateTime DateOfBirth , ref short Gendor, ref string Address, ref string Phone,
                                       ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false; 
            string query = "select * from People where PersonId = @PersonId"; 
            SqlCommand sqlCommand = new SqlCommand(query,GlobalAccesDataBase.conn);
            sqlCommand.Parameters.AddWithValue("@PersonId",PersonId);

            try
            {
                GlobalAccesDataBase.conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    NationalNo = reader["NationalNo"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = reader["ThirdName"].ToString();
                    else
                        ThirdName = string.Empty  ;

                    LastName = reader["LastName"].ToString();
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    Gendor = Convert.ToInt16(reader["Gendor"]);
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();
                    if (reader["Email"] != DBNull.Value)
                        Email = reader["Email"].ToString();
                    else
                        Email = string.Empty;

                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = reader["ImagePath"].ToString();
                    else
                        ImagePath = string.Empty;
                }
                else
                    isFound = false;
                reader.Close();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            finally
            {
                GlobalAccesDataBase.conn.Close();
            }
            return isFound;
        }

        public static bool FindPersonByNationalNo(ref int PersonId, string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
                                       ref string LastName, ref DateTime DateOfBirth, ref short Gendor, ref string Address, ref string Phone,
                                       ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;
            string query = "select * from People where NationalNo = @NationalNo";
            SqlCommand sqlCommand = new SqlCommand(query, GlobalAccesDataBase.conn);
            sqlCommand.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                GlobalAccesDataBase.conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                

                if (reader.Read())
                {
                    isFound = true;

                    PersonId = Convert.ToInt32(reader["PersonId"]);
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = reader["ThirdName"].ToString();
                    else
                        ThirdName = string.Empty;

                    LastName = reader["LastName"].ToString();
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    Gendor = Convert.ToInt16(reader["Gendor"]);
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();
                    if (reader["Email"] != DBNull.Value)
                        Email = reader["Email"].ToString();
                    else
                        Email = string.Empty;

                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = reader["ImagePath"].ToString();
                    else
                        ImagePath = string.Empty;
                }
                else
                    isFound = false;
                reader.Close();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            finally
            {
                GlobalAccesDataBase.conn.Close();
            }
            return isFound;
        }

        public static bool DeletePersonById(int PersonId)
        {
            bool isDeleted = false;
            string query = "Delete from People where PersonId = @PersonId";

            SqlCommand sqlCommand = new SqlCommand(query, GlobalAccesDataBase.conn);
            sqlCommand.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                GlobalAccesDataBase.conn.Open();
                int RowAffected = sqlCommand.ExecuteNonQuery();

                if (RowAffected > 0)
                {
                    isDeleted = true;
                }


            }
            catch (Exception ex) 
            {
                throw ex;
            }
            finally
            {
                GlobalAccesDataBase.conn.Close ();
            }
            return isDeleted;
        }

        public static bool isExistById(int PersonId)
        {
            bool isFound = false;
            string query = "select 1 from people where PersonId = @PersonId"; 
            SqlCommand sqlCommand = new SqlCommand( query, GlobalAccesDataBase.conn);
            sqlCommand.Parameters.AddWithValue("@PersonId", PersonId);

            try
            {
                GlobalAccesDataBase.conn.Open();
                object Result = sqlCommand.ExecuteScalar();
                if (Result != null)
                {
                    isFound = true;
                }
                else
                    isFound = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GlobalAccesDataBase.conn.Close();
            }
            return isFound;
        }

        public static bool isExistByNationalNo(string NationalNo)
        {
            bool isFound = false;
            string query = "select 1 from people where NationalNo = @NationalNo";
            SqlCommand sqlCommand = new SqlCommand(query, GlobalAccesDataBase.conn);
            sqlCommand.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                GlobalAccesDataBase.conn.Open();
                object Result = sqlCommand.ExecuteScalar();
                if (Result != null)
                {
                    isFound = true;
                }
                else
                    isFound = false;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            finally
            {
                GlobalAccesDataBase.conn.Close();
            }
            return isFound;
        }

    }
}
