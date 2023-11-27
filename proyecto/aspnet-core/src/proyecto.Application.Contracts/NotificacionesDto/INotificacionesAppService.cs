using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.NotificacionesDto;

public interface INotificacionesAppService : IApplicationService
{

  //Task<ICollection<NotificacionDto>> GetNotificacionAsync();

    Task<NotificacionDto> GetNotificacionAsync(int id);

    Task<NotificacionDto> CreateNotificacionAsync(CrearNotificacionDto input);

    Task<NotificacionDto> UpdateNotificacionAsync(int id, CrearNotificacionDto input);

    Task<NotificacionDto> DeleteNotificacionAsync(int id);

}