using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DVLD.Classes
{
    internal class Global
    {
        public static clsUser CurrentUser;
        public static bool RememberUsernameAndPassword(string Username , string Password)
        {
            try
            {
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
                string FilePath = CurrentDirectory + "\\Data.txt";

                if(Username == "" && File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    return true;
                }

                // concatonate username and passwrod with seperator.
                string DataToSave = Username + "#//#" + Password;

                using(StreamWriter writer = new StreamWriter(FilePath))
                {
                    writer.WriteLine(DataToSave);
                    return true; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured : {ex.Message}");
                return false;
            }
        }
        public static bool GetSortedCredential(ref string Username ,ref string Password)
        {
            string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
            string FilePath = CurrentDirectory + "\\Data.txt";

            try
            {
                if (File.Exists(FilePath))
                {
                    using (StreamReader reader = new StreamReader(FilePath))
                    {
                        string Line = "";
                        while ((Line = reader.ReadLine()) != null)
                        {
                            string[] Result = Line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = Result[0];
                            Password = Result[1];
                        }

                        return true;
                    }
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occured : {ex.Message}");
                return false;
            }
        }
    }
}
