using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathCaseAPI.Web.Identity.DTO.Responses.Interfaces
{
    public interface IGetByIdResponseBase<T> : IResponseBase where T : class
    {
        public T Data { get; set; }
    }
}
