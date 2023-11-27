using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.BusquedasDto;

public interface IBusquedasAppService : IApplicationService
{

    //Task<ICollection<BusquedaDto>> GetBusquedaAsync();

    Task<BusquedaDto> GetBusquedaAsync(int id);

    Task<BusquedaDto> CreateBusquedaAsync(CrearBusquedaDto input);

    Task<BusquedaDto> UpdateBusquedaAsync(int id, CrearBusquedaDto input);

    Task<BusquedaDto> DeleteBusquedaAsync(int id);

}