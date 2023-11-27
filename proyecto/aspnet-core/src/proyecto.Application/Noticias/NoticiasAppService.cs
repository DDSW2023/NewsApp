using System.Collections.Generic;
using System.Threading.Tasks;
using proyecto.noticias;
using Volo.Abp.Domain.Repositories;

namespace proyecto.Noticias;

public class NoticiasAppService : proyectoAppService, INoticiasAppService
{

    private readonly INoticiasService _noticiasService;
    
    private readonly IRepository<Noticia, int> _repository;


    public NoticiasAppService( IRepository<Noticia, int> repo, INoticiasService newsService)
    {
        _noticiasService = newsService;
        _repository = repo;
    }
    
    public async Task<ICollection<ArticuloDto>> Search(string query)
    {
        var noticia = await _noticiasService.GetNewsAsync(query);

        return noticia;                 
    }

    public async Task<NoticiaDto> CreateNoticia(CrearNoticiasDto noticia)
    {
        var noti = new Noticia
        {
            descripcion = noticia.descripcion,
            fecha = noticia.fecha,
            titulo = noticia.titulo,
            autor = noticia.autor,
            url = noticia.url,
            urlImagen = noticia.urlImagen,
            Contenido = noticia.Contenido,
            tema = noticia.tema,
            ListaNoticiasId = noticia.ListaNoticiasId
        };
                
        await _repository.InsertAsync(noti);
        
        return ObjectMapper.Map<Noticia, NoticiaDto>(noti);

    }

    public async Task<NoticiaDto> GetNoticia(int noticiaId)
    {
        var noticia = await _repository.GetAsync(noticiaId);
        return ObjectMapper.Map<Noticia, NoticiaDto>(noticia);
    }
}