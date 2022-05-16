using PathCaseAPI.Web.Identity.DTO.Responses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PathCaseAPI.Web.Identity.DTO.Responses
{
    public class GetAllResponseBase<T> : ResponseBase, IGetAllResponseBase<T> where T : class
    {
        public IList<T> DataList { get; set; }
        public int DataCount { get; set; }
    }
}
