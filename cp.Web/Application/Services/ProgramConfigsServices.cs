using cp.Web.Application.Dto;
using cp.Web.Application.Interface;
using cp.Web.Domain;
using cp.Web.Persistence.Repository;

namespace cp.Web.Application.Services
{
    public class ProgramConfigsServices : IProgramConfigServices
    {
        private readonly ICustomQuestionRepository _programConfigsRepository;
        private readonly IPersonSubmissionRepository _personSubmissionRepository;
        public ProgramConfigsServices(ICustomQuestionRepository programConfigsRepository, IPersonSubmissionRepository personSubmissionRepository)
        {
            _programConfigsRepository = programConfigsRepository;
            _personSubmissionRepository = personSubmissionRepository;
        }

        public async Task<ResponseDto<string>> CreateCustomQuestion(CustomQuestionDto dto)
        {
            //Todo: Handle Validation of Question type

            CustomQuestions customQuestion = new CustomQuestions
            {
                QuestionType = dto.QuestionType,
                Question = dto.Question,
                QuestionValues = dto.QuestionValues?.Count == 0 ? null : dto.QuestionValues
            };

            var response = await _programConfigsRepository.CreateItem(customQuestion);
            if (response.Item1)
            {
                return new ResponseDto<string> { Status = true, Message = "Created Successfully", Data = response.Item2.Id };
            }

            return new ResponseDto<string> { Status = false, Message = "An error occurred when creating question config" };
        }

        public async Task<ResponseDto<string>> UpdateCustomQuestion(string Id, CustomQuestionDto dto)
        {
            var existingQuestion = await _programConfigsRepository.GetItem(Id);
            if (existingQuestion == null)
            {
                return new ResponseDto<string> { Status = false, Message = "Invalid Id supplied" };
            }

            existingQuestion.QuestionValues = dto.QuestionValues;
            existingQuestion.Question = dto.Question;
            existingQuestion.QuestionType = dto.QuestionType;

            var resp = await _programConfigsRepository.UpdateItem(Id, existingQuestion);
            if (resp.Item1)
            {
                return new ResponseDto<string> { Status = true, Data = resp.Item2.Id, Message = "Successful" };
            }

            return new ResponseDto<string> { Status = false, Message = "An error occurred while updating entry" };
        }

        public async Task<ResponseDto<List<GetCustomQuestionDto>>> GetCustomQuestions()
        {
            var customQuestions = await _programConfigsRepository.GetItems("SELECT * FROM c");
            List<GetCustomQuestionDto> questions = customQuestions.Select(x => new GetCustomQuestionDto
            {
                Question = x.Question,
                QuestionType = x.QuestionType,
                QuestionValues = x?.QuestionValues,
                Id = x.Id
            }).ToList();

            return new ResponseDto<List<GetCustomQuestionDto>> { Data = questions, Status = true, Message = "Successful" };
        }

        public async Task<ResponseDto<string>> SubmitApplication(PersonSubmissionDto dto)
        {
            PersonSubmissions personSubmissions = new PersonSubmissions
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                CurrentResidence = dto.CurrentResidence,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                IdNumber = dto.IdNumber,
                Nationality = dto.Nationality,
                PhoneNumber = dto.Phone,
                CustomAnswers = dto.CustomAnswerDtos.Select(x => new CustomAnswer
                {
                    SubmittedAnswers = x.Answer,
                    Question = x.Question,
                }).ToList()
            };

            var response = await _personSubmissionRepository.CreateItem(personSubmissions);
            if (response.Item1)
            {
                return new ResponseDto<string> { Status = true, Message = "Created Successfully", Data = response.Item2.Id };
            }

            return new ResponseDto<string> { Status = false, Message = "An error occurred when creating question config" };
        }
    }
}