using Auth.DataLayer.Entities;
using System;

namespace Auth.DataLayer.Factories
{
    public interface ICredentialFactory
    {
        Credential Create(Guid userId, Guid roleId);
    }
}
