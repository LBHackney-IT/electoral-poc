using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Helpers
{
    public static class GenerateUrlHelper
    {
        public static string ComposeFilePath(string basePath, string fileName, string submissionId)
        {
            fileName = fileName.StartsWith("/") ? fileName.Remove(0,1) : fileName;
            submissionId = submissionId.StartsWith("/") ? submissionId.Remove(0, 1) : submissionId;
            basePath = string.IsNullOrEmpty(basePath) ? "" : basePath + "/";

            return basePath 
                + submissionId + "/docs/"
                + fileName;
        }
    }
}
