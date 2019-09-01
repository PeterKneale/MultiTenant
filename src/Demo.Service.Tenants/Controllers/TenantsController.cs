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
    public class TenantsController : ControllerBase
    {
        /// <summary>
        /// Gets all tenants
        /// </summary>
        [HttpGet]
        [Authorize(Policy = Constants.ManageTenantsPolicy)]
        public ActionResult<IEnumerable<TenantModel>> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a tenant
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Policy = Constants.ManageTenantsPolicy)]
        public ActionResult<IEnumerable<TenantModel>> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new tenant
        /// </summary>
        [HttpPost]
        [Authorize(Policy = Constants.CreateTenantPolicy)]
        public void Post([FromBody] TenantModel model)
        {
            throw new NotImplementedException();
        }
    }
}
