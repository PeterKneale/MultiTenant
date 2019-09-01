using Demo.Service.Tenants.Infrastructure;
using Demo.Service.Tenants.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.Service.Tenants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainController : ControllerBase
    {
        /// <summary>
        /// Gets the domain by domain name
        /// </summary>
        [HttpGet("{domain}")]
        [Authorize(Policy = Constants.ReadDomainsPolicy)]
        public ActionResult<DomainModel> Get(string domain)
        {
            throw new NotImplementedException();
        }
    }
}
