

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

        private readonly INoticiasAppService _noticiasAppService;
        private readonly IRepository<Alerta, int> _repository;

        public AlertasAppService(IRepository<Alerta, int> repo, INoticiasAppService noti)
        {
            _repository = repo;
            _noticiasAppService = noti;
        }


        //Crear una alerta de nuevas noticias a partir de un texto de búsqueda

        public async Task<AlertaDto> CreateAlertaAsync(CrearAlertaDto input, string textoBusqueda, int userId)
        {
            var noticias = await _noticiasAppService.Search(textoBusqueda, userId);

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

        public async Task<ICollection<AlertaDto>> GetAlertaAsync(int id)
        {
            var noticia = await _repository.GetListAsync();
            return ObjectMapper.Map<ICollection<Alerta>, ICollection<AlertaDto>>(noticia);       
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