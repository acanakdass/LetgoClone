using System;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt) 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = Convert.ToBase64String(hmac.Key);
                passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

        public static bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
        {
            var pwHashByte = Convert.FromBase64String(passwordHash);
            var pwSaltByte = Convert.FromBase64String(passwordSalt);
            
            using (var hmac = new System.Security.Cryptography.HMACSHA512(pwSaltByte))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=pwHashByte[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
