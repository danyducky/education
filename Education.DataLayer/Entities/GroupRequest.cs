using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Education.DataLayer.Entities
{
    [Table("group_requests")]
    public class GroupRequest : IEducationEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [ForeignKey("Group")]
        [Column("group_id")]
        public Guid GroupId { get; set; }

        [MaxLength(256)]
        [Column("comment")]
        public string Comment { get; set; }

        #region Navigation
        public Group Group { get; set; }
        #endregion
    }

    public static class GroupRequestExtensions
    {
        public static IQueryable<GroupRequest> ByUserId(this IQueryable<GroupRequest> query, bool filter, Guid? userId) => filter ? query.ByUserId(userId.Value) : query;
        public static IQueryable<GroupRequest> ByUserId(this IQueryable<GroupRequest> query, Guid userId) => query.Where(x => x.UserId == userId);
        public static IQueryable<GroupRequest> ByUserIds(this IQueryable<GroupRequest> query, bool filter, IEnumerable<Guid> userIds) => filter ? query.ByUserIds(userIds) : query;
        public static IQueryable<GroupRequest> ByUserIds(this IQueryable<GroupRequest> query, IEnumerable<Guid> userIds) => query.Where(x => userIds.Contains(x.UserId));



        public static IQueryable<GroupRequest> ByGroupId(this IQueryable<GroupRequest> query, bool filter, Guid? groupId) => filter ? query.ByGroupId(groupId.Value) : query;
        public static IQueryable<GroupRequest> ByGroupId(this IQueryable<GroupRequest> query, Guid groupId) => query.Where(x => x.GroupId == groupId);
        public static IQueryable<GroupRequest> ByGroupIds(this IQueryable<GroupRequest> query, bool filter, IEnumerable<Guid> groupIds) => filter ? query.ByGroupIds(groupIds) : query;
        public static IQueryable<GroupRequest> ByGroupIds(this IQueryable<GroupRequest> query, IEnumerable<Guid> groupIds) => query.Where(x => groupIds.Contains(x.GroupId));
    }
}
