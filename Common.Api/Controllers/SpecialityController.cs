using Auth.DataLayer.Enums;
using Common.Api.Contexts;
using Common.Attributes;
using Education.DataLayer;
using Education.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Common.Api.Controllers
{
    [ApiController]
    [BeAuthorized(Roles.USER)]
    public class SpecialityController : Controller
    {
        private readonly AppRequestContext context;

        public SpecialityController(AppRequestContext context)
        {
            this.context = context;
        }

        [HttpGet("speciality")]
        public IActionResult Get()
        {
            return Ok(
                context.Get<Speciality>()
                       .ToList()
                );
        }

        /// <summary>
        /// Получение специальности
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("speciality/{id}")]
        [Produces(typeof(Speciality))]
        public IActionResult GetById(Guid id)
        {
            return Ok(
                context.Get<Speciality>()
                       .ById(id)
                       .FirstOrDefault()
                );
        } 
    }
}
