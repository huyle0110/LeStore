using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeStoreLibrary.Utils
{
    public class Securities
    {
        public const string KeyEncrypt = "Huyle";
        public static string SHA1(string data)
        {
            return BitConverter.ToString(encryptData(string.Join("", data, KeyEncrypt))).Replace("-", "").ToLower();
        }
        static byte[] encryptData(string data)
        {
            System.Security.Cryptography.SHA1CryptoServiceProvider SHA1Hasher = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = SHA1Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
    }
}
