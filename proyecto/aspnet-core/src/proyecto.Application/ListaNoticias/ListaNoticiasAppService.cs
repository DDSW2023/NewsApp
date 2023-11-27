using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ListaNoticiaManager _listaNoticiaManager;

        public ListaNoticiasAppService(IRepository<ListaNoticia, int> repository, UserManager<IdentityUser> user, ListaNoticiaManager manager)
        {
            _repository = repository;
            _userManager = user;
            _listaNoticiaManager = manager;
        }

        
        public async Task<ICollection<ListaNoticiaDto>> GetThemesAsync()
        {
            var listas = await _repository.GetListAsync(includeDetails:true);

            return ObjectMapper.Map<ICollection<ListaNoticia>, ICollection<ListaNoticiaDto>>(listas);
        }

        public async Task<ListaNoticiaDto> GetThemesAsync(int id)
        {            
            var queryable = await _repository.WithDetailsAsync(x => x.Listas);

            var query = queryable.Where(x => x.Id == id);

            var listas = await AsyncExecuter.FirstOrDefaultAsync(query);

            return ObjectMapper.Map<ListaNoticia, ListaNoticiaDto>(listas);
            
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

        public async Task<ListaNoticiaDto> DeleteListaNoticiaAsync(CrearListaNoticiaDto input)
        {
            throw new NotImplementedException();
        }
    }
}
