using Auth.DataLayer.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.DataLayer.Entities
{
    [Table("roles")]
    public class Role : IAuthEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("caption")]
        public string Caption { get; set; }

        [Column("power")]
        public RolePower Power { get; set; }
    }
}
