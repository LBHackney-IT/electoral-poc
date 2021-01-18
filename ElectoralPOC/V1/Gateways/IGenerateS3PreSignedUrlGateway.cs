using ElectoralPOC.V1.Boundary.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Helpers
{
    public interface IGenerateS3PreSignedUrlGateway
    {
        string GenerateS3PutPreSignurl(GenerateS3PreSignedUrlRequest request);
    }
}
