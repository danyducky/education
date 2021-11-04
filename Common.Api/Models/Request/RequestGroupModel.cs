using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Api.Models.Request
{
    public class RequestGroupModel
    {
        public Guid SpecialityId { get; set; }
        public Guid GroupId { get; set; }

        [MaxLength(256)]
        public string Comment { get; set; }
    }
}
