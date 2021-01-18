using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Domain.Exceptions
{
    public class UrlExpirationTimeInvalidException : Exception
    {
        public UrlExpirationTimeInvalidException(string message) : base(message) { }
    }
}
