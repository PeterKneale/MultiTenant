using Demo.Service.Profiles.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.Service.Profiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        /// <summary>
        /// Gets the profile of the authenticated user
        /// </summary>
        [HttpGet] 
        public ActionResult<ProfileModel> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the profile of the authenticated user
        /// </summary>
        [HttpPost]
        public void Post([FromBody] ProfileModel model)
        {
            throw new NotImplementedException();
        }
    }
}
