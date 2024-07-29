using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using proyecto.Accesos;
using proyecto.noticias;
using Volo.Abp.Domain.Repositories;
using IQueryable = System.Linq.IQueryable;

namespace proyecto.Noticias;

public class NoticiasAppService : proyectoAppService, INoticiasAppService
{

    private readonly INoticiasService _noticiasService;
    
    private readonly IRepository<Noticia, int> _repository;
    private readonly IRepository<Acceso, int> _repositoryacceso;


    public NoticiasAppService(IRepository<Acceso, int> acceso, IRepository<Noticia, int> repo, INoticiasService newsService)
    {
        _noticiasService = newsService;
        _repositoryacceso = acceso;
        _repository = repo;
    }

    // Realizar una búsqueda en NewsApi y devolver los resultados.
    // Obtención información estadística de monitoreo de los accesos a la API.
    public async Task<ICollection<ArticuloDto>> Search(string query, int userId)
    {
        // Crear y comenzar el cronómetro
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Ejecutar la consulta asíncrona
        var noticia = await _noticiasService.GetNewsAsync(query);

        // Detener el cronómetro
        stopwatch.Stop();

        // Obtener el tiempo transcurrido
        long time = stopwatch.ElapsedMilliseconds;

        var acceso = new Acceso
        {
            fecha = DateTime.Now,
            tiempoConsulta = time,
            UsuarioId = userId
        };

        await _repositoryacceso.InsertAsync(acceso);
        
        return noticia;                 
    }

    public async Task<NoticiaDto> CreateNoticia(CrearNoticiasDto noticia)
    {
        string descripcion = noticia.descripcion;
        string primeros100Caracteres = descripcion.Substring(0, Math.Min(descripcion.Length, 100));

        var noti = new Noticia
        {
            descripcion = primeros100Caracteres,
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
    
    public async Task<IQueryable<NoticiaDto>> GetNoticias()
    {
        var noticia = await _repository.GetQueryableAsync();
        return ObjectMapper.Map<IQueryable<Noticia>, IQueryable<NoticiaDto>>(noticia);
    }
}