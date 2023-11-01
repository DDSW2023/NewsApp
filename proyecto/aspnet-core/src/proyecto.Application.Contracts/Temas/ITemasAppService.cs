using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.Temas;

public interface ITemasAppService : IApplicationService
{

    Task<ICollection<TemaDto>> GetTemaAsync();

    Task<TemaDto> GetTemaAsync(int id);
    
    Task<TemaDto> CreateTemaAsync(CrearTemaDto input);
    
    Task<TemaDto> UpdateTemaAsync(int id, CrearTemaDto input);
    
    Task<TemaDto> DeleteTemaAsync(int id);
    
}