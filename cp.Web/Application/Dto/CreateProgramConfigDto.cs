using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cp.Web.Application.Dto
{
    public class CreateProgramConfigDto
    {
        [Required]
        public string ProgramTitle { get; set; }
        [Required]
        public string ProgramDescription { get; set; }
        public List<CreateCustomQuestionDto> CustomQuestions { get; set; }
    }
}