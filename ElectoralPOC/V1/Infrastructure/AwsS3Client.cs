using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using ElectoralPOC.V1.Boundary.Request;
using ElectoralPOC.V1.Boundary.Response;
using ElectoralPOC.V1.Domain.Exceptions;
using ElectoralPOC.V1.Helpers;
using ElectoralPOC.V1.UseCase.Interfaces;
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

        public void SaveJsonToS3(SaveJsonToS3Request jsonRequest)
        {
            using (AmazonS3Client _s3Client = new AmazonS3Client(RegionEndpoint.EUWest2))
            {

                byte[] _byteArray = Encoding.ASCII.GetBytes(jsonRequest.JsonData);
                using (var stream = new MemoryStream(_byteArray))
                {
                    var objectRequest = new PutObjectRequest
                    {
                        BucketName = jsonRequest.BucketName,
                        Key = jsonRequest.FileName,
                        ContentType = "application/json",
                        InputStream = stream,
                    };
                    var response = _s3Client.PutObjectAsync(objectRequest).Result;
                }
            }
        }
    }
}
