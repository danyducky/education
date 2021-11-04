using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Education.DataLayer.Entities
{
    [Table("students")]
    public class Student : IEducationEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("person_id")]
        public Guid PersonId { get; set; }

        [Column("firstname")]
        public string Firstname { get; set; }

        [Column("surname")]
        public string Surname { get; set; }

        [Column("patronymic")]
        public string Patronymic { get; set; }

        [Column("group_id")]
        [ForeignKey("Group")]
        public Guid GroupId { get; set; }

        [Column("is_group_leader")]
        public bool IsGroupLeader { get; set; }

        #region Navigation

        public Group Group { get; set; }

        #endregion
    }

    public static class StudentQueryExtensions
    {
        public static IQueryable<Student> ById(this IQueryable<Student> query, bool filter, Guid? id) => filter ? query.ById(id.Value) : query;
        public static IQueryable<Student> ById(this IQueryable<Student> query, Guid id) => query.Where(x => x.Id == id);
        public static IQueryable<Student> ByIds(this IQueryable<Student> query, bool filter, IEnumerable<Guid> ids) => filter ? query.ByIds(ids) : query;
        public static IQueryable<Student> ByIds(this IQueryable<Student> query, IEnumerable<Guid> ids) => query.Where(x => ids.Contains(x.Id));


        public static IQueryable<Student> ByUserId(this IQueryable<Student> query, bool filter, Guid? userId) => filter ? query.ByUserId(userId.Value) : query;
        public static IQueryable<Student> ByUserId(this IQueryable<Student> query, Guid userId) => query.Where(x => x.UserId == userId);
        public static IQueryable<Student> ByUserIds(this IQueryable<Student> query, bool filter, IEnumerable<Guid> userIds) => filter ? query.ByUserIds(userIds) : query;
        public static IQueryable<Student> ByUserIds(this IQueryable<Student> query, IEnumerable<Guid> userIds) => query.Where(x => userIds.Contains(x.UserId));



        public static IQueryable<Student> ByPersonId(this IQueryable<Student> query, bool filter, Guid? personId) => filter ? query.ByPersonId(personId.Value) : query;
        public static IQueryable<Student> ByPersonId(this IQueryable<Student> query, Guid personId) => query.Where(x => x.PersonId == personId);
        public static IQueryable<Student> ByPersonIds(this IQueryable<Student> query, bool filter, IEnumerable<Guid> personIds) => filter ? query.ByPersonIds(personIds) : query;
        public static IQueryable<Student> ByPersonIds(this IQueryable<Student> query, IEnumerable<Guid> personIds) => query.Where(x => personIds.Contains(x.PersonId));
    }
}
