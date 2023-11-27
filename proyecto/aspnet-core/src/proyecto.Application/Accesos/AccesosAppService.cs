using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using proyecto.AccesosDto;

namespace proyecto.Accesos;

public class AccesosAppService : proyectoAppService, IAccesosAppService
{

    private readonly IRepository<Acceso, int> _repository;

    public AccesosAppService(IRepository<Acceso, int> repository)
    {
        _repository = repository;
    }

    public async Task<AccesoDto> CreateAccesoAsync(CrearAccesoDto input)
    {
        var acceso = new Acceso
        {
            fecha = input.fecha,
            horaInicio = input.horaInicio,
            horaFin = input.horaFin,
            UsuarioId = input.UsuarioId,
        };
        await _repository.InsertAsync(acceso);
        return ObjectMapper.Map<Acceso, AccesoDto>(acceso);
    }
    public async Task<AccesoDto> UpdateAccesoAsync(int id, CrearAccesoDto input)
    {
        var acceso = await _repository.GetAsync(id);
        acceso.fecha = input.fecha;
        acceso.horaInicio = input.horaInicio;
        acceso.horaFin = input.horaFin;
        acceso.UsuarioId = input.UsuarioId;
        await _repository.UpdateAsync(acceso);
        return ObjectMapper.Map<Acceso, AccesoDto>(acceso);
    }

    public async Task<ICollection<AccesoDto>> GetAccesoAsync()
    {
        var queryAccesos = await _repository.WithDetailsAsync(x => x.Errores);
        var accesos = await AsyncExecuter.ToListAsync(queryAccesos);
        return ObjectMapper.Map<ICollection<Acceso>, ICollection<AccesoDto>>(accesos);
    }

    public async Task<AccesoDto> GetAccesoAsync(int id)
    {
        var queryAccesos = await _repository.WithDetailsAsync(x => x.Errores);
        var filtroAcceso = queryAccesos.Where(x => x.Id == id);
        var acceso = await AsyncExecuter.FirstOrDefaultAsync(filtroAcceso);
        return ObjectMapper.Map<Acceso, AccesoDto>(acceso);
    }

    public async Task<AccesoDto> DeleteAccesoAsync(int id)
    {
        var queryAccesos = await _repository.WithDetailsAsync(x => x.Errores);
        var filtroAccesos = queryAccesos.Where(x => x.Id == id);
        var acceso = await AsyncExecuter.FirstOrDefaultAsync(filtroAccesos);
        await _repository.DeleteAsync(id);
        return ObjectMapper.Map<Acceso, AccesoDto>(acceso);
    }
}