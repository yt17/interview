using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.HashingHelper
{    
        public class HashingHelper
        {
            public static void CreatePasswordHash(string password, out byte[] passworHash, out byte[] passwordSalt)
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passworHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                }
            }

            public static bool VerifyPasswordHash(string password, byte[] passworHash, byte[] passwordSalt)
            {
                using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
                {
                    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != passworHash[i])
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }
        }
}