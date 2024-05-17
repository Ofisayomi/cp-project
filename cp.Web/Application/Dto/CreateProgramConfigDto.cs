using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cp.Web.Application.Dto
{
    public class CreateProgramConfigDto
    {
        public List<CustomQuestionDto> CustomQuestions { get; set; }
    }
}