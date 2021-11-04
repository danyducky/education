using Auth.DataLayer.Enums;
using Common.Api.Contexts;
using Common.Attributes;
using Education.DataLayer;
using Education.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Api.Controllers
{
    [ApiController]
    [BeAuthorized(Roles.USER)]
    public class GroupController : Controller
    {
        private readonly AppRequestContext context;

        public GroupController(AppRequestContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Список всех групп
        /// </summary>
        /// <returns></returns>
        [HttpGet("group")]
        [Produces(typeof(List<Group>))]
        public IActionResult Get()
        {
            return Ok(
                context.Get<Group>()
                       .ToList()
                );
        }

        [HttpGet("group/{id}")]
        [Produces(typeof(Group))]
        public IActionResult GetById(Guid id)
        {
            return Ok(
                context.Get<Group>()
                       .ById(id)
                       .FirstOrDefault()
                );
        }
        
        /// <summary>
        /// Список групп по специальности
        /// </summary>
        /// <param name="specialityId"></param>
        /// <returns></returns>
        [HttpGet("group/specs/{specialityId}")]
        [Produces(typeof(List<Group>))]
        public IActionResult GetBySpecialityId(Guid specialityId)
        {
            return Ok(
                context.Get<Group>()
                       .BySpecialityId(specialityId)
                       .ToList()
                );
        }

        /// <summary>
        /// Список групп по специальности и наименованию
        /// </summary>
        /// <param name="specialityId"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpPost("group/search/{specialityId}")]
        [Produces(typeof(List<Group>))]
        public IActionResult Search(Guid specialityId, [FromBody] string text)
        {
            return Ok(
                context.Get<Group>()
                       .BySpecialityId(specialityId)
                       .Where(x => x.Caption.Contains(text))
                       .ToList()
                );
        }
    }
}
