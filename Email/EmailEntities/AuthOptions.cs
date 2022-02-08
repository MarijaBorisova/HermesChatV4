using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Email
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // token publisher
        public const string AUDIENCE = "MyAuthClient"; // token user
        const string KEY = "mysupersecret_secretkey!123";   // crypted key
        public const int LIFETIME = 1; // token lifetime- 1 sec
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}