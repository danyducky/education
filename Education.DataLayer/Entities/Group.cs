using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Education.DataLayer.Entities
{
    [Table("groups")]
    public class Group : IEducationEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("caption")]
        public string Caption { get; set; }

        [ForeignKey("Speciality")]
        [Column("speciality_id")]
        public Guid SpecialityId { get; set; }


        #region Navigation
        public Speciality Speciality { get; set; }
        #endregion
    }

    public static class GroupQueryExtensions
    {
        public static IQueryable<Group> ById(this IQueryable<Group> query, bool filter, Guid? id) => filter ? query.ById(id.Value) : query;
        public static IQueryable<Group> ById(this IQueryable<Group> query, Guid id) => query.Where(x => x.Id == id);
        public static IQueryable<Group> ByIds(this IQueryable<Group> query, bool filter, IEnumerable<Guid> ids) => filter ? query.ByIds(ids) : query;
        public static IQueryable<Group> ByIds(this IQueryable<Group> query, IEnumerable<Guid> ids) => query.Where(x => ids.Contains(x.Id));


        public static IQueryable<Group> BySpecialityId(this IQueryable<Group> query, bool filter, Guid? specialityId) => filter ? query.BySpecialityId(specialityId.Value) : query;
        public static IQueryable<Group> BySpecialityId(this IQueryable<Group> query, Guid specialityId) => query.Where(x => x.SpecialityId == specialityId);
        public static IQueryable<Group> BySpecialityIds(this IQueryable<Group> query, bool filter, IEnumerable<Guid> specialityIds) => filter ? query.BySpecialityIds(specialityIds) : query;
        public static IQueryable<Group> BySpecialityIds(this IQueryable<Group> query, IEnumerable<Guid> specialityIds) => query.Where(x => specialityIds.Contains(x.SpecialityId));
    }
}
