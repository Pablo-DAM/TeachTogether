using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachTogether.Models;

namespace TeachTogether.Security
{
    public static class AuthenticationManager
    {
        public static LoginData AuthData { get; private set; }

        public static void SaveAuthenticationData(LoginData data)
        {
            AuthData = data;
        }

        public static string GetToken()
        {
            return AuthData?.token?.token;
        }

        public static string GetTokenType()
        {
            return AuthData?.token?.tokenType;
        }

        public static int GetUserId()
        {
            return AuthData?.id ?? 0;
        }
    }
}
