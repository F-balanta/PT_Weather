using Application.Data;
using Application.Weathers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeathersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<WeatherDto>>> GetAllWeathers() => await _mediator.Send(new GetAll.Query());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<WeatherDto>> GetById(int id) => await _mediator.Send(new GetById.Query { Id = id });

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command data) => await _mediator.Send(data);

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Unit>> Edit(int id, Edit.CommandId data)
        {
            data.Id = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Unit>> Delete(int id) => await _mediator.Send(new Delete.Command {Id = id});
    }
}
