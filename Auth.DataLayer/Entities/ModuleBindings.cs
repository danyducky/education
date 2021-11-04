using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Auth.DataLayer.Entities
{
    [Table("module_bindings")]
    public class ModuleBindings : IAuthEntity
    {
        [Column("module_id")]
        public Guid ModuleId { get; set; }

        [Column("role_id")]
        public Guid RoleId { get; set; }

        #region Navigation

        public Module Module { get; set; }
        public Role Role { get; set; }

        #endregion
    }

    public static class ModuleBindingsQueryExtensions
    {
        public static IQueryable<ModuleBindings> ByRoleId(this IQueryable<ModuleBindings> query, bool filter, Guid? roleId) => filter ? query.ByRoleId(roleId.Value) : query;
        public static IQueryable<ModuleBindings> ByRoleId(this IQueryable<ModuleBindings> query, Guid roleId) => query.Where(x => x.RoleId == roleId);
        public static IQueryable<ModuleBindings> ByRoleIds(this IQueryable<ModuleBindings> query, bool filter, IEnumerable<Guid> roleIds) => filter ? query.ByRoleIds(roleIds) : query;
        public static IQueryable<ModuleBindings> ByRoleIds(this IQueryable<ModuleBindings> query, IEnumerable<Guid> roleIds) => query.Where(x => roleIds.Contains(x.RoleId));


        public static IQueryable<ModuleBindings> ByModuleId(this IQueryable<ModuleBindings> query, bool filter, Guid? moduleId) => filter ? query.ByModuleId(moduleId.Value) : query;
        public static IQueryable<ModuleBindings> ByModuleId(this IQueryable<ModuleBindings> query, Guid moduleId) => query.Where(x => x.ModuleId == moduleId);
        public static IQueryable<ModuleBindings> ByModuleIds(this IQueryable<ModuleBindings> query, bool filter, IEnumerable<Guid> moduleIds) => filter ? query.ByModuleIds(moduleIds) : query;
        public static IQueryable<ModuleBindings> ByModuleIds(this IQueryable<ModuleBindings> query, IEnumerable<Guid> moduleIds) => query.Where(x => moduleIds.Contains(x.ModuleId));
    }
}
