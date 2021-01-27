using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Domain.Exceptions
{
    public class JsonFileCouldNotBeSavedToS3Exception : Exception
    {
        public JsonFileCouldNotBeSavedToS3Exception()
        {
        }

        public JsonFileCouldNotBeSavedToS3Exception(string message) : base(message) { }
    }
}
