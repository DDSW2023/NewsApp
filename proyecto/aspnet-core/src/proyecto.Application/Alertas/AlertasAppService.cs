using proyecto.AlertasDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;
using proyecto.noticias;
using Volo.Abp.Domain.Repositories;
using proyecto.Alertas;
using proyecto.Notificaciones;
using proyecto.Noticias;

namespace proyecto.Alertas1
{

    public class AlertasAppService : proyectoAppService, IAlertasAppService
    {

        private readonly IAlertasAppService _alertasService;
        private readonly INoticiasAppService _noticiasAppService;
        private readonly IRepository<Alerta, int> _repository;

        public AlertasAppService(IRepository<Alerta, int> repo, IAlertasAppService newsService)
        {
            _alertasService = newsService;
            _repository = repo;
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