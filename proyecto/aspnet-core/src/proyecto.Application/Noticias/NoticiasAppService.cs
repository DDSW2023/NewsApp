using System.Collections.Generic;
using System.Threading.Tasks;
using proyecto.noticias;

namespace proyecto.Noticias;

public class NoticiasAppService : proyectoAppService, INoticiasAppService
{

    private readonly INoticiasService _noticiasService;

    public NoticiasAppService(INoticiasService newsService)
    {
        _noticiasService = newsService;
    }
    
    public async Task<ICollection<ArticuloDto>> Search(string query)
    {
        var noticia = await _noticiasService.GetNewsAsync(query);

        return noticia;                 
    }
    
}