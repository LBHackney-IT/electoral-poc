using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using ElectoralPOC.V1.Boundary.Request;
using ElectoralPOC.V1.Domain.Exceptions;
using ElectoralPOC.V1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Infrastructure
{
    public class AWSS3Client : IAwsS3Client
    {
        public string GenerateS3PreSignURL(GetPreSignedUrlRequest request)
        {
            using (AmazonS3Client _s3Client = new AmazonS3Client(RegionEndpoint.USWest2))
            {            
                return _s3Client.GetPreSignedURL(request);
            }
        }
    }
}
