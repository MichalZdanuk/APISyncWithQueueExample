using Microsoft.AspNetCore.Mvc;
using SystemA.Application.DTOs;

namespace SystemA.API.Controllers
{
    [Route("version")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public VersionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<APIVersionDto> GetVersion()
        {
            var version = new APIVersionDto
            {
                Version = _configuration["Version"]
            };

            return Ok(version);
        }
    }
}
