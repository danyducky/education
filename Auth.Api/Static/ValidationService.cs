using Auth.Api.Contexts;
using Auth.Api.Models.Register;
using Auth.DataLayer;
using Auth.DataLayer.Entities;
using Common.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Auth.Api.Static
{
    public static class ValidationService
    {
        public static bool Validate(this AppRequestContext context, RegisterModel model, ModelStateDictionary modelState)
        {
            var encryptedEmail = context.Encrypt(model.Email);
            var user = context.Get<User>()
                .ByEmail(encryptedEmail)
                .FirstOrDefault();

            if (user != null)
                modelState.AddModelError("user", "Пользователь с таким 'Email' уже найден");

            return modelState.IsValid;
        }

        //public static bool Validate(this AppRequestContext context, LoginModel model, ModelStateDictionary modelState)
        //{


        //    return modelState.IsValid;
        //}
    }
}
