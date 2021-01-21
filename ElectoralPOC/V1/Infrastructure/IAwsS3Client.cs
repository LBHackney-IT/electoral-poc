using Amazon.S3.Model;
using ElectoralPOC.V1.Boundary.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Infrastructure
{
    public interface IAwsS3Client
    {
        void SaveJsonToS3(SaveJsonToS3Request jsonRequest);
    }
}
