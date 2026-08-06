using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access
{
    public class DataUser
    {
        public static DataTable GetAllDataUsers()
        {
            DataTable dataTable = new DataTable();
            string query = @"SELECT u.UserID, u.PersonID,
                           (ISNULL(p.FirstName, '') + ' ' +
                            ISNULL(p.SecondName, '') + ' ' +
                            ISNULL(p.ThirdName, '') + ' ' +
                            ISNULL(p.LastName, '')) AS FullName,
                           u.UserName, u.Password, u.IsActive
                            FROM Users u
                            INNER JOIN People p ON u.PersonID = p.PersonID;";


            SqlCommand sqlCommand = new SqlCommand(query, GlobalAccesDataBase.conn);

            try
            {
                GlobalAccesDataBase.conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)  
                    {
                        dataTable.Load(reader);
                    }
                    else
                    {
                        dataTable = new DataTable();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally
            {
                GlobalAccesDataBase.conn.Close();
            }

            return dataTable;
        }


        public static bool IsUserExist(int UserId)
        {
            bool isExist = false;
            string query = "select 1 from users where UserID = @UserId;";
            SqlCommand comm = new SqlCommand(query, GlobalAccesDataBase.conn);
            comm.Parameters.AddWithValue("@UserId", UserId);

            try
            {
                GlobalAccesDataBase.conn.Open();
                object Result = comm.ExecuteScalar();
                if (Result != null)
                {
                    isExist = true;
                }
                else
                    isExist = false; 
            }
            catch
            {

            }
            finally
            {
                GlobalAccesDataBase.conn.Close();
            }
            return isExist;
        }

        public static bool IsUserExist(string UserName)
        {
            bool isExist = false;
            string query = "select 1 from users where userName = @UserName;";
            SqlCommand comm = new SqlCommand(query, GlobalAccesDataBase.conn);
            comm.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                GlobalAccesDataBase.conn.Open();
                object Result = comm.ExecuteScalar();
                if (Result != null)
                {
                    isExist = true;
                }
                else
                    isExist = false;
            }
            catch
            {

            }
            finally
            {
                GlobalAccesDataBase.conn.Close();
            }
            return isExist;
        }

        public static bool IsUserExistForPersonId(int personId)
        {
            bool isExist = false;

            string query = @"SELECT COUNT(*) 
                     FROM Users 
                     WHERE PersonId = @PersonId";

            SqlCommand cmd = new SqlCommand(query, GlobalAccesDataBase.conn);
            
                cmd.Parameters.AddWithValue("@PersonId", personId);

                try
                {
                    GlobalAccesDataBase.conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    isExist = (count > 0);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error checking user existence by PersonId: " + ex.Message);
                }
                finally
                {
                    GlobalAccesDataBase.conn.Close();
                }

            return isExist;
        }


        public static bool GetUserInfoByUserId(int userId, ref int personId, ref string userName, ref string password, ref bool isActive)
        {
            bool isFound = false;

            string query = @"SELECT PersonId , UserName, Password, IsActive 
                     FROM Users 
                     WHERE UserId = @UserId";

            SqlCommand sqlCommand = new SqlCommand(query, GlobalAccesDataBase.conn);
            sqlCommand.Parameters.AddWithValue("@UserId", userId);

            try
            {
                GlobalAccesDataBase.conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    personId = Convert.ToInt32(reader["PersonId"]);
                    userName = reader["UserName"].ToString();
                    password = reader["Password"].ToString();
                    isActive = Convert.ToBoolean(reader["IsActive"]);
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

            return isFound;
        }

        public static bool GetUserInfoByPersonId(ref int userId,  int personId, ref string userName, ref string password, ref bool isActive)
        {
            bool isFound = false;

            string query = @"SELECT UserId, UserName, Password, IsActive 
                     FROM Users 
                     WHERE PersonId = @PersonId";

            SqlCommand sqlCommand = new SqlCommand(query, GlobalAccesDataBase.conn);
            sqlCommand.Parameters.AddWithValue("@PersonId", userId);

            try
            {
                GlobalAccesDataBase.conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    userId = Convert.ToInt32(reader["UserId"]);
                    userName = reader["UserName"].ToString();
                    password = reader["Password"].ToString();
                    isActive = Convert.ToBoolean(reader["IsActive"]);
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

            return isFound;
        }

        public static bool IsUserExistByUsernameAndPassword(string userName, string password)
        {
            bool isExist = false;
            string query = @"SELECT COUNT(*) FROM Users WHERE UserName = @UserName AND Password = @Password";

            using (SqlCommand cmd = new SqlCommand(query, GlobalAccesDataBase.conn))
            {
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);

                GlobalAccesDataBase.conn.Open();
                int count = (int)cmd.ExecuteScalar();
                GlobalAccesDataBase.conn.Close();

                isExist = (count > 0);
            }

            return isExist;
        }

        public static void GetUserInfoByUsernameAndPassword(ref int userId, ref int personId, string userName , string password , ref bool isActive)
        {
            string query = @"SELECT u.UserID, u.PersonID, u.IsActive
                     FROM Users u
                     WHERE u.UserName = @UserName AND u.Password = @Password";

            using (SqlCommand cmd = new SqlCommand(query, GlobalAccesDataBase.conn))
            {
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);

                GlobalAccesDataBase.conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    userId = Convert.ToInt32(reader["UserID"]);
                    personId = Convert.ToInt32(reader["PersonID"]);
                    isActive = Convert.ToBoolean(reader["IsActive"]);
                }

                reader.Close();
                GlobalAccesDataBase.conn.Close();
            }
        }



        public static int AddUser(int PersonId,  string userName, string Password, bool IsActive)
        {
            int userId = -1;

            string query = @"INSERT INTO Users (PersonId , UserName, Password, IsActive) 
                     VALUES (@PersonId, @UserName, @Password, @IsActive);
                     SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(query, GlobalAccesDataBase.conn);

            sqlCommand.Parameters.AddWithValue("@PersonId", PersonId);
            sqlCommand.Parameters.AddWithValue("@UserName", userName);
            sqlCommand.Parameters.AddWithValue("@Password", Password);
            sqlCommand.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                GlobalAccesDataBase.conn.Open();
                object result = sqlCommand.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    userId = id;
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally
            {
                GlobalAccesDataBase.conn.Close();
            }

            return userId;
        }


        public static bool UpdateUser(int UserId, int PersonId , string userName, string Password, bool IsActive)
        {
            int rowsAffected = 0;

            string query = @"UPDATE Users 
                     SET PersonId = @PersonId,
                         UserName = @UserName,
                         Password = @Password,
                         IsActive = @IsActive
                     WHERE UserId = @UserId";

            SqlCommand sqlCommand = new SqlCommand(query, GlobalAccesDataBase.conn);

            sqlCommand.Parameters.AddWithValue("@UserId", UserId);
            sqlCommand.Parameters.AddWithValue("@PersonId", PersonId);
            sqlCommand.Parameters.AddWithValue("@UserName", userName);
            sqlCommand.Parameters.AddWithValue("@Password", Password);
            sqlCommand.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                GlobalAccesDataBase.conn.Open();
                rowsAffected = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally
            {
                GlobalAccesDataBase.conn.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteUser(int UserId)
        {
            int rowsAffected = 0;

            string query = "DELETE FROM Users WHERE UserId = @UserId";

            SqlCommand sqlCommand = new SqlCommand(query, GlobalAccesDataBase.conn);
            sqlCommand.Parameters.AddWithValue("@UserId", UserId);

            try
            {
                GlobalAccesDataBase.conn.Open();
                rowsAffected = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GlobalAccesDataBase.conn.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool ChangePassword(int UserId , int NewPassword)
        {
            bool IsChange = false;
            string query = "Update Users set Password = @NewPassword where UserId = @UserId";
            SqlCommand sqlCommand = new SqlCommand(query , GlobalAccesDataBase.conn);

            sqlCommand.Parameters.AddWithValue("@NewPassword" , NewPassword); 
            sqlCommand.Parameters.AddWithValue("@UserId", UserId);

            try
            {
                GlobalAccesDataBase.conn.Open();

                int RowAffected = sqlCommand.ExecuteNonQuery(); 
                if (RowAffected > 0)
                {
                    IsChange = true; 
                }
            }
            catch 
            {
                
            }
            finally
            {
                GlobalAccesDataBase.conn.Close() ;
            }
            return IsChange;
        }

       



    }
}
