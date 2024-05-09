using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using proyecto.Alertas1;
using proyecto.AlertasDto;
using proyecto.ListaNoticiasDto;
using proyecto.noticias;
using proyecto.Noticias;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace proyecto.ListaNoticias
{

    public class ListaNoticiasAppService : proyectoAppService, IListaNoticiasAppService
    {

        
        private readonly IRepository<ListaNoticia, int> _repository;
        private readonly IRepository<Noticia, int> _repositoryNoticias;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ListaNoticiaManager _listaNoticiaManager;
        private readonly INoticiasService _noticiasService;
        private readonly INoticiasAppService _noticiasAppService;

        public ListaNoticiasAppService(INoticiasAppService noticia, IRepository<ListaNoticia, int> repository, INoticiasService noticiasService, UserManager<IdentityUser> user, ListaNoticiaManager manager, IRepository<Noticia, int> noticias )
        {
            _repository = repository;
            _userManager = user;
            _listaNoticiaManager = manager;
            _repositoryNoticias = noticias;
            _noticiasService = noticiasService;
            _noticiasAppService = noticia;
        }

        
        public async Task<ICollection<ListaNoticiaDto>> GetListasAsync()
        {
            var listas = await _repository.GetListAsync(includeDetails:true);

            return ObjectMapper.Map<ICollection<ListaNoticia>, ICollection<ListaNoticiaDto>>(listas);
        }

        public async Task<ListaNoticiaDto> GetListasAsync(int id)
        {            
            var queryable = await _repository.WithDetailsAsync(x => x.Listas);

            var Noticiasq = await _repositoryNoticias.GetQueryableAsync();

            var noticias = new Collection<NoticiaDto>();
            
                
                foreach(var i in Noticiasq){

                    if (i.ListaNoticiasId == id)
                    {
                        var dto = ObjectMapper.Map<Noticia, NoticiaDto>(i);
                        noticias.Add(dto);
                    }
                };
            
            var query = queryable.Where(x => x.Id == id);

            var listas = await AsyncExecuter.FirstOrDefaultAsync(query);

            var response = new ListaNoticiaDto();

            response.nombreLista = listas.nombreLista;
            response.Id = listas.Id;
            response.Alertas = ObjectMapper.Map<ICollection<Alerta>, ICollection<AlertaDto>>(listas.Alertas);
            response.ListaNoticias = ObjectMapper.Map<ICollection<ListaNoticia>, ICollection<ListaNoticiaDto>>(listas.Listas);
            response.ListaNoticiasItems = ObjectMapper.Map<ICollection<Noticia>, ICollection<NoticiaDto>>(listas.ListaNoticias);


            return response;
            
        }    

        public async Task<ListaNoticiaDto> CreateListaNoticiaAsync(CrearListaNoticiaDto input)
        {

            var userGuid = CurrentUser.Id.GetValueOrDefault();

            var identityUser = await _userManager.FindByIdAsync(userGuid.ToString());

            var lista = await _listaNoticiaManager.CreateAsyncOrUpdate(input.Id, input.nombreLista, input.ParentId, identityUser);

            if (input.Id is null)
            {
                lista = await _repository.InsertAsync(lista, autoSave: true);
            }
            else
            {
                await _repository.UpdateAsync(lista, autoSave: true);
            }            
            
            return ObjectMapper.Map<ListaNoticia, ListaNoticiaDto>(lista);
 
        }

        public async Task<ListaNoticiaDto> DeleteListaNoticiaAsync(int id)
        {
            var lista = await _repository.GetAsync(id);
     
            await _repository.DeleteAsync(id);
        
            return ObjectMapper.Map<ListaNoticia, ListaNoticiaDto>(lista);
        }

        public async Task<NoticiaDto> AgregarNoticiasAsync(int id, string query, string busqueda)
        {
            var lista = await _noticiasService.GetNewsAsync(query);
            
            NoticiaDto noticiaEncontrada = null;

            bool finded = false;
 
            
            foreach (var noticiaLista in lista)
            {

                if (noticiaLista.Titulo.Contains(busqueda))
                {

                    if (noticiaLista is not null &&
                        noticiaLista.Url is not null &&
                        noticiaLista.Descripcion is not null &&
                        noticiaLista.Titulo is not null &&
                        noticiaLista.Autor is not null)
                    {
                        
                        var crearNoticia = new CrearNoticiasDto
                        {
                            descripcion = noticiaLista.Descripcion,
                            fecha = noticiaLista.FechaPublicado,
                            titulo = noticiaLista.Titulo,
                            autor = noticiaLista.Autor,
                            url = noticiaLista.Url,
                            urlImagen = "asd",
                            Contenido = "asd",
                            tema = query,
                            ListaNoticiasId = id
                        };

                        await _noticiasAppService.CreateNoticia(crearNoticia);
                        
                        noticiaEncontrada = new NoticiaDto
                        {
                            Descripcion = noticiaLista.Descripcion,
                            FechaPublicado = noticiaLista.FechaPublicado,
                            Titulo = noticiaLista.Titulo,
                            Autor = noticiaLista.Autor,
                            Mensaje = "Noticia Encontrada!",
                            Contenido = "",
                            Id = 0,
                            tema = "",
                            Url = "",
                            UrlDeImagen = ""
                        };

                        finded = true;

                    }
                }
            }
            
            if (finded == false)
            {
                // No se encontró ninguna noticia que coincida con la búsqueda
                return new NoticiaDto { Mensaje = "No se encontró ninguna noticia con el título especificado." };
            }
            else
            {
            return noticiaEncontrada;
                
            }

        }
        
    }
}
