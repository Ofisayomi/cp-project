using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cp.Web.Application.Dto
{
    public class PersonSubmissionDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public List<CustomAnswerDto> CustomAnswerDtos { get; set; }

    }
}