using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cp.Web.Application.Dto;
using cp.Web.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace cp.Web.Presentation
{
    public static class ProgramConfigEndpoints
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapPost("/custom-question", async ([FromServices] IProgramConfigServices _programConfigServices, [FromBody] CustomQuestionDto dto) =>
            {
                return await _programConfigServices.CreateCustomQuestion(dto);
            });

            app.MapPut("/custom-question/:Id", async ([FromServices] IProgramConfigServices _programConfigServices, string Id, [FromBody] CustomQuestionDto dto) =>
            {
                return await _programConfigServices.UpdateCustomQuestion(Id, dto);
            });

            app.MapGet("/custom-questions", async ([FromServices] IProgramConfigServices _programConfigServices) =>
            {
                return await _programConfigServices.GetCustomQuestions();
            });

            app.MapPost("/submit-application", async ([FromServices] IProgramConfigServices _programConfigServices, [FromBody] PersonSubmissionDto dto) =>
            {
                return await _programConfigServices.SubmitApplication(dto);
            });
        }
    }
}