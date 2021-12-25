using System;
using System.Security.Cryptography;

namespace Task4
{
    class SecureRandom
    {
        public static byte[] GetSecureRandom()
        {
            byte[] secretkey = new Byte[32];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                 rng.GetBytes(secretkey);            
            return secretkey;
        }
    }
}
