using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Auth.DataLayer.Entities
{
    [Table("credentials")]
    public class Credential : IAuthEntity
    {
        [Column("user_id")]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [Column("role_id")]
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }

        #region Navigation
        public User User { get; set; }
        public Role Role { get; set; }
        #endregion
    }

    public static class CredentialQueryExtensions
    {
        public static IQueryable<Credential> ByUserId(this IQueryable<Credential> query, Guid userId) => query.Where(x => x.UserId == userId);

        public static IQueryable<Credential> ByRoleId(this IQueryable<Credential> query, Guid roleId) => query.Where(x => x.RoleId == roleId);
        public static IQueryable<Credential> ByRoleIds(this IQueryable<Credential> query, IEnumerable<Guid> roleIds) => query.Where(x => roleIds.Contains(x.RoleId));
    }
}
