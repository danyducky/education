using Auth.DataLayer.Entities;
using System;

namespace Auth.DataLayer.Factories
{
    public class PersonFactory : IPersonFactory
    {
        public Person Create(Guid userId, string firstname, string surname, string patronymic, DateTime birthDate)
        {
            return new Person
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Firstname = firstname,
                Surname = surname,
                Patronymic = patronymic,
                BirthDate = birthDate
            };
        }
    }
}
