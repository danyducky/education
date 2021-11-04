using Auth.DataLayer.Entities;
using System;

namespace Auth.DataLayer.Factories
{
    public interface IPersonFactory
    {
        Person Create(Guid userId, string firstname, string surname, string patronymic, DateTime birthDate);
    }
}
