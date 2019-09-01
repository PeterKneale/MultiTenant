using Demo.Service.Profiles.Domain.Queries;
using Demo.Service.Widgets.Domain.Commands;
using Demo.Service.Widgets.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Service.Widgets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WidgetsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WidgetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/widgets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WidgetViewModel>>> Get()
        {
            var widgets = await _mediator.Send(new GetWidgets.Query());
            var response = widgets.Select(x => new WidgetViewModel { Id = x.Id, Name = x.Name });
            return Ok(response);
        }

        // GET api/widgets/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/widgets
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] WidgetCreateModel model)
        {
            var id = model.Id;
            var name = model.Name;
            await _mediator.Send(new CreateWidget.Command(id, name));
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        // PUT api/widgets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/widgets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
