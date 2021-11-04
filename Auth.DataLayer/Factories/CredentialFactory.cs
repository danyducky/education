using Auth.DataLayer.Entities;
using System;

namespace Auth.DataLayer.Factories
{
    public class CredentialFactory : ICredentialFactory
    {
        public Credential Create(Guid userId, Guid roleId)
        {
            return new Credential
            {
                UserId = userId,
                RoleId = roleId,
            };
        }
    }
}
