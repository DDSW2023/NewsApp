

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyecto.Alertas1;
using proyecto.AlertasDto;
using proyecto.Noticias;
using proyecto.Notificaciones;
using Volo.Abp.Domain.Repositories;

namespace proyecto.Alertas
{

    public class AlertasAppService : proyectoAppService, IAlertasAppService
    {

        private readonly IAlertasAppService _alertasService;
        private readonly INoticiasAppService _noticiasAppService;
        private readonly IRepository<Alerta, int> _repository;

        public AlertasAppService(IRepository<Alerta, int> repo, IAlertasAppService newsService, INoticiasAppService noti)
        {
            _alertasService = newsService;
            _repository = repo;
            _noticiasAppService = noti;
        }
        public async Task<AlertaDto> CreateAlertaAsync(CrearAlertaDto input, string textoBusqueda)
        {
            var noticias = await _noticiasAppService.Search(textoBusqueda);

            if (noticias.Any())
            {
                // Crear una nueva alerta
                var nuevaAlerta = new Alerta
                {
                    descripcion = textoBusqueda,
                    fecha = DateTime.Today
                };

                // Asociar las noticias encontradas con la alerta
                nuevaAlerta.Notificaciones = noticias.Select(noticia => new Notificacion { descripcion = noticia.Descripcion }).ToList();

      //          foreach (var n in noticias)
        //        {
          //          var notificacion = new Notificacion
            //        {
             //           fecha = n.FechaPublicado,
               //         descripcion = n.Descripcion,
                 //       link = n.Url
                   // };
                    
                   // nuevaAlerta.Notificaciones.Add(notificacion);
               // }

                var alerta = await _repository.InsertAsync(nuevaAlerta);

                return ObjectMapper.Map<Alerta, AlertaDto>(nuevaAlerta);
            }
            else
            {
                throw new Exception("No se encontraron noticias que coincidan con el texto de búsqueda.");
            }
        }
        

        public Task<AlertaDto> DeleteAlertaAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AlertaDto>> GetAlertaAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AlertaDto> GetAlertaAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AlertaDto> UpdateAlertaAsync(int id, CrearAlertaDto input)
        {
            throw new NotImplementedException();
        }
    }
}