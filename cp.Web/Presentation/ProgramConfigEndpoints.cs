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
            app.MapPost("/program-config", async ([FromServices] IProgramConfigServices _programConfigServices, [FromBody] CreateProgramConfigDto dto) =>
            {
                return await _programConfigServices.CreateProgramConfig(dto);
            });
        }
    }
}