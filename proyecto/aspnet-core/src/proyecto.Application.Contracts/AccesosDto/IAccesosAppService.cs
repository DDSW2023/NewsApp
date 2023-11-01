using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.AccesosDto;

public interface IAccesosAppService : IApplicationService
{

    Task<ICollection<AccesoDto>> GetTemaAsync();

    Task<AccesoDto> GetTemaAsync(int id);

    Task<AccesoDto> CreateTemaAsync(CrearAccesoDto input);

    Task<AccesoDto> UpdateTemaAsync(int id, CrearAccesoDto input);

    Task<AccesoDto> DeleteTemaAsync(int id);

}