using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckMyDropi.Api.Core.DTOs
{
    public abstract  class BaseResponse
    {
        public bool Success { get; }
        public string Message { get; }
        public IEnumerable<string> Errors { get; }

        protected BaseResponse(IEnumerable<string> errors, bool success = false, string message = null)
        {
            Success = success;
            Message = message;
            Errors = errors;
        }

        public BaseResponse(bool success = false, string message = null) 
        {
            Success = success;
            Message = message;
        }
    }
}
