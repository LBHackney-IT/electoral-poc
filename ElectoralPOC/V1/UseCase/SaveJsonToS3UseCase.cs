using ElectoralPOC.V1.Boundary.Request;
using ElectoralPOC.V1.Boundary.Response;
using ElectoralPOC.V1.Domain;
using ElectoralPOC.V1.Gateway;
using ElectoralPOC.V1.Helpers;
using ElectoralPOC.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.UseCase
{
    public class SaveJsonToS3UseCase : ISaveJsonToS3UseCase
    {
        private ISaveJsonToS3Gateway _saveJsonToS3Gateway;

        public SaveJsonToS3UseCase(ISaveJsonToS3Gateway saveJsonToS3Gateway)
        {
            _saveJsonToS3Gateway = saveJsonToS3Gateway;
        }

        public void SaveJsonToS3Case(SaveJsonToS3Request request)
        {
            request.FileName = SaveJsonToS3Helper.EnsureFileIsJson(request.FileName);
            _saveJsonToS3Gateway.SaveJsonToS3(request);

        }
    }
}
