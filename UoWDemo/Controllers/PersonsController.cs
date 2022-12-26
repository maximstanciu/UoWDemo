using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UoWDemo.Handlers.Queries;

namespace UoWDemo.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class PersonsController : ApiController
    {
        private readonly ISender _mediator;

        public PersonsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ErrorOr.ErrorOr))]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetPersonByIdQuery(id);
            var result = await _mediator.Send(query);

            return result.Match(resp => StatusCode((int)HttpStatusCode.OK, resp),
                errors => Problem(errors));
        }
    }
}
