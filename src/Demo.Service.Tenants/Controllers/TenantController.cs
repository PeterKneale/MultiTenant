using Demo.Service.Tenants.Infrastructure;
using Demo.Service.Tenants.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Demo.Service.Tenants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        /// <summary>
        /// Gets the tenant associated with the current user
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Policy = Constants.ManageTenantPolicy)]
        public ActionResult<TenantModel> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the tenant associated with the current user
        /// </summary>
        [HttpPost]
        [Authorize(Policy = Constants.ManageTenantPolicy)]
        public void Post([FromBody] TenantModel model)
        {
            throw new NotImplementedException();
        }
    }
}
