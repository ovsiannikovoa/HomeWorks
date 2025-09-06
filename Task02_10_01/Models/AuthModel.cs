using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_10_01.Models
{
    public static class AuthModel
    {
        public const string ValidUsername = "admin";
        public const string ValidPassword = "12345";

        public static bool Authenticate(string username, string password)
        {
            return username == ValidUsername && password == ValidPassword;
        }
    }
}