using ElectoralPOC.V1.Boundary.Response;
using ElectoralPOC.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectoralPOC.V1.Controllers
{
    [ApiController]
    [Route("form/register-applicant/applicant-details")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class ElectoralPOCController : BaseController
    {
        private readonly IInsertJsonUseCase _insertJsonUseCase;
        public ElectoralPOCController(IInsertJsonUseCase insertJsonUseCase)
        {
            _insertJsonUseCase = insertJsonUseCase;
        }

        /// <summary>
        /// inserts JSON data into the database
        /// </summary>
        /// <response code="201">...</response>
        /// <response code="500">Invalid Query Parameter.</response>
        [ProducesResponseType(typeof(ResponseObjectList), StatusCodes.Status200OK)]
        [HttpPut]
        public IActionResult InsertData()
        {
            return Ok(_insertJsonUseCase.Execute());
        }

        
    }
}
