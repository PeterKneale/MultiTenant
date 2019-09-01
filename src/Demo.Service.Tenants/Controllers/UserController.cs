using Demo.Service.Tenants.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.Service.Tenants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Get the current user
        /// </summary>
        [HttpGet]
        public ActionResult<UserModel> Get()
        {
            throw new NotImplementedException();
        }
    }
}
