using PathCaseAPI.Web.Identity.DTO.Responses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathCaseAPI.Web.Identity.DTO.Responses
{
    public class ResponseBase : IResponseBase
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
