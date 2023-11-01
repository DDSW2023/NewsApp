using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.BusquedasDto;

public interface IBusquedasAppService : IApplicationService
{

    Task<ICollection<BusquedaDto>> GetTemaAsync();

    Task<BusquedaDto> GetTemaAsync(int id);

    Task<BusquedaDto> CreateTemaAsync(CrearBusquedaDto input);

    Task<BusquedaDto> UpdateTemaAsync(int id, CrearBusquedaDto input);

    Task<BusquedaDto> DeleteTemaAsync(int id);

}