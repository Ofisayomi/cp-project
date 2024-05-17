using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cp.Web.Application.Dto
{
    public class CustomAnswerDto
    {
        public string Question { get; set; }
        public List<string> Answer { get; set; }
    }
}