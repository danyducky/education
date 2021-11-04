using Auth.DataLayer.Entities;
using Auth.Shared.Enums;
using Auth.Shared.Models;
using Common.Exceptions;
using Common.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Auth.Shared.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfig config;

        public TokenService(IConfig config)
        {
            this.config = config;
        }

        private string Key { get => config.GetValue<string>("JwtKey"); }
        private string Issuer { get => config.GetValue<string>("JwtIssuer"); }
        private double JwtExpiryMins { get => config.GetValue<double>("JwtExpiryMinutes"); }
        private double RefreshExpiryMins { get => config.GetValue<double>("RefreshExpiryMinutes"); }

        public string BuildJwtToken(TokenPayload payload)
        {
            var accessTokenId = Guid.NewGuid().ToString();
            var stringRoles = string.Join(':', payload.RoleIds);
            var accessTokenClaims = new[]
            {
                new Claim(JwtClaimTypes.Id, accessTokenId),
                new Claim(JwtClaimTypes.UserId, payload.UserId.ToString()),
                new Claim(JwtClaimTypes.PersonId, payload.PersonId.ToString()),
                new Claim(JwtClaimTypes.Roles, stringRoles)
            };

            return BuildToken(accessTokenClaims);
        }

        private string BuildToken(Claim[] claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(Issuer, Issuer, claims,
                                                       expires: DateTime.Now.AddMinutes(JwtExpiryMins),
                                                       signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public RefreshToken BuildRefreshToken(string ipAddress)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    ExpiresIn = DateTime.UtcNow.AddMinutes(RefreshExpiryMins),
                    CreatedAt = DateTime.UtcNow,
                    CreatedByIp = ipAddress
                };
            }
        }

        public JwtSecurityToken GetTokenRepresentation(string token)
        {
            var mySecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidIssuer = Issuer,
                    ValidAudience = Issuer,
                    IssuerSigningKey = mySecurityKey
                }, out SecurityToken validatedToken);

                return (JwtSecurityToken)validatedToken;
            }
            catch
            {
                throw new ForbiddenException();
            }
        }
    }
}
