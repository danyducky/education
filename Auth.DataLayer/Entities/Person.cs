using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Auth.DataLayer.Entities
{
    [Table("persons")]
    public class Person : IAuthEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("user_id")]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [Column("firstname")]
        public string Firstname { get; set; }

        [Column("surname")]
        public string Surname { get; set; }

        [Column("patronymic")]
        public string Patronymic { get; set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        #region Navigation
        public User User { get; set; }
        #endregion
    }

    public static class PersonQueryExtensions
    {
        public static IQueryable<Person> ById(this IQueryable<Person> query, Guid id) => query.Where(x => x.Id == id);

        public static IQueryable<Person> ByUserId(this IQueryable<Person> query, Guid userId) => query.Where(x => x.UserId == userId);
        public static IQueryable<Person> ByUserIds(this IQueryable<Person> query, IEnumerable<Guid> userIds) => query.Where(x => userIds.Contains(x.UserId));
    }
}
