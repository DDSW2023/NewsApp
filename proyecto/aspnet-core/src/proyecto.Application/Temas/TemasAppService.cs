using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace proyecto.Temas;

public class TemasAppService : proyectoAppService, ITemasAppService
{
    
    private readonly IRepository<Tema, int> _repository;

    public TemasAppService(IRepository<Tema, int> repository)
    {
        _repository = repository;
    }
    
    
    public async Task<ICollection<TemaDto>> GetTemaAsync()
    {
        var queryTemas = await _repository.WithDetailsAsync(x => x.TemaNoticias);

        var temas = await AsyncExecuter.ToListAsync(queryTemas);

        return ObjectMapper.Map<ICollection<Tema>, ICollection<TemaDto>>(temas);
    }

    public async Task<TemaDto> GetTemaAsync(int id)
    {
        var queryTemas = await _repository.WithDetailsAsync(x => x.TemaNoticias);

        var filtroTema = queryTemas.Where(x => x.Id == id);

        var tema = await AsyncExecuter.FirstOrDefaultAsync(filtroTema);

        return ObjectMapper.Map<Tema, TemaDto>(tema);
    }

    public async Task<TemaDto> CreateTemaAsync(CrearTemaDto input)
    {

        var tema = new Tema
        {
            nombre = input.nombre,
            descripcion = input.descripcion
        };

        await _repository.InsertAsync(tema);
        
        return ObjectMapper.Map<Tema, TemaDto>(tema);

    }

    public async Task<TemaDto> UpdateTemaAsync(int id, CrearTemaDto input)
    {
        var tema = await _repository.GetAsync(id);

        tema.descripcion = input.descripcion;
        tema.nombre = input.nombre; 

        await _repository.UpdateAsync(tema);

        return ObjectMapper.Map<Tema, TemaDto>(tema);
    }

    public async Task<TemaDto> DeleteTemaAsync(int id)
    {
        var queryTemas = await _repository.WithDetailsAsync(x => x.TemaNoticias);

        var filtroTemas = queryTemas.Where(x => x.Id == id);
        
        var tema = await AsyncExecuter.FirstOrDefaultAsync(filtroTemas);
        
        await _repository.DeleteAsync(id);
        
        return ObjectMapper.Map<Tema, TemaDto>(tema);
    }
}