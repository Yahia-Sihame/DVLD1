using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DVLD_Data_Access;

namespace DVLD_Buisness_Layer
{
    public class ClsUser
    {
       public  enum enMode { Add = 1 , Update = 2}
        public enMode Mode = enMode.Add;

        public int UserId;
        public int PersonId;
        public ClsPerson Person  = new ClsPerson();
        public string UserName; 
        public string Password;
        public bool IsActive;


        public ClsUser()
        {
            UserId = -1;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = true; 
            Mode = enMode.Add;
        }

        public ClsUser(int userId)
        {
            UserId = userId;
            PersonId = -1;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = true;  
            Mode = enMode.Update; 
        }

        public ClsUser(int userId, int personId, string userName, string password, bool isActive)
        {
            UserId = userId;
            PersonId = personId;
            Person = ClsPerson.Find(personId);
            UserName = userName;
            Password = password;
            IsActive = isActive;
            Mode = enMode.Update;
        }


        public static ClsUser FindUserByUserId(int userId)
        {
            bool isExist = DataUser.IsUserExist(userId);
            int PersonId = -1;
            string FullName = string.Empty;
            string UserName = string.Empty;
            string Password = string.Empty;
            bool IsActive = true;

            if (isExist)
            {
                DataUser.GetUserInfoByUserId(userId, ref  PersonId, ref  UserName, ref  Password, ref  IsActive);
                return new ClsUser(userId, PersonId, UserName,Password,IsActive);
            }
            else
                return null;
        }
        public static ClsUser FindUserByPersonId(int PersonId)
        {
            bool isExist = DataUser.IsUserExist(PersonId);
            int UserId = -1;
            string UserName = string.Empty;
            string Password = string.Empty;
            bool IsActive = true;

            if (isExist)
            {
                DataUser.GetUserInfoByPersonId(ref UserId, PersonId,  ref UserName, ref Password, ref IsActive);
                return new ClsUser(UserId, PersonId, UserName, Password, IsActive);
            }
            else
                return null;
        }
        public static ClsUser FindUserByUsernameAndPassword(string UserName, string Password)
        {
            bool isExist = DataUser.IsUserExistByUsernameAndPassword(UserName,Password);
            int UserId = -1;
            int PersonId = -1; 
            bool IsActive = true;


            if (isExist)
            {
                DataUser.GetUserInfoByUsernameAndPassword(ref UserId, ref PersonId, UserName, Password, ref IsActive);
                return new ClsUser(UserId, PersonId, UserName, Password, IsActive); 
            }
            else 
                 return null;
        }
        public static ClsUser FindUserInfoByUsernameAndPassword(string UserName, string Password)
        {
            int UserId = -1;
            int PersonId = -1;
            string FullName = string.Empty;
            bool IsActive = false;

            bool isExist = DataUser.IsUserExistByUsernameAndPassword(UserName, Password);

            if (isExist)
            {
                DataUser.GetUserInfoByUsernameAndPassword(ref UserId, ref PersonId, UserName , Password ,ref IsActive);
                return new ClsUser(UserId, PersonId, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
        }



        private bool _UpdateUser()
        {
            return DataUser.UpdateUser(UserId, PersonId, UserName, Password, IsActive);
        }
        private bool _AddUser()
        {
            int UserId = DataUser.AddUser(PersonId,UserName,Password,IsActive); 

            return UserId != -1; 
        }
        public static bool DeleteUser(int UserId)
        {
            return DataUser.DeleteUser(UserId);
        }

        public bool Save()
        {
            if ( this.Mode == enMode.Update )
            {
                if ( this._UpdateUser() == true )
                {
                    return true;
                }
                else 
                    return false;
            }
            else
            {
                if (this._AddUser() == true)
                {
                    this.Mode = enMode.Update;
                    return true;
                }
                else
                    return false;
            }
        }



        public static bool IsUserExist(int userId)
        {
            return DataUser.IsUserExist(userId);
        }
        public static bool IsUserExist(string UserName)
        {
            return DataUser.IsUserExist(UserName);
        }
        public static bool IsUserExistForPersonId(int personId)
        {
            return DataUser.IsUserExistForPersonId((int)personId);
        }


        public static DataTable GetAllUsers()
        {
            return DataUser.GetAllDataUsers();
        }
    }
}
