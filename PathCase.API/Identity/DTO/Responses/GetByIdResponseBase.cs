using PathCaseAPI.Web.Identity.DTO.Responses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathCaseAPI.Web.Identity.DTO.Responses
{
    public class GetByIdResponseBase<T> : ResponseBase, IGetByIdResponseBase<T> where T : class
    {
        public T Data { get; set; }
    }
}
