using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.Services
{
    public class DataCryptor : IDataCryptor
    {
        private readonly IConfig config;

        private string CryptKey { get => config.GetValue<string>("CryptKey"); }

        public DataCryptor(IConfig config)
        {
            this.config = config;
        }

        public string Encrypt(string value, string cryptKey = null)
        {
            string EncryptionKey = cryptKey ?? CryptKey;
            byte[] clearBytes = Encoding.Unicode.GetBytes(value);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    value = Convert.ToBase64String(ms.ToArray());
                }
            }
            return value;
        }

        public string Decrypt(string encryptedValue, string cryptKey = null)
        {
            string EncryptionKey = cryptKey ?? CryptKey;
            encryptedValue = encryptedValue.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(encryptedValue);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    encryptedValue = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return encryptedValue;
        }

        public bool Validate(string value, string encryptedValue, string cryptKey = null)
            => Encrypt(value, cryptKey ?? CryptKey) == encryptedValue;
    }
}
