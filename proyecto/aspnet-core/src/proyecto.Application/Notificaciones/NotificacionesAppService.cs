using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using proyecto.NotificacionesDto;

namespace proyecto.Notificaciones;

public class NotificacionesAppService : proyectoAppService, INotificacionesAppService
{

    private readonly IRepository<Notificacion, int> _repository;

    public NotificacionesAppService(IRepository<Notificacion, int> repository)
    {
        _repository = repository;
    }

    public async Task<NotificacionDto> CreateNotificacionAsync(CrearNotificacionDto input)
    {
        var notificacion = new Notificacion
        {            
            fecha = input.fecha,
            descripcion = input.descripcion,
            link = input.link,
            UsuarioId = input.UsuarioId,
            AlertaId = input.AlertaId,
        };
        await _repository.InsertAsync(notificacion);
        return ObjectMapper.Map<Notificacion, NotificacionDto>(notificacion);
    }
    public async Task<NotificacionDto> UpdateNotificacionAsync(int id, CrearNotificacionDto input)
    {
        var notificacion = await _repository.GetAsync(id);
        notificacion.fecha = input.fecha;
        notificacion.descripcion = input.descripcion;
        notificacion.link = input.link;
        notificacion.UsuarioId = input.UsuarioId;
        notificacion.AlertaId = input.AlertaId;
        await _repository.UpdateAsync(notificacion);
        return ObjectMapper.Map<Notificacion, NotificacionDto>(notificacion);
    }

    public async Task<NotificacionDto> GetNotificacionAsync(int id)
    {
        var notificacion = await _repository.GetAsync(id);
        return ObjectMapper.Map<Notificacion, NotificacionDto>(notificacion);
    }

    public async Task<NotificacionDto> DeleteNotificacionAsync(int id)
    {
        var notificacion = await _repository.GetAsync(id);
        await _repository.DeleteAsync(id);
        return ObjectMapper.Map<Notificacion, NotificacionDto>(notificacion);
    }
}