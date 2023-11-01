using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.NotificacionesDto;

public interface INotificacionesAppService : IApplicationService
{

    Task<ICollection<NotificacionDto>> GetTemaAsync();

    Task<NotificacionDto> GetTemaAsync(int id);

    Task<NotificacionDto> CreateTemaAsync(CrearNotificacionDto input);

    Task<NotificacionDto> UpdateTemaAsync(int id, CrearNotificacionDto input);

    Task<NotificacionDto> DeleteTemaAsync(int id);

}