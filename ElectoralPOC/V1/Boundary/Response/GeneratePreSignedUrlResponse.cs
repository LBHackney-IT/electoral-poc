using Newtonsoft.Json;
using System;

namespace ElectoralPOC.V1.Boundary.Response
{
    public class GeneratePreSignedUrlResponse
    {
        /// <example>
        /// Hackney
        /// </example>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
