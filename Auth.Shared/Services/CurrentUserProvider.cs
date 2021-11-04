using Auth.Shared.Enums;
using Auth.Shared.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace Auth.Shared.Services
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        private CurrentUserModel Cache;

        public CurrentUserModel CurrentUser
        {
            get
            {
                if (Cache != null)
                    return Cache;

                var user = httpContextAccessor.HttpContext.User;

                var userId = Guid.Parse(user.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.UserId).Value);
                var personId = Guid.Parse(user.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.PersonId).Value);

                var roleClaimType = ((ClaimsIdentity)user.Identity).RoleClaimType;
                var roles = user.Claims
                    .Where(x => x.Type == roleClaimType)
                    .Select(c => Guid.Parse(c.Value))
                    .ToList();

                return Cache = new CurrentUserModel(userId, personId, roles);
            }
        }
    }
}
