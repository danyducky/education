using Auth.DataLayer.Entities;
using Auth.Shared.Models;
using Common.Magic;
using System.IdentityModel.Tokens.Jwt;

namespace Auth.Shared.Services
{
    public interface ITokenService
    {
        string BuildJwtToken(TokenPayload payload);
        RefreshToken BuildRefreshToken(string ipAddress);
        JwtSecurityToken GetTokenRepresentation(string token);
    }

    public static class TokenServiceExtensions
    {
        public static TokenPack BuildTokenPack(this IHave<ITokenService> context, TokenPayload payload, string ipAddress)
            => new TokenPack(context.Entity.BuildJwtToken(payload), context.Entity.BuildRefreshToken(ipAddress));

        public static string BuildJwtToken(this IHave<ITokenService> context, TokenPayload payload)
            => context.Entity.BuildJwtToken(payload);

        public static RefreshToken BuildRefreshToken(this IHave<ITokenService> context, string ipAddress)
            => context.Entity.BuildRefreshToken(ipAddress);

        public static JwtSecurityToken GetTokenRepresentation(this IHave<ITokenService> context, string token)
            => context.Entity.GetTokenRepresentation(token);
    }
}
