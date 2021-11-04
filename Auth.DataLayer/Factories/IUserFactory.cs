using Auth.DataLayer.Entities;
using System;

namespace Auth.DataLayer.Factories
{
    public interface IUserFactory
    {
        User Create(string email, string password);
    }
}
