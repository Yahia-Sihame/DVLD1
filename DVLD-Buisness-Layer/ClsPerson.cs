using DVLD_Data_Access; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_Buisness_Layer
{
    public class ClsPerson
    {
        public enum enMode { Add = 0, Update = 1 }

        public enMode Mode = enMode.Add;
        public int PersonId { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public ClsCountries Country {  get; set; }

        
 
        public ClsPerson()
        {
            this.PersonId = -1;
            this.NationalNo = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.DateOfBirth = DateTime.MinValue;
            this.Gendor = 0;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.ImagePath = string.Empty;
            Mode = enMode.Add;
        }

        private ClsPerson(int PersonID, string NationalNo, string FirstName, string SecondName,
                   string ThirdName, string LastName, DateTime DateOfBirth, short Gendor,
                   string Address, string Phone, string Email, int NationalityCountryID,
                   string ImagePath)
        {
            
            this.PersonId = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.ImagePath = ImagePath;
            this.Country = ClsCountries.Find(NationalityCountryID); 

            this.Mode = enMode.Update;
        }

        //Update 
        public ClsPerson(int PersonId)
        {
            this.PersonId = PersonId;
            Mode = enMode.Update;
        }
        
        private bool _AddPerson()
        {
            this.PersonId = DataPerson.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName,
                            LastName, DateOfBirth, Gendor, Address, Phone, Email,
                            NationalityCountryID, ImagePath);
             
            return PersonId != -1;
        }

        private bool _UpdatePerson()
        {
            return DataPerson.UpdatePerson(this.PersonId, this.NationalNo, this.FirstName, this.SecondName,
                                              this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor,
                                              this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }


        public static ClsPerson Find(int PersonID)
        {
            string NationalNo = string.Empty;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            short Gendor = 0;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            string ImagePath = string.Empty;

            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;

            bool isFound = DataPerson.FindPersonById(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                                                        ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email,
                                                        ref NationalityCountryID, ref ImagePath); 
            
            if (isFound)
            {
                return new ClsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName,
                             LastName, DateOfBirth, Gendor, Address, Phone, Email,
                             NationalityCountryID, ImagePath);
            }
            else
                return null;
        }

        public static ClsPerson Find(string NationalNo)
        {
            int PersonId = -1;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            short Gendor = 0;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            string ImagePath = string.Empty;

            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;

            bool isFound = DataPerson.FindPersonByNationalNo(ref PersonId, NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                                                       ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email,
                                                       ref NationalityCountryID, ref ImagePath);

            if (isFound)
            {
                return new ClsPerson(PersonId, NationalNo, FirstName, SecondName, ThirdName,
                             LastName, DateOfBirth, Gendor, Address, Phone, Email,
                             NationalityCountryID, ImagePath);
            }
            else
                return null;
        }

        public static DataTable AllPeople()
        {
            return DataPerson.AllPeaplesData();
        }


        public bool save()
        {
            if (Mode == enMode.Add)
            {
                if (_AddPerson())
                {
                    Mode = enMode.Update;
                    return true;
                }
                else
                    return false;  
            }
            else 
                return _UpdatePerson();
        }

        static public bool DeletePerson(int PersonId)
        {
            return DataPerson.DeletePersonById(PersonId);
        }

        public static bool isPersonExist(int PersonId) 
        {
            return DataPerson.isExistById(PersonId);
        }

        public static bool isPersonExist(string NationalNo)
        {
            bool IsExist = DataPerson.isExistByNationalNo(NationalNo);
            return IsExist;
        }

    }
}
