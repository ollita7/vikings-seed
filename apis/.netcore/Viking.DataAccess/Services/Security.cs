using System.Text;

namespace Viking.DataAccess
{
    public class Security
    {
        public string CreatePasswordHash(string password)
        {
            //TODO::
            string passwordSalt = "Viking-seed-Salt";

            using (var hmac = new System.Security.Cryptography.HMACSHA512(Encoding.UTF8.GetBytes(passwordSalt)))
            {
                byte[] passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Encoding.UTF8.GetString(passwordHash);
            }
        }

        public bool VerifyPasswordHash(string password)
        {
            //TODO::
            string passwordSalt = "Viking-seed-Salt";
            byte[] passwordHash = Encoding.UTF8.GetBytes(password);

            using (var hmac = new System.Security.Cryptography.HMACSHA512(Encoding.UTF8.GetBytes(passwordSalt)))
            {
                byte[] ComputeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < ComputeHash.Length; i++)
                {
                    if (ComputeHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

    }
}
