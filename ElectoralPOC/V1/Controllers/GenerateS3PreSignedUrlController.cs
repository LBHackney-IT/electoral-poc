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
    [Route("api/v1/presigned-urls")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class GenerateS3PreSignedUrlController : BaseController
    {
        private readonly IGetPreSignURLUseCase _getPreSignURLUseCase;

        public GenerateS3PreSignedUrlController(IGetPreSignURLUseCase getPreSignURLUseCase)
        {
            _getPreSignURLUseCase = getPreSignURLUseCase;
        }
        /// <summary>
        /// Generates a pre-signed S3 URL. Based on input, the generated URL can be used for retrieving/uploading files
        /// </summary>
        /// <response code="201">URL successfully generated</response>
        /// <response code="400">One or more request parameters are invalid/missing</response>
        /// <response code="500">URL could not be generated</response>
        [ProducesResponseType(typeof(GeneratePreSignedUrlResponse), StatusCodes.Status201Created)]
        [HttpPost]
        public IActionResult GenerateS3PreSignedUrl([FromBody] GenerateS3PreSignedUrlRequest request)
        {
            try
            {
                return StatusCode(201, _getPreSignURLUseCase.GetS3PutPresignUrl(request));
            }
            catch (PreSignedUrlCouldNotBeGeneratedException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (UrlExpirationTimeInvalidException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
