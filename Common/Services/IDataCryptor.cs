using Common.Magic;

namespace Common.Services
{
    public interface IDataCryptor
    {
        string Encrypt(string value, string cryptKey = null);
        string Decrypt(string encryptedValue, string cryptKey = null);
        bool Validate(string value, string encryptedValue, string cryptKey = null);
    }

    public static class DataCryptorExtensions
    {
        public static string Encrypt(this IHave<IDataCryptor> context, string value, string cryptKey = null) =>
            context.Entity.Encrypt(value, cryptKey);

        public static string Decrypt(this IHave<IDataCryptor> context, string encryptedValue, string cryptKey = null) =>
            context.Entity.Decrypt(encryptedValue, cryptKey);

        public static bool ValidateCrypto(this IHave<IDataCryptor> context, string value, string encryptedValue, string cryptKey = null) =>
            context.Entity.Validate(value, encryptedValue, cryptKey);
    }
}
