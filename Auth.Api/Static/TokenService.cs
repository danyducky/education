using Auth.Api.Contexts;
using Auth.DataLayer;
using Auth.DataLayer.Entities;
using Auth.Shared.Models;
using Auth.Shared.Services;
using Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Auth.Api.Static
{
    public static class TokenService
    {
        public static TokenPack TryRefreshToken(this AppRequestContext context, string token, string ipAddress)
        {
            var user = context.Get<User>()
                .ByRefreshToken(token)
                .Include(x => x.Person)
                .FirstOrDefault();

            if (user == null)
                throw new ForbiddenException();

            var refreshToken = user.RefreshTokens.First(r => r.Token == token);

            context.Remove(refreshToken);

            var roles = context.Get<Credential>()
                .ByUserId(user.Id)
                .Select(x => x.RoleId)
                .AsEnumerable();

            var pack = context.BuildTokenPack(
                new TokenPayload(user.Id, user.Person.Id, roles),
                ipAddress
            );

            context.Attach(user);

            user.RefreshTokens.Add(pack.RefreshToken);
            
            context.SaveChanges();

            return pack;
        }
    }
}
