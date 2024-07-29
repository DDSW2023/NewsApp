using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using proyecto.Alertas1;
using proyecto.AlertasDto;
using proyecto.noticias;
using proyecto.Noticias;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using proyecto.NotificacionesDto;
using proyecto.Usuarios;
using proyecto.UsuariosDto;

namespace proyecto.Notificaciones;

public class NotificacionesAppService : proyectoAppService, INotificacionesAppService
{

    private readonly IRepository<Notificacion, int> _repository;
    private readonly IRepository<Noticia, int> _repositorynoticias;

    private readonly IRepository<Alerta, int> _repositoryalerta;
    private readonly IRepository<Usuario, int> _repositoryusuario;
    private readonly IUsuariosAppService _usuariosAppService;

    private readonly INoticiasAppService _noticiasAppService;

    public NotificacionesAppService(IRepository<Noticia, int> noticia, IRepository<Notificacion, int> repository, IUsuariosAppService user, INoticiasAppService noti, IRepository<Alerta, int> alerta)
    {
        _repository = repository;
        _noticiasAppService = noti;
        _repositoryalerta = alerta;
        _usuariosAppService = user;
        _repositorynoticias = noticia;
    }
    
    
    
    public async Task<AlertaDto> CreateAlertaAsync(CrearAlertaDto input, string textoBusqueda)
    {
        
            // Crear una nueva alerta
            var nuevaAlerta = new Alerta
            {
                descripcion = textoBusqueda,
                fecha = DateTime.Today
            };
            
            var alerta = await _repositoryalerta.InsertAsync(nuevaAlerta);

            return ObjectMapper.Map<Alerta, AlertaDto>(nuevaAlerta);

    }

    // Obtener la informacion de notificaciones de las alertas del usuario para el área de notificación.
    public async Task<List<NotificacionDto>> GetNotificacionUserAsync(string user)
    {
        var notificaciones = await _repository.GetListAsync();

        var userId = await _usuariosAppService.GetUserIdByName(user);
        
        var lista = new List<NotificacionDto>();

        foreach (var n in notificaciones)
        {
            if (n.UsuarioId == userId.Id)
            {
                var notificacionDto = new NotificacionDto
                {
                    AlertaId = n.AlertaId,
                    descripcion = n.descripcion,
                    fecha = n.fecha,
                    Id = n.Id,
                    UsuarioId = n.UsuarioId,
                    link = n.link
                };
                
                lista.Add(notificacionDto);
            }
        }

        return lista;
    }

    // Ejecucion asincrónica que busque los textos de las alertas en la API y persista la información de las notificaciones
    public async Task<List<NotificacionDto>> PersistirNotificaciones(int alertId, int userId)
    {
        var response = new List<NotificacionDto>();
        
        var alert = await _repositoryalerta.GetAsync(alertId);

        // Buscamos el texto de búsqueda en la API
        var noticias = await _noticiasAppService.Search(alert.descripcion, userId);

        foreach (var n in noticias)
        {
            // Creamos el objeto notificación
            var notificacion = new Notificacion
            {
                descripcion = "Nueva noticia: " + n.Titulo,
                AlertaId = alertId,
                fecha = DateTime.Now,
                link = n.Url,
                UsuarioId = userId
            };

            // Persistimos la notificación 
            
            var notificacionDto = ObjectMapper.Map<Notificacion, NotificacionDto>(notificacion);

            response.Add(notificacionDto);

            if (response.Count < 27)
            {
            _repository.InsertAsync(notificacion);
            }
            
        }


        return response;

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