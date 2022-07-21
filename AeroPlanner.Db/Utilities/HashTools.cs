using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Db.Utilities
{
    public class HashTools
    {
        public static byte[] GetSHA256(string input)
        {
            var sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
        }
    }
}
