using Demo.Service.Tenants.Infrastructure;
using Demo.Service.Tenants.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Demo.Service.Tenants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Gets all users within the current users tenant
        /// </summary>
        [HttpGet]
        [Authorize(Policy = Constants.ManageUsersPolicy)]
        public ActionResult<IEnumerable<UserModel>> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a user within the current users tenant
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Policy = Constants.ManageUsersPolicy)]
        public ActionResult<UserModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new user within the current users tenant
        /// </summary>
        [HttpPost]
        [Authorize(Policy = Constants.ManageUsersPolicy)]
        public void Post([FromBody] UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
