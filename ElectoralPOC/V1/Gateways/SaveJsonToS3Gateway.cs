using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using ElectoralPOC.V1.Boundary.Request;
using ElectoralPOC.V1.Boundary.Response;
using ElectoralPOC.V1.Domain.Exceptions;
using ElectoralPOC.V1.Gateway;
using ElectoralPOC.V1.Helpers;
using ElectoralPOC.V1.Infrastructure;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Gateway
{
    public class SaveJsonToS3Gateway : ISaveJsonToS3Gateway
    {
        private readonly IAwsS3Client _awsS3Client;
        public SaveJsonToS3Gateway(IAwsS3Client awsS3Client)
        {
            _awsS3Client = awsS3Client;
        }
        public void SaveJsonToS3(SaveJsonToS3Request jsonRequest)
        {
            try
            {
                _awsS3Client.SaveJsonToS3(jsonRequest);
            }
            catch (Exception ex)
            {
                throw new JsonFileCouldNotBeSavedToS3Exception($"The JSON file could not be save to S3 for the following reason - {ex.Message}, {ex.InnerException}");
            }
        }
    }
}
