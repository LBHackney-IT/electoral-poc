using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Boundary.Response
{
    /// <typeparam name="T"></typeparam>

    public class APIResponse<T> where T : class
    {
        /// <example>
        /// Hackney
        /// </example>
        [JsonProperty("json")]
        public T JsonData { get; set; }

        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }


        public APIResponse() { }

        public APIResponse(T result)
        {
            StatusCode = (int) HttpStatusCode.OK;
            JsonData = result;
        }
    }
}
