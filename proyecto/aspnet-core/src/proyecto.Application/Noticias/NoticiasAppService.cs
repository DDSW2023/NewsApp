using System.Collections.Generic;
using System.Threading.Tasks;
using proyecto.noticias;

<<<<<<< HEAD

namespace proyecto.Noticias
{
    public class NoticiasAppService : proyectoAppService, INoticiasAppService
    {
        private readonly INoticiasService _noticiasService;

        public NoticiasAppService(INoticiasService noticiasService)
        {
            _noticiasService = noticiasService;
        }

        public Task<ICollection<NoticiaDto>> Search(string query)
        {
            throw new NotImplementedException();
        }
=======
namespace proyecto.Noticias;

public class NoticiasAppService : proyectoAppService, INoticiasAppService
{

    private readonly INoticiasService _noticiasService;

    public NoticiasAppService(INoticiasService newsService)
    {
        _noticiasService = newsService;
>>>>>>> 0a4434e97851e0decfdb5a6dcd0d967255475149
    }
    
    public async Task<ICollection<ArticuloDto>> Search(string query)
    {
        var noticia = await _noticiasService.GetNewsAsync(query);

        return noticia;                 
    }
    
}