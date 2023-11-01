using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.ErroresDto;

public interface IErroresAppService : IApplicationService
{

    Task<ICollection<ErrorDto>> GetTemaAsync();

    Task<ErrorDto> GetTemaAsync(int id);

    Task<ErrorDto> CreateTemaAsync(CrearErrorDto input);

    Task<ErrorDto> UpdateTemaAsync(int id, CrearErrorDto input);

    Task<ErrorDto> DeleteTemaAsync(int id);

}
