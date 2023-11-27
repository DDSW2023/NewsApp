using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto.ListaNoticiasDto;
using proyecto.noticias;
using proyecto.Noticias;
using Volo.Abp.Domain.Repositories;

namespace proyecto.ListaNoticias
{
    public class ListaNoticiasAppService : proyectoAppService, IListaNoticiasAppService
    {

        private readonly IRepository<ListaNoticia, int> _repository;
        private readonly IRepository<Noticia, int> _repositoryNoticias;
        
        private readonly INoticiasService _noticiasService;
        public ListaNoticiasAppService(IRepository<ListaNoticia, int> repository, INoticiasService newsService, IRepository<Noticia, int> repositoryNoticias )
        {
            _repository = repository;
            _repositoryNoticias = repositoryNoticias;
            _noticiasService = newsService;
        }
        public async Task<ListaNoticiaDto> CreateListaNoticiaAsync(string query, int parentId, NoticiaDto noticiaDto)
        {

            var listaNoticias = new ListaNoticia
            {
                nombreLista = query,
                ParentId = parentId
            };
            
            var lista = await _noticiasService.GetNewsAsync(query);

            foreach (var noticiaLista in lista)
            {
                
                var noticia = new Noticia
                {
                    descripcion = noticiaLista.Descripcion,
                   // fecha = noticiaLista.FechaPublicado,
                    titulo = noticiaLista.Titulo,
                    autor = noticiaLista.Autor,
                    url = noticiaLista.Url,
                    urlImagen = noticiaLista.UrlDeImagen,
                    Contenido = noticiaLista.Contenido,
                    ListaNoticiasId = listaNoticias.Id
                };
                
                await _repositoryNoticias.InsertAsync(noticia);
                
            }

            return ObjectMapper.Map<ListaNoticia, ListaNoticiaDto>(listaNoticias);
        }
    }
}
