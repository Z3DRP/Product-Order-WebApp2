using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace OdersWebApp.Encryption
{
    public static class Protector
    {
        readonly static byte[] _salty = Encoding.Unicode.GetBytes("7BANANAS");

        public static string Encryptor(string pwd)
        {
            if (string.IsNullOrEmpty(pwd))
                throw new ArgumentException("String is null or empty");

            try
            {
                using (var sha256 = SHA256.Create())
                {
                    var Salted = Combine(Encoding.UTF8.GetBytes(pwd), _salty);
                    var saltyHash = sha256.ComputeHash(Salted);
                    return Convert.ToBase64String(saltyHash);
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public static bool Compare(string encrypted, string str)
        {
            bool isSame;

            if (string.IsNullOrEmpty(encrypted))
                throw new ArgumentException("Encrypted data is null or empty");
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("String data is null or emtpty");

            try
            {
                string enteredString = Encryptor(str);
                isSame = enteredString == encrypted ? true : false;
            }
            catch (Exception ex)
            { throw ex; }

            return isSame;
        }
        private static byte[] Combine(byte[] first, byte[] second)
        {
            var byts = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, byts, 0, first.Length);
            Buffer.BlockCopy(second, 0, byts, first.Length, second.Length);

            return byts;
        }
    }
}
