using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Viking.DataAccess
{
    public class Security
    {
        protected readonly IConfiguration _configuration;
        public Security(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreatePasswordHash(string password)
        {
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_configuration["Security:PasswordSalt"])))
            {
                byte[] passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return Convert.ToBase64String(passwordHash);
            }
        }

        public bool VerifyPasswordHash(string passwordInput, string passwordStored)
        {
            byte[] PasswordFromBase = System.Convert.FromBase64String(passwordStored);

            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_configuration["Security:PasswordSalt"])))
            {
                byte[] passwordFromUser = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordInput));

                for (int i = 0; i < passwordFromUser.Length; i++)
                {
                    if (passwordFromUser[i] != PasswordFromBase[i])
                        return false;
                }
            }
            return true;
        }

    }
}
