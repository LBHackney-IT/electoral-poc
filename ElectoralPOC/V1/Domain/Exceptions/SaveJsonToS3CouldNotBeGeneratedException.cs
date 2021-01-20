using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Domain.Exceptions
{
    public class SaveJsonToS3CouldNotBeGeneratedException : Exception
    {
        public SaveJsonToS3CouldNotBeGeneratedException(string message) : base(message) { }
    }
}
