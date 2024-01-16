using proyecto.AlertasDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.Alertas;
using proyecto.Notificaciones;
using proyecto.noticias;
using Volo.Abp.Domain.Repositories;
using proyecto.NotificacionesApp;

namespace proyecto.Notificacion1
{
    public class NotificacionAppService : proyectoAppService, INotificacionAppService
    {
        
        private readonly INotificacionAppService _notificacionService;

        private readonly IRepository<Notificacion, int> _repository;
    
        public NotificacionAppService(IRepository<Notificacion, int> repo, INotificacionAppService newsService)
        {
            _notificacionService = newsService;

            _repository = repo;
        }
        public async Task<NotificacionesResponseDto> CreateNotificacionAsync(NotificacionesRequestDto requestDto )
        {
            var nuevaNotificacion = new Notificacion
            {
                descripcion = requestDto.descripcion,
                fecha = DateTime.Today,
                UsuarioId = requestDto.UsuarioId,
                AlertaId = requestDto.AlertaId,
                link = ""
            };

            await _repository.InsertAsync(nuevaNotificacion);
            return ObjectMapper.Map<Notificacion, NotificacionesResponseDto>(nuevaNotificacion);
        }

       
    }
}