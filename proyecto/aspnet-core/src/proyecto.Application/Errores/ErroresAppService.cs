using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using proyecto.ErroresDto;

namespace proyecto.Errores;

public class ErroresAppService : proyectoAppService, IErroresAppService
{

    private readonly IRepository<Error, int> _repository;

    public ErroresAppService(IRepository<Error, int> repository)
    {
        _repository = repository;
    }

    public async Task<ErrorDto> CreateErrorAsync(CrearErrorDto input)
    {
        var error = new Error
        {
            descripcion = input.descripcion,
            AccesoId = input.AccesoId,
        };
        await _repository.InsertAsync(error);
        return ObjectMapper.Map<Error, ErrorDto>(error);
    }
    public async Task<ErrorDto> UpdateErrorAsync(int id, CrearErrorDto input)
    {
        var error = await _repository.GetAsync(id);
        error.descripcion = input.descripcion;
        error.AccesoId = input.AccesoId;
        await _repository.UpdateAsync(error);
        return ObjectMapper.Map<Error, ErrorDto>(error);
    }

    public async Task<ErrorDto> GetErrorAsync(int id)
    {
        var error = await _repository.GetAsync(id);
        return ObjectMapper.Map<Error, ErrorDto>(error);
    }

    public async Task<ErrorDto> DeleteErrorAsync(int id)
    {
        var error = await _repository.GetAsync(id);
        await _repository.DeleteAsync(id);
        return ObjectMapper.Map<Error, ErrorDto>(error);
    }
}