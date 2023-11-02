using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.UsuariosDto;

public interface IUsuariosAppService : IApplicationService
{
    Task<ICollection<UsuarioDto>> GetUsuarioAsync();

    Task<UsuarioDto> GetUsuarioAsync(int id);

    Task<UsuarioDto> CreateUsuarioAsync(CrearUsuarioDto input);

    Task<UsuarioDto> UpdateUsuarioAsync(int id, CrearUsuarioDto input);

    Task<UsuarioDto> DeleteUsuarioAsync(int id);

}