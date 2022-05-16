using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathCaseAPI.Web.Identity.DTO.Responses.Interfaces
{
    public interface IResponseBase
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
