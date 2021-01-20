using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using ElectoralPOC.V1.Boundary.Request;
using ElectoralPOC.V1.Boundary.Response;
using ElectoralPOC.V1.Domain.Exceptions;
using ElectoralPOC.V1.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Infrastructure
{
    public class AWSS3Client : IAwsS3Client
    {
        public string SaveJsonToS3(GetPreSignedUrlRequest request)
        {
            using (AmazonS3Client _s3Client = new AmazonS3Client(RegionEndpoint.USWest2))
            {
              
                byte[] _byteArray = Encoding.ASCII.GetBytes("unprocessed /{ }_requestdata.json");
                using (var stream = new MemoryStream(_byteArray))
                {
                    var objectRequest = new PutObjectRequest
                    {
                        BucketName = Environment.GetEnvironmentVariable("electoral-register-stack-rdatadropbucketa4dd7fb3-jcd1deylvkwn"),
                        Key = Environment.GetEnvironmentVariable("unprocessed /{ }_requestdata.json"),
                        ContentType = Environment.GetEnvironmentVariable("application/json"),
                        InputStream = stream,
                    };
                    var response = _s3Client.PutObjectAsync(objectRequest).ConfigureAwait(false);
                }
                return _s3Client.GetPreSignedURL(request);
            }
        }
    }
}
