using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.IO;
using DVLD_DataAccessLayer;
using System.Security.Cryptography;

namespace DVLD_BusinessLayer
{
    public class clsPerson
    {
        public enum enMode : byte { AddNew = 0, Update = 1 }
        public enum enGender : byte { Male = 0, Female = 1 }

        public enMode Mode;
        public int ID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }

        public clsCountry CountryInfo;

        private string _ImagePath;
        public string ImagePath 
        {
            get { return _ImagePath; }

            set { _ImagePath = value; } 
        }

        public string FullName()
        {
            return $"{FirstName} {SecondName} {ThirdName} {LastName}";
        }

        public clsPerson()
        {
            ID = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gender = enGender.Male;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = -1;
            ImagePath = "";

            Mode = enMode.AddNew;
        }
        private clsPerson(int ID, string FirstName, string SecondName, string ThirdName, string LastName,
                          string NationalNo, DateTime DateOfBirth, enGender Gender, string Address,
                          string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }

        public static bool IsPersonExist(int ID)
        {
            return PersonData.IsPersonExist(ID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return PersonData.IsPersonExist(NationalNo);
        }

        private bool _AddNewPerson()
        {
            this.ID = PersonData.AddNewPerson(
                this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.NationalNo,
                this.DateOfBirth, (byte)this.Gender, this.Address, this.Phone, this.Email,
                this.NationalityCountryID, this.ImagePath);

            return (this.ID != -1);
        }
        private bool _UpdatePersonInfo()
        {
            return PersonData.UpdatePerson(
                this.ID, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.NationalNo, this.DateOfBirth, (byte)this.Gender,
                this.Address, this.Phone, this.Email,
                  this.NationalityCountryID, this.ImagePath);
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdatePersonInfo();

                default:
                    return false;
            }
        }

        public static clsPerson Find(int PersonID)
        {

            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNo = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;
            byte Gender = 0;

            bool IsFound = PersonData.GetPersonInfoByID
                                (
                                    PersonID, ref FirstName, ref SecondName,
                                    ref ThirdName, ref LastName, ref NationalNo, ref DateOfBirth,
                                    ref Gender, ref Address, ref Phone, ref Email,
                                    ref NationalityCountryID, ref ImagePath
                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName,
                          NationalNo, DateOfBirth, (enGender)Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int PersonID = -1, NationalityCountryID = -1;
            byte Gender = 0;

            bool IsFound = PersonData.GetPersonInfoByNationalNo
                                (
                                    NationalNo, ref PersonID, ref FirstName, ref SecondName,
                                    ref ThirdName, ref LastName, ref DateOfBirth,
                                    ref Gender, ref Address, ref Phone, ref Email,
                                    ref NationalityCountryID, ref ImagePath
                                );

            if (IsFound)

                return new clsPerson(PersonID, FirstName, SecondName, ThirdName, LastName,
                          NationalNo, DateOfBirth, (enGender)Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }

        public static bool HasAssociatedUser(int ID)
        {
            return PersonData.IsPersonAssociatedWithUser(ID);
        }

        public static bool DeletePerson(int ID)
        {
            if(PersonData.DeletePerson(ID))
                return true;
            else
                return false;
        }

        public static DataTable GetAllPeople()
        {
            return PersonData.GetAllPeople();
        }
    }
}
