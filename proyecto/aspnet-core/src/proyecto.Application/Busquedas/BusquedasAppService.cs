using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using proyecto.BusquedasDto;

namespace proyecto.Busquedas;

public class BusquedasAppService : proyectoAppService, IBusquedasAppService
{

    private readonly IRepository<Busqueda, int> _repository;

    public BusquedasAppService(IRepository<Busqueda, int> repository)
    {
        _repository = repository;
    }

    public async Task<BusquedaDto> CreateBusquedaAsync(CrearBusquedaDto input)
    {
        var busqueda = new Busqueda
        {
            parametro = input.parametro,
            UsuarioId = input.UsuarioId,
        };
        await _repository.InsertAsync(busqueda);
        return ObjectMapper.Map<Busqueda, BusquedaDto>(busqueda);
    }
    public async Task<BusquedaDto> UpdateBusquedaAsync(int id, CrearBusquedaDto input)
    {
        var busqueda = await _repository.GetAsync(id);
        busqueda.parametro = input.parametro;
        busqueda.UsuarioId = input.UsuarioId;
        await _repository.UpdateAsync(busqueda);
        return ObjectMapper.Map<Busqueda, BusquedaDto>(busqueda);
    }

    public async Task<BusquedaDto> GetBusquedaAsync(int id)
    {
        var busqueda = await _repository.GetAsync(id);
        return ObjectMapper.Map<Busqueda, BusquedaDto>(busqueda);
    }

    public async Task<BusquedaDto> DeleteBusquedaAsync(int id)
    { 
        var busqueda = await _repository.GetAsync(id);
        await _repository.DeleteAsync(id);
        return ObjectMapper.Map<Busqueda, BusquedaDto>(busqueda);
    }
}