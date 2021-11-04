using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.Services
{
    public class DataHasher : IDataHasher
    {
        private readonly IConfig config;

        private string HashSalt { get => config.GetValue<string>("HashSalt"); }

        public DataHasher(IConfig config)
        {
            this.config = config;
        }

        public string Create(string value, string salt = null)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                             password: value,
                             salt: Encoding.UTF8.GetBytes(salt ?? HashSalt),
                             prf: KeyDerivationPrf.HMACSHA512,
                             iterationCount: 10000,
                             numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
        }

        public bool Validate(string value, string hashedValue, string salt = null)
            => Create(value, salt ?? HashSalt) == hashedValue;

        public string GenerateRandomString()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }
    }
}
