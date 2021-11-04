using Auth.DataLayer.Entities;

namespace Auth.Shared.Models
{
    public class TokenPack
    {
        public TokenPack(string accessToken, RefreshToken refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public string AccessToken { get; }
        public RefreshToken RefreshToken { get; }
    }
}
