using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using ElectoralPOC.V1.Boundary.Request;
using ElectoralPOC.V1.Domain.Exceptions;
using ElectoralPOC.V1.Gateway;
using ElectoralPOC.V1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Helpers
{
    public class SaveJsonToS3Gateway : ISaveJsonToS3Gateway
    {
        private readonly IAwsS3Client _awsS3Client;
        public SaveJsonToS3Gateway(IAwsS3Client awsS3Client)
        {
            _awsS3Client = awsS3Client;
        }
        public string ConvertJsonToArray(SaveJsonToS3Request request)
        {
            try
            {
                double expires;
                var isValidExpirationTime = double.TryParse(Environment.GetEnvironmentVariable("PRESIGNED_URL_EXPIRATION_IN_SECONDS"), out expires);
                if (!isValidExpirationTime) throw new UrlExpirationTimeInvalidException("Environment variable does not contain a valid double");

                GetPreSignedUrlRequest getUrlRequest = new GetPreSignedUrlRequest
                {
                    BucketName = request.BucketName,
                    Key = SaveJsonToS3Helper.ComposeFilePath(request.BasePath, request.FileName, request.SubmissionId),
                    Verb = request.HttpVerb == "GET" ? HttpVerb.GET : HttpVerb.PUT,
                    Expires = DateTime.UtcNow.AddSeconds(expires),
                };
                return _awsS3Client.SaveJsonToS3(getUrlRequest);
            }
            catch (Exception ex) //TODO find list of specific AWS exceptions that could be thrown by S3
            {
                throw new SaveJsonToS3CouldNotBeGeneratedException($"Pre-signed URL could not be generated - {ex.Message}, {ex.InnerException}");
            }
        }
    }
}
