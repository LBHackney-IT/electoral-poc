using Newtonsoft.Json;
using System;

namespace ElectoralPOC.V1.Boundary.Response
{
    public class SaveJsonToS3Response
    {
        /// <example>
        /// Hackney
        /// </example>
        [JsonProperty("json")]
        public string JsonData { get; set; }


    }
}
