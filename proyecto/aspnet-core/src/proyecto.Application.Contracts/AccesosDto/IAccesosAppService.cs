using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.AccesosDto;

public interface IAccesosAppService : IApplicationService
{
    Task<MonitoreoResponseDto> GetMonitoreo(DateTime fechaInicio, DateTime fechaFin);

    Task<ICollection<AccesoDto>> GetAccesoAsync();

    Task<AccesoDto> GetAccesoAsync(int id);

    Task<AccesoDto> CreateAccesoAsync(CrearAccesoDto input);

    Task<AccesoDto> UpdateAccesoAsync(int id, CrearAccesoDto input);

    Task<AccesoDto> DeleteAccesoAsync(int id);

}