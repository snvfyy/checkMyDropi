using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheckMyDropi.Api.Data.Entities
{
    public class MaliciousLink
    {
        public string Url { get; set; }

        [Key]
        public int IdMaliciousLink { get; set; }
    }
}
