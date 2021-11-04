using Education.DataLayer.Entities;
using System;

namespace Education.DataLayer.Factories
{
    public class GroupRequestFactory : IGroupRequestFactory
    {
        public GroupRequest Create(Guid userId, Guid groupId, string comment)
        {
            return new GroupRequest
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                GroupId = groupId,
                Comment = comment
            };
        }
    }
}
