using Education.DataLayer.Entities;
using System;

namespace Education.DataLayer.Factories
{
    public interface IGroupRequestFactory
    {
        GroupRequest Create(Guid userId, Guid groupId, string comment);
    }
}
