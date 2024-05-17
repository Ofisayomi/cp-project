using cp.Web.Application.Dto;
using cp.Web.Application.Interface;
using cp.Web.Domain;
using cp.Web.Persistence.Repository;

namespace cp.Web.Application.Services
{
    public class ProgramConfigsServices : IProgramConfigServices
    {
        private readonly IProgramConfigsRepository _programConfigsRepository;
        public ProgramConfigsServices(IProgramConfigsRepository programConfigsRepository)
        {
            _programConfigsRepository = programConfigsRepository;
        }

        public async Task<ResponseDto> CreateProgramConfig(CreateProgramConfigDto dto)
        {
            ProgramConfigs programConfigs = new ProgramConfigs
            {
                Description = dto.ProgramDescription,
                Title = dto.ProgramTitle,
                CustomQuestions = dto.CustomQuestions.Select(x => new CustomQuestions
                {
                    Question = x.Question,
                    QuestionType = x.QuestionType,
                    QuestionValues = x.QuestionValues?.Count == 0 ? null : x.QuestionValues
                }).ToList()
            };

            var response = await _programConfigsRepository.CreateItem(programConfigs);
            if (response.Item1)
            {
                return new ResponseDto { Status = true, Message = "Created Successfully", Data = response.Item2.Id };
            }

            return new ResponseDto { Status = false, Message = "An error occurred when creating question config" };
        }
    }
}