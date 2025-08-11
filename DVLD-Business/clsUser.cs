using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.IO;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo;
        public string Username { get; set; }
        public string Password { get; set; }

        private string _originalHashedPassword;
        public bool IsActive { get; set; }
        public clsUser()
        {
            this.ID = -1;
            this.PersonID = -1;
            this.Username = "";
            this.Password = "";
            this.IsActive = false;
            Mode = enMode.AddNew;
        }

        public clsUser(int ID ,int PersonID, string Username, string Password,bool IsActive)
        {
            this.ID = ID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.Username = Username;
            this.Password = Password;
            this._originalHashedPassword = Password;
            this.IsActive = IsActive;
            Mode = enMode.Update;
        }
        private bool _AddNewUser()
        {
            this.Password = CryptoManager.HashPassword(this.Password);
            this.ID = UserData.AddNewUser(this.PersonID, this.Username, this.Password, this.IsActive);
            return (this.ID != -1);
        }
        private bool _UpdateUserInfo()
        {
            if(this.Password != _originalHashedPassword)
                this.Password = CryptoManager.HashPassword(this.Password);
            
            return UserData.UpdateUser(this.ID ,this.PersonID, this.Username, this.Password, this.IsActive);
        }
        public static clsUser FindByUserID(int ID)
        {
            int PersonID = -1;
            bool IsActive = false;
            string Username = "", Password = "";

            bool IsFound = UserData.GetUserInfoByUserID(ID,ref PersonID,ref Username,ref Password,ref IsActive);

            if (IsFound)
                return new clsUser(ID, PersonID, Username, Password, IsActive);
            else
                return null;
        }
        public static clsUser FindByPersonID(int ID)
        {
            int UserID = -1;
            bool IsActive = false;
            string Username = "", Password = "";

            bool IsFound = UserData.GetUserInfoByPersonID(ID, ref UserID, ref Username, ref Password, ref IsActive);

            if (IsFound)
                return new clsUser(UserID, ID, Username, Password, IsActive);
            else
                return null;
        }
        public static clsUser FindByUsernameAndPassword(string Username, string Password)
        {
            int UserID = -1;
            int PersonID = -1;

            bool IsActive = false;

            bool IsFound = UserData.GetUserInfoByUsername(Username,ref Password, ref UserID, ref PersonID, ref IsActive);

            if (IsFound)
                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            else
                return null;
        }
        public static clsUser Authenticate(string Username, string EnteredPassword)
        {
            int UserID = -1,PersonID = -1;
            bool IsActive = false;
            string StoredHashPassword = "";

            bool IsFound = UserData.GetUserInfoByUsername(Username,ref StoredHashPassword, ref UserID, ref PersonID, ref IsActive);

            if (!IsFound) return null;

             if(CryptoManager.VerifyPassword(StoredHashPassword, EnteredPassword))
                return new clsUser(UserID, PersonID, Username, EnteredPassword, IsActive);
           
            return null;
        }
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateUserInfo();

                default:
                    return false;
            }
        }
        public static bool DeleteUser(int ID)
        {
            if (UserData.DeleteUser(ID))
                return true;
            else
                return false;
        }
        public static DataTable GetAllUsers()
        {
            return UserData.GetAllUsers();
        }
        public static bool IsUserExist(string username)
        {
            return UserData.IsUserExist(username);
        }
        public static bool IsUserExist(int ID)
        {
            return UserData.IsUserExist(ID);
        }
        public static bool IsUserExistForPersonID(int PersonID)
        {
            return UserData.IsUserExistForPersonID(PersonID);
        }
    }
}
