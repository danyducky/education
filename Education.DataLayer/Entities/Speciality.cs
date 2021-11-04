using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Education.DataLayer.Entities
{
    [Table("specialities")]
    public class Speciality : IEducationEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("caption")]
        public string Caption { get; set; }

        [Column("short_caption")]
        public string ShortCaption { get; set; }

        [Column("years_to_study")]
        public short YearsToStudy { get; set; }

        [Column("months_to_study")]
        public short MonthsToStudy { get; set; }


        #region Navigation
        public ICollection<Group> Groups { get; set; }
        #endregion
    }

    public static class SpecialityQueryExtensions
    {
        public static IQueryable<Speciality> ById(this IQueryable<Speciality> query, bool filter, Guid? id) => filter ? query.ById(id.Value) : query;
        public static IQueryable<Speciality> ById(this IQueryable<Speciality> query, Guid id) => query.Where(x => x.Id == id);
        public static IQueryable<Speciality> ByIds(this IQueryable<Speciality> query, bool filter, IEnumerable<Guid> ids) => filter ? query.ByIds(ids) : query;
        public static IQueryable<Speciality> ByIds(this IQueryable<Speciality> query, IEnumerable<Guid> ids) => query.Where(x => ids.Contains(x.Id));
    }
}
