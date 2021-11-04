using Auth.Api.Contexts;
using Auth.Api.Models.Auth;
using Auth.Api.Models.Shared;
using Auth.DataLayer;
using Auth.DataLayer.Entities;
using Auth.Shared.Models;
using Auth.Shared.Services;
using Common.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Auth.Api.Static
{
    public static class AuthService
    {
        public static LoginResult TryLogin(this AppRequestContext context, LoginModel model, string ipAddress, ModelStateDictionary modelState)
        {
            var encryptedEmail = context.Encrypt(model.Email);
            var user = context.Get<User>()
                .ByEmail(encryptedEmail)
                .FirstOrDefault();

            if (user == null || !context.ValidateHash(model.Password, user.Password))
            {
                modelState.AddModelError("user", "Некорректный email или пароль");
                return LoginResult.Invalid;
            }

            var person = context.Get<Person>()
                .ByUserId(user.Id)
                .FirstOrDefault();

            var credential = context.Get<Credential>()
                .ByUserId(user.Id)
                .ToList();

            var payload = new TokenPayload(
                user.Id,
                person.Id,
                credential.Select(c => c.RoleId)
                );

            var pack = context.BuildTokenPack(payload, ipAddress);

            context.Attach(user);

            user.RefreshTokens.Add(pack.RefreshToken);
            
            context.SaveChanges();

            return LoginResult.Valid(pack);
        }

        public static void ForgetToken(this AppRequestContext context, string refreshToken)
        {
            var user = context.Get<User>()
                .ByRefreshToken(refreshToken)
                .FirstOrDefault();

            if (user == null)
                return;

            var token = user.RefreshTokens.First(x => x.Token == refreshToken);

            context.Remove(token);
            context.SaveChanges();
        }
    }
}
