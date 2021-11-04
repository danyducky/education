using System;
using System.Collections.Generic;

namespace Auth.Shared.Models
{
    public class TokenPayload
    {
        public TokenPayload(Guid userId, Guid personId, IEnumerable<Guid> roleIds)
        {
            UserId = userId;
            PersonId = personId;
            RoleIds = roleIds;
        }

        public Guid UserId { get; }
        public Guid PersonId { get; }
        public IEnumerable<Guid> RoleIds { get; }
    }
}
