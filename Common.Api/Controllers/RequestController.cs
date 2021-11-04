using Auth.DataLayer.Enums;
using Auth.Shared.Services;
using Common.Api.Contexts;
using Common.Api.Models.Request;
using Common.Api.Static;
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
    public class RequestController : Controller
    {
        private readonly AppRequestContext context;

        public RequestController(AppRequestContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Получить заявку в студенческую группу
        /// </summary>
        /// <returns></returns>
        [HttpGet("request")]
        [Produces(typeof(List<GroupRequest>))]
        public IActionResult Get()
        {
            return Ok(
                context.Get<GroupRequest>()
                       .ByUserId(context.GetCurrentUser().Id)
                       .FirstOrDefault()
                );
        }

        /// <summary>
        /// Подать заявку в группу
        /// </summary>
        /// <returns></returns>
        [HttpPost("request/group")]
        [Produces(typeof(Guid))]
        public IActionResult Group(RequestGroupModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var requestId = context.CreateGroupRequest(model);

            return Ok(requestId);
        }
    }
}
