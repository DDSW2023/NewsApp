using System;
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
            tiempoConsulta = 0,
            UsuarioId = input.UsuarioId,
        };
        await _repository.InsertAsync(acceso);
        return ObjectMapper.Map<Acceso, AccesoDto>(acceso);
    }
    public async Task<AccesoDto> UpdateAccesoAsync(int id, CrearAccesoDto input)
    {
        var acceso = await _repository.GetAsync(id);
        acceso.fecha = input.fecha;
        acceso.UsuarioId = input.UsuarioId;
        await _repository.UpdateAsync(acceso);
        return ObjectMapper.Map<Acceso, AccesoDto>(acceso);
    }

    public async Task<MonitoreoResponseDto> GetMonitoreo(DateTime fechaInicio, DateTime fechaFin)
    {
        // Inicializamos la response
        var response = new MonitoreoResponseDto();
        response.Accesos = new List<AccesoDto>();
        
        // Declaramos los contadores
        var total = 0;
        float tiempoTotal = 0;
        float tiempoPromedio = 0;
        
        var accesos = await _repository.GetListAsync();

        foreach (var a in accesos)
        {
            // Chequeamos que esté entre las fechas
            if (a.fecha >= fechaInicio && a.fecha <= fechaFin)
            {
                
            
            // Sumamos los contadores
            total = total + 1;
            tiempoTotal = tiempoTotal + a.tiempoConsulta;

            var accesoDto = new AccesoDto
            {
                fecha = a.fecha,
                tiempoAcceso = a.tiempoConsulta,
                Id = a.Id,
                UsuarioId = a.UsuarioId
            };
            
            response.Accesos.Add(accesoDto);
            }
        }

        if (total > 0)
        {
            tiempoPromedio = tiempoTotal / total;
        }
        else
        {
            tiempoPromedio = 0;
        }

        response.tiempoPromedio = tiempoPromedio;
        response.cantidadAccesos = total;

        return response;
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