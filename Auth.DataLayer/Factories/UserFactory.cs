using Auth.DataLayer.Entities;
using Common.Services;
using System;

namespace Auth.DataLayer.Factories
{
    public class UserFactory : IUserFactory
    {
        private readonly IDateTimeManager dateTimeManager;

        public UserFactory(IDateTimeManager dateTimeManager)
        {
            this.dateTimeManager = dateTimeManager;
        }

        public User Create(string email, string password)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Email = email,
                Password = password,
                RegistrationDate = dateTimeManager.Now
            };
        }
    }
}
