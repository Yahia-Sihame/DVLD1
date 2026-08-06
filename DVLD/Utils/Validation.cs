using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD.Utils
{
    internal class ClsValidation
    {
        public static bool VerificationEmail(string Email)
        {
            string Pattern = @"^[^@\s]+@[^@\s]+\.[^@/s]+$";
            return Regex.IsMatch(Email, Pattern);
        }

        public static bool ValidateNumberInt(string number)
        {
            string Patern = @"^[0-9]*$";
            return Regex.IsMatch(number,Patern);
        }
        public static bool ValidateNumberFloat(string number)
        {
            string Patern = @"^[0-9]*(?:\.[0-9]*)?$";
            return Regex.IsMatch(number, Patern);
        }


    }
}
