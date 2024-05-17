using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using cp.Web.Application.Enums;
using Newtonsoft.Json;

namespace cp.Web.Application.Dto
{
    public class CustomQuestionDto
    {
        [Required]
        public string QuestionType { get; set; }
        [Required]
        public string Question { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string>? QuestionValues { get; set; }
    }

    public class GetCustomQuestionDto : CustomQuestionDto
    {
        public string Id { get; set; }
    }

}