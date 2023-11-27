using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.ErroresDto;

public interface IErroresAppService : IApplicationService
{

 // Task<ICollection<ErrorDto>> GetErrorAsync();

    Task<ErrorDto> GetErrorAsync(int id);

    Task<ErrorDto> CreateErrorAsync(CrearErrorDto input);

    Task<ErrorDto> UpdateErrorAsync(int id, CrearErrorDto input);

    Task<ErrorDto> DeleteErrorAsync(int id);

}
