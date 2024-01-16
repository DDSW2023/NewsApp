using System.Threading.Tasks;
using proyecto.Notificaciones;

namespace proyecto.NotificacionesApp;

public interface INotificacionAppService
{
    public Task<NotificacionesResponseDto> CreateNotificacionAsync(NotificacionesRequestDto requestDto);
}