using ElectoralPOC.V1.Domain.Exceptions;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Helpers
{
    public static class SaveJsonToS3Helper
    {
        public static string ComposeFilePath(string basePath, string fileName, string submissionId)
        {
            fileName = fileName.StartsWith("/") ? fileName.Remove(0, 1) : fileName;
            submissionId = submissionId.StartsWith("/") ? submissionId.Remove(0, 1) : submissionId;
            basePath = string.IsNullOrEmpty(basePath) ? "" : basePath + "/";

            return basePath
                + submissionId + "/docs/"
                + fileName;
        }

        public static string EnsureFileIsJson(string fileName)
        {
            if (fileName.EndsWith(".json"))
            {
                return fileName;
            }
            else
            {
                throw new JsonFileCouldNotBeSavedToS3Exception();
            }
        }
    }
}
