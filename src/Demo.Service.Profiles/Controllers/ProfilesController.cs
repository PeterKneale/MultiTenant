using Demo.Service.Profiles.Infrastructure;
using Demo.Service.Profiles.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.Service.Profiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        /// <summary>
        /// Gets the profile of the specified user
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<ProfileModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the profile of the specified user
        /// </summary>
        [HttpPost("{id}")]
        [Authorize(Policy = Constants.OverrideProfilePolicyName)]
        public void Post(Guid id, [FromBody] ProfileModel model)
        {
            throw new NotImplementedException();
        }
    }
}
