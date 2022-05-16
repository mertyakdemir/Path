using PathCaseAPI.Web.Identity.DTO.Responses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathCaseAPI.Web.Identity.DTO.Responses
{
    public class IdResponseBase : ResponseBase, IIdResponseBase
    {
        public int Id { get; set; }
    }
}
