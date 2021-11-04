using Auth.Shared.Services;
using Common.Exceptions;
using Common.Static;
using Education.DataLayer;
using Education.DataLayer.Entities;
using System;
using System.Linq;
using Common.Api.Contexts;
using Common.Api.Models.Request;

namespace Common.Api.Static
{
    public static class RequestService
    {
        public static Guid CreateGroupRequest(this AppRequestContext context, RequestGroupModel model)
        {
            var currentUser = context.GetCurrentUser();

            var isRequestFound = context.Get<GroupRequest>()
                .ByUserId(currentUser.Id)
                .ToList().Count > 0;

            if (isRequestFound)
                throw new ForbiddenException();

            var group = context.Get<Group>()
                .ById(model.GroupId)
                .BySpecialityId(model.SpecialityId)
                .FirstOrDefault();

            if (group == null)
                throw new BadRequestException();

            var request = new GroupRequest
            {
                Id = context.NewGuid(),
                UserId = currentUser.Id,
                GroupId = group.Id,
                Comment = model.Comment
            };

            context.Add(request);

            context.SaveChanges();

            return request.Id;
        }
    }
}
