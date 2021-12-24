using System;
using System.Security.Cryptography;

namespace Task4
{
    class GameHMAC
    {
        public static byte[] HashHMAC(byte[] key,byte[] message)
        {            
            var hash = new HMACSHA256(key);//SHA2
            return hash.ComputeHash(message);
        }
        
    }
}
