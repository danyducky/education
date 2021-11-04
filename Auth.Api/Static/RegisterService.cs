using Auth.Api.Contexts;
using Auth.Api.Models.Register;
using Auth.DataLayer;
using Auth.DataLayer.Enums;
using Auth.DataLayer.Factories;
using Common.Magic;
using Common.Services;
using System;

namespace Auth.Api.Static
{
    public static class RegisterService
    {
        public static Guid RegisterAndSave(this AppRequestContext context, RegisterModel model)
        {
            var encryptedEmail = context.Encrypt(model.Email);
            var hashedPassword = context.CreateHash(model.Password);

            var user = context.Entity<IUserFactory>()
                .Create(encryptedEmail, hashedPassword);

            var person = context.Entity<IPersonFactory>().Create(user.Id,
                                                                 model.Firstname,
                                                                 model.Surname,
                                                                 model.Patronymic,
                                                                 model.BirthDate);

            var credential = context.Entity<ICredentialFactory>()
                .Create(user.Id, Roles.User);

            context.Add(user);
            context.Add(person);
            context.Add(credential);

            context.SaveChanges();

            return user.Id;
        }
    }
}
