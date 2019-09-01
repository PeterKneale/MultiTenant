using Demo.Edge.Signup.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.Edge.Signup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Post([FromBody] SignupModel model)
        {
            throw new NotImplementedException();
        }
    }
}
