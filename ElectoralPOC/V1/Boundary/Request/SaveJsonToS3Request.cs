using Amazon.S3;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.V1.Boundary.Request
{
    public class SaveJsonToS3Request
    {
        [Required]
        public string FileName { get; set; }
        [Required]
        public string BucketName { get; set; }

        [Required]
        public string JsonData { get; set; }
    }
}
