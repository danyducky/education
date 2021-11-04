using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Auth.DataLayer.Entities
{
    [Table("users")]
    public class User : IAuthEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("registration_date")]
        public DateTime RegistrationDate { get; set; }

        #region Navigation
        public Person Person { get; set; }
        public IList<RefreshToken> RefreshTokens { get; set; }
        #endregion
    }

    public static class UserQueryExtensions
    {

        public static IQueryable<User> ById(this IQueryable<User> query, bool filter, Guid? id) => filter ? query.ById(id.Value) : query;
        public static IQueryable<User> ById(this IQueryable<User> query, Guid id) => query.Where(x => x.Id == id);
        public static IQueryable<User> ByIds(this IQueryable<User> query, bool filter, IEnumerable<Guid> ids) => filter ? query.ByIds(ids) : query;
        public static IQueryable<User> ByIds(this IQueryable<User> query, IEnumerable<Guid> ids) => query.Where(x => ids.Contains(x.Id));


        public static IQueryable<User> ByEmail(this IQueryable<User> query, bool filter, string email) => filter ? query.ByEmail(email) : query;
        public static IQueryable<User> ByEmail(this IQueryable<User> query, string email) => query.Where(x => x.Email == email);
        public static IQueryable<User> ByEmails(this IQueryable<User> query, bool filter, IEnumerable<string> emails) => filter ? query.ByEmails(emails) : query;
        public static IQueryable<User> ByEmails(this IQueryable<User> query, IEnumerable<string> emails) => query.Where(x => emails.Contains(x.Email));

        public static IQueryable<User> ByRefreshToken(this IQueryable<User> query, string token) => query.Where(x => x.RefreshTokens.Any(t => t.Token == token));
    }
}
