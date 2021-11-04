using Auth.Api.Contexts;
using Auth.Api.Models.Shared;
using Auth.DataLayer;
using Auth.DataLayer.Entities;
using Auth.Shared.Services;
using Common.Services;
using System.Linq;

namespace Auth.Api.Static
{
    public static class UserService
    {
        public static UserModel GetMe(this AppRequestContext context)
        {
            var currentUser = context.GetCurrentUser();

            var user = context.Get<User>()
                .ById(currentUser.Id)
                .FirstOrDefault();

            var person = context.Get<Person>()
                .ById(currentUser.PersonId)
                .FirstOrDefault();

            return new UserModel(
                user.Id,
                context.Decrypt(user.Email),
                person.Firstname,
                person.Surname,
                person.Patronymic,
                person.BirthDate
            );
        }
    }
}
