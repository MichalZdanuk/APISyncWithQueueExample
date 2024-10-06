using MediatR;
using Microsoft.AspNetCore.Mvc;
using SystemB.Application.DTOs.UserEventHistoricalRecords;
using SystemB.Application.Queries.UserEventHistoricalRecords.GetUserEventHistoricalRecord;

namespace SystemB.API.Controllers
{
    [Route("api/user-events")]
    [ApiController]
    public class UserEventHistoricalRecordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserEventHistoricalRecordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<UserEventHistoricalRecordDto>>> GetUserEventHistoricalRecords()
        {
            var query = new GetUserEventHistoricalRecordQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
