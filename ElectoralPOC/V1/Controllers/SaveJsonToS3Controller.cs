using ElectoralPOC.V1.Boundary.Request;
using ElectoralPOC.V1.Boundary.Response;
using ElectoralPOC.V1.Domain.Exceptions;
using ElectoralPOC.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Controllers
{
    [ApiController]
    [Route("api/v1/json-data")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class SaveJsonToS3Controller : BaseController
    {
        private readonly ISaveJsonToS3UseCase _getSaveJsonToS3UseCase;

        public SaveJsonToS3Controller(ISaveJsonToS3UseCase getSaveJsonToS3UseCase)
        {
            _getSaveJsonToS3UseCase = getSaveJsonToS3UseCase;
        }
        /// <summary>
        /// Save json data to AWS S3 bucket 
        /// </summary>
        /// <response code="201">JSON data successfully saved to S3 bucket</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(SaveJsonToS3Response), StatusCodes.Status201Created)]
        [Produces("application/json")]
        [HttpPost]
        public IActionResult SaveJsonToS3([FromBody] SaveJsonToS3Request request)
        {
            try
            {
                _getSaveJsonToS3UseCase.SaveJsonToS3Case(request);
                return CreatedAtAction("SaveS3Successful", null);
            }
            catch (JsonFileCouldNotBeSavedToS3Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
