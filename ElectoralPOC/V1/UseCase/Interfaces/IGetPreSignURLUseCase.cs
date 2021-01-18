using ElectoralPOC.V1.Boundary.Request;
using ElectoralPOC.V1.Boundary.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.UseCase.Interfaces
{
    public interface IGetPreSignURLUseCase
    {
        GeneratePreSignedUrlResponse GetS3PutPresignUrl(GenerateS3PreSignedUrlRequest request);
    }
}
