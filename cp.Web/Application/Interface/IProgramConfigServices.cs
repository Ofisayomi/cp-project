using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cp.Web.Application.Dto;

namespace cp.Web.Application.Interface
{
    public interface IProgramConfigServices
    {
        Task<ResponseDto<string>> CreateCustomQuestion(CustomQuestionDto dto);
        Task<ResponseDto<string>> UpdateCustomQuestion(string Id, CustomQuestionDto dto);
        Task<ResponseDto<List<GetCustomQuestionDto>>> GetCustomQuestions();
        Task<ResponseDto<string>> SubmitApplication(PersonSubmissionDto dto);
    }
}