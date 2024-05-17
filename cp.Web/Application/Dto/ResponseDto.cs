using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cp.Web.Application.Dto
{
    public class ResponseDto<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }
}