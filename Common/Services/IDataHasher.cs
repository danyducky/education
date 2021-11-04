using Common.Magic;

namespace Common.Services
{
    public interface IDataHasher
    {
        string Create(string value, string salt = null);
        bool Validate(string value, string hashedValue, string salt = null);
        string GenerateRandomString();
    }

    public static class DataHasherExtensions
    {
        public static string CreateHash(this IHave<IDataHasher> context, string value, string salt = null) 
            => context.Entity.Create(value, salt);

        public static bool ValidateHash(this IHave<IDataHasher> context, string value, string hashedValue, string salt = null)
            => context.Entity.Validate(value, hashedValue, salt);

        public static string GenerateRandomString(this IHave<IDataHasher> context)
            => context.Entity.GenerateRandomString();
    }
}
