using System;
using System.Security.Cryptography;
using System.Text;

namespace DBSampleCrud
{
    class Encryption
    {

        private static readonly string Key = "1234567890123456";

        // ENC
        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = new byte[16];

                ICryptoTransform encryptor = aes.CreateEncryptor();

                byte[] input = Encoding.UTF8.GetBytes(plainText);
                byte[] encrypted = encryptor.TransformFinalBlock(
                    input, 0, input.Length);

                return Convert.ToBase64String(encrypted);
            }
        }

        // DEC
        public static string Decrypt(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = new byte[16];

                ICryptoTransform decryptor = aes.CreateDecryptor();

                byte[] input = Convert.FromBase64String(cipherText);
                byte[] decrypted = decryptor.TransformFinalBlock(
                    input, 0, input.Length);

                return Encoding.UTF8.GetString(decrypted);
            }

        }
    }
}
