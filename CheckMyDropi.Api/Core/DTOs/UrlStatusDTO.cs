using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckMyDropi.Api.Core.DTOs
{
    public class UrlStatusDTO : BaseResponse
    {
        public int Id { get; }
        public string Url { get; }
        public bool malicius { get; }

        public UrlStatusDTO(bool success, int id, string url, bool malicius, string message = null) : base(success, message)
        {
            Id = id;
            Url = url;
            this.malicius = malicius;
        }
    }
}
