using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Domain.Exceptions
{
    public class FileNameContainsInvalidExtensionException : Exception
    {
        public FileNameContainsInvalidExtensionException(string message) : base(message) { }
    }
}
