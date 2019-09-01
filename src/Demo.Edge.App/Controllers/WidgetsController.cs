using Demo.Edge.App.Models;
using Demo.Edge.App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Edge.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetsController : ControllerBase
    {
        private readonly IWidgetsService _service;

        public WidgetsController(IWidgetsService service)
        {
            _service = service;
        }

        // GET api/widgets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WidgetViewModel>>> GetAsync()
        {
            var result = await _service.GetAsync();
            return Ok(result);
        }
    }
}
