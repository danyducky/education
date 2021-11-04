using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.DataLayer.Entities
{
    [Table("modules")]
    public class Module : IAuthEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("caption")]
        public string Caption { get; set; }

        [Column("short_caption")]
        public string ShortCaption { get; set; }

        [Column("route")]
        public string Route { get; set; }
    }
}
