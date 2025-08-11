using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DVLD_BusinessLayer
{
    public class CryptoManager
    {
        // Hashing
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer;

            using (var rfc2898 = new Rfc2898DeriveBytes(password, 16, 10000))
            {
                salt = rfc2898.Salt;
                buffer = rfc2898.GetBytes(32);
            }

            var hashBytes = new byte[49];

            Buffer.BlockCopy(salt, 0, hashBytes, 1, 16);
            Buffer.BlockCopy(buffer, 0, hashBytes, 17, 32);

            hashBytes[0] = 0x00; // format marker

            return Convert.ToBase64String(hashBytes);
        }
        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;

            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i];
            }
            return result == 0;
        }
        public static bool VerifyPassword(string hashedPassword, string enteredPassword)
        {
            var hashBytes = Convert.FromBase64String(hashedPassword);

            if (hashBytes[0] != 0x00)
                return false;

            var salt = new byte[16];
            Buffer.BlockCopy(hashBytes, 1, salt, 0, 16);
            var storedSubkey = new byte[32];
            Buffer.BlockCopy(hashBytes, 17, storedSubkey, 0, 32);

            using (var rfc2898 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000))
            {
                var generatedSubkey = rfc2898.GetBytes(32);
                return ByteArraysEqual(generatedSubkey, storedSubkey);
            }
        }
        // Encryption / Decryption
        private static readonly string encryptionKey = "12345678901234567890123456789012";
        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aes.GenerateIV(); // Initialization Vector

                byte[] iv = aes.IV;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, iv);

                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

                // Combine IV + encrypted data
                byte[] result = new byte[iv.Length + encryptedBytes.Length];
                Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                Buffer.BlockCopy(encryptedBytes, 0, result, iv.Length, encryptedBytes.Length);

                return Convert.ToBase64String(result);
            }
        }
        public static string Decrypt(string EncryptedText)
        {
            byte[] fullBytes = Convert.FromBase64String(EncryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(encryptionKey);

                // Extract IV (first 16 bytes)
                byte[] iv = new byte[16];
                Buffer.BlockCopy(fullBytes, 0, iv, 0, iv.Length);

                // Extract encrypted data (remaining bytes)
                int encryptedLength = fullBytes.Length - iv.Length;
                byte[] encryptedBytes = new byte[encryptedLength];
                Buffer.BlockCopy(fullBytes, iv.Length, encryptedBytes, 0, encryptedLength);

                // Decrypt
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, iv);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}
