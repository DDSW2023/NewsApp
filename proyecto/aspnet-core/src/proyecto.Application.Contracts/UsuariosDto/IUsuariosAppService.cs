using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.UsuariosDto;

public interface IUsuariosAppService : IApplicationService
{
    Task<ICollection<UsuarioDto>> GetUsuarioAccesosAsync();

    Task<ICollection<UsuarioDto>> GetUsuarioBusquedasAsync();

    Task<UsuarioDto> GetUserIdByName(string user);
    
    Task<ICollection<UsuarioDto>> GetUsuarioNotificacionesAsync();

    Task<UsuarioDto> GetUsuarioAccesoAsync(int id);

    Task<UsuarioDto> GetUsuarioBusquedaAsync(int id);

    Task<UsuarioDto> GetUsuarioNotificacionAsync(int id);

    Task<UsuarioDto> CreateUsuarioAsync(CrearUsuarioDto input);

    Task<UsuarioDto> UpdateUsuarioAsync(int id, CrearUsuarioDto input);

    Task<UsuarioDto> DeleteUsuarioAsync(int id);

}