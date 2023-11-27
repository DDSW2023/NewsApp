using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace proyecto.ListaNoticias
{
    public class ListaNoticiaManager : DomainService
    {
        private readonly IRepository<ListaNoticia, int> _repository;
        
        public ListaNoticiaManager(IRepository<ListaNoticia, int> repository)
        {
            _repository = repository;
        }

        public async Task<ListaNoticia> CreateAsyncOrUpdate(int? id, string name, int? parentId, IdentityUser identityUser)
        {
            ListaNoticia lista = null;            

            if (id is not null)
            {
                // Si el id no es nulo significa que se modifica el tema
                lista = await _repository.GetAsync(id.Value, includeDetails: true);

                lista.nombreLista = name;
            }
            else
            {
                //Si el id es nulo, es un tema nuevo
                lista = new ListaNoticia() { nombreLista = name, User = identityUser };

                if (parentId is not null)
                {
                    // Si el parent id no es nulo, es un tema hijo de un tema padre.
                    var parentLista = await _repository.GetAsync(parentId.Value, includeDetails: true);
                    parentLista.Listas.Add(lista);
                }               
            };

            return lista;
        }
    }
}