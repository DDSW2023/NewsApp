using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.ListaNoticiasDto
{
    public interface IListaNoticiasAppService : IApplicationService
    {
        //Task<ICollection<ListaNoticiaDto>> GetListaNoticiaAsync(int id);
        Task<ListaNoticiaDto> CreateListaNoticiaAsync(string query);
        //Task<ListaNoticiaDto> CreateListaNoticiaAsync(CrearListaNoticiaDto input);
        //Task<ListaNoticiaDto> UpdateListaNoticiaAsync(int id, CrearListaNoticiaDto input);
        //Task<ListaNoticiaDto> DeleteListaNoticiaAsync(int id);
    }
}
