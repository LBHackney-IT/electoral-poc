using ElectoralPOC.V1.Boundary.Request;
using ElectoralPOC.V1.Boundary.Response;
using ElectoralPOC.V1.Domain;
using ElectoralPOC.V1.Helpers;
using ElectoralPOC.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.UseCase
{
    public class GetPreSignURLUseCase : IGetPreSignURLUseCase
    {
        private IGenerateS3PreSignedUrlGateway _generateS3PreSignUrlHelper;
        public GetPreSignURLUseCase(IGenerateS3PreSignedUrlGateway generateS3PreSignURLHelper)
        {
            _generateS3PreSignUrlHelper = generateS3PreSignURLHelper;
        }

        public GeneratePreSignedUrlResponse GetS3PutPresignUrl(GenerateS3PreSignedUrlRequest request)
        {
            return new GeneratePreSignedUrlResponse
            {
                Url = _generateS3PreSignUrlHelper.GenerateS3PutPreSignurl(request)
            };
        }
    }
}
