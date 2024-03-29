﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AesEncryptionNamespace
{
    public class AesEncryption
    {
        private readonly byte[] Key = Encoding.UTF8.GetBytes("$AES256@ENCRYPT$");
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("$AES256@DECRYPT$");

        public string Encrypt(string password)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                        csEncrypt.Write(passwordBytes, 0, passwordBytes.Length);
                    }

                    byte[] encryptedBytes = msEncrypt.ToArray();
                    string encryptedPassword = Convert.ToBase64String(encryptedBytes);
                    return encryptedPassword;
                }
            }
        }

        public string Decrypt(string encryptedPassword)
        {
            byte[] cipherText = Convert.FromBase64String(encryptedPassword);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            byte[] decryptedBytes = new byte[cipherText.Length];
                            int bytesRead = csDecrypt.Read(decryptedBytes, 0, decryptedBytes.Length);
                            string decryptedPassword = Encoding.UTF8.GetString(decryptedBytes, 0, bytesRead);
                            return decryptedPassword;
                        }
                    }
                }
            }
        }
    }
}
