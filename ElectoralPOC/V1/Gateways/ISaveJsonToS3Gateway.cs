using Amazon.S3.Model;
using ElectoralPOC.V1.Boundary.Request;
using ElectoralPOC.V1.Boundary.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Gateway
{
    public interface ISaveJsonToS3Gateway
    {
        void SaveJsonToS3(SaveJsonToS3Request jsonRequest);
    }
}
