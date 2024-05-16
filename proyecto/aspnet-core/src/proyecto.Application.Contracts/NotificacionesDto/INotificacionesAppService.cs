using System.Collections.Generic;
using System.Threading.Tasks;
using proyecto.AlertasDto;
using Volo.Abp.Application.Services;

namespace proyecto.NotificacionesDto;

public interface INotificacionesAppService : IApplicationService
{

  //Task<ICollection<NotificacionDto>> GetNotificacionAsync();
  
  //Alerta
  Task<AlertaDto> CreateAlertaAsync(CrearAlertaDto input, string textoBusqueda);

    Task<List<NotificacionDto>> GetNotificacionUserAsync(string user);
    
    Task<List<NotificacionDto>> PersistirNotificaciones(int alertId, int userId);
  
    Task<NotificacionDto> GetNotificacionAsync(int id);

    Task<NotificacionDto> CreateNotificacionAsync(CrearNotificacionDto input);

    Task<NotificacionDto> UpdateNotificacionAsync(int id, CrearNotificacionDto input);

    Task<NotificacionDto> DeleteNotificacionAsync(int id);

}