using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Quiz
{
    static class Check_password_Email    //робимо перевірку на пароль і логін
    {
        static Regex regex; // клас для регулярних виразів
        static public bool CheckPassword(string password)
        {
            string namepatern = @"^[a-zA-Z0-9]{8,14}$";
            regex = new Regex(namepatern);
            if (regex.IsMatch(password))
            {
                Console.WriteLine("Vse ok P");
                return true;
            }
            return false;
        }
        static public bool CheckEmail(string email)
        {
            string namepatern = @"^([a-z0-9]{3,15})[@][a-z]{2,7}.[a-z]{2,6}$";
            regex = new Regex(namepatern);
          
            if (regex.IsMatch(email))
            {
                Console.WriteLine("Vse ok L");
                return true;
            }
            return false;
        }
       
    }
}
