using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.UsuariosDto;

public interface IUsuariosAppService : IApplicationService
{
    Task<ICollection<UsuarioDto>> GetTemaAsync();

    Task<UsuarioDto> GetTemaAsync(int id);

    Task<UsuarioDto> CreateTemaAsync(CrearUsuarioDto input);

    Task<UsuarioDto> UpdateTemaAsync(int id, CrearUsuarioDto input);

    Task<UsuarioDto> DeleteTemaAsync(int id);

}