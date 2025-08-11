using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using PhoneNumbers;

namespace DVLD.Global_Classes
{
    public class Validation
    {
        public static bool ValidateEmail(string email)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        public static bool ValidateInteger(string Number)
        {
            return int.TryParse(Number, out _);
        }
        public static bool ValidateFloat(string Number)
        {
            return float.TryParse(Number, out _);
        }
        public static bool IsNumber(string Number)
        {
            return (ValidateInteger(Number) || ValidateFloat(Number));
        }

        public static bool ValidatePhoneNumber(string phoneNumberInput ,string countryISO,out string errorMessage)
        {
            errorMessage = "";

            try
            {
                PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
                PhoneNumber number = phoneNumberUtil.Parse(phoneNumberInput, countryISO);

                if(!phoneNumberUtil.IsValidNumber(number))
                {
                    errorMessage = "Invalid phone number for the selected country.";
                    return false;
                }

                return true;
            }
            catch(NumberParseException)
            {
                errorMessage = "Phone number format is invalid.";
                return false;
            }
        }
    }
}
