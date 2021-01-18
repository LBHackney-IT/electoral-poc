using Newtonsoft.Json;

namespace ElectoralPOC.V1.Boundary.Response
{
    //TODO: Rename to represent to object you will be returning eg. ResidentInformation, HouseholdDetails e.t.c
    public class GeneratePreSignedUrlResponse
    {
        /// <example>
        /// Hackney
        /// </example>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
