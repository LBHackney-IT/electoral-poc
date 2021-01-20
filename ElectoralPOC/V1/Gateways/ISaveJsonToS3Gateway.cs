using ElectoralPOC.V1.Boundary.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Gateway
{
    public interface ISaveJsonToS3Gateway
    {
        string ConvertJsonToArray(SaveJsonToS3Request request);
    }
}
