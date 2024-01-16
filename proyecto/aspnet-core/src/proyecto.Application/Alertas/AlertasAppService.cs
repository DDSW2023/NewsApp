using proyecto.AlertasDto;
using proyecto.noticias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace proyecto.Alertas;

public class AlertasAppService : proyectoAppService, IAlertasAppService
{
    //private readonly IAlertasAppService _alertasService;

    private readonly IRepository<Alerta, int> _repository;
    
    public AlertasAppService(IRepository<Alerta, int> repo, IAlertasAppService newsService)
    {
       // _alertasService = newsService;

        _repository = repo;
    }
    
   
        public async Task<AlertaDto> CreateAlertaAsync(CrearAlertaDto input, Noticia query)
        {
        var nuevaAlerta = new Alerta
        {
            descripcion = query.titulo,
            fecha = DateTime.Today,
            ListaNoticia = query.ListaNoticia,
            ListaNoticiaId = query.ListaNoticiasId,
        };


        await _repository.InsertAsync(nuevaAlerta);
        return ObjectMapper.Map<Alerta, AlertaDto>(nuevaAlerta);


        }


        public Task<AlertaDto> DeleteAlertaAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AlertaDto>> GetAlertaAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AlertaDto> UpdateAlertaAsync(int id, CrearAlertaDto input)
        {
            throw new NotImplementedException();
        }

        Task<AlertaDto> IAlertasAppService.GetAlertaAsync()
        {
            throw new NotImplementedException();
        }
     }
}