using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cp.Web.Application.Dto;

namespace cp.Web.Application.Interface
{
    public interface IProgramConfigServices
    {
        Task<ResponseDto> CreateProgramConfig(CreateProgramConfigDto dto);
    }
}