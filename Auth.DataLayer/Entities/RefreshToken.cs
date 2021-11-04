using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.DataLayer.Entities
{
    [Table("refresh_tokens")]
    [Owned]
    public class RefreshToken : IAuthEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("token")]
        public string Token { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("expires_in")]
        public DateTime ExpiresIn { get; set; }

        public bool IsExpired => DateTime.UtcNow >= ExpiresIn;

        [Column("created_by_ip")]
        public string CreatedByIp { get; set; }
    }
}
