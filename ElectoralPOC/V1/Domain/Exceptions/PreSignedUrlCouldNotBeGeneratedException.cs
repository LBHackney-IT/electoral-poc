using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Domain.Exceptions
{
    public class PreSignedUrlCouldNotBeGeneratedException : Exception
    {
        public PreSignedUrlCouldNotBeGeneratedException(string message) : base(message) { }
    }
}
