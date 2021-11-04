using System;
using System.Collections.Generic;

namespace Auth.Shared.Models
{
    public class CurrentUserModel
    {
        public CurrentUserModel(Guid id, Guid personId, IReadOnlyCollection<Guid> roleIds)
        {
            Id = id;
            PersonId = personId;
            RoleIds = roleIds;
        }

        public Guid Id { get; }
        public Guid PersonId { get; }
        public IReadOnlyCollection<Guid> RoleIds { get; }
    }
}
