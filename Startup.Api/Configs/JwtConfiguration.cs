using Common.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Startup.Api.Configs
{
    public static class JwtConfiguration
    {
        public static void Configure(this JwtBearerOptions options, IConfigurationSection config)
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = config["JwtIssuer"],
                ValidAudience = config["JwtIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtKey"]))
            };
        }
    }
}
