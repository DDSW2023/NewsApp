using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using proyecto.Noticias;
using Volo.Abp.Application.Services;

namespace proyecto.ListaNoticiasDto
{
    public interface IListaNoticiasAppService : IApplicationService
    {
        //Task<ICollection<ListaNoticiaDto>> GetListaNoticiaAsync(int id);
        public Task<ListaNoticiaDto> CreateListaNoticiaAsync(string query, int parentId, NoticiaDto noticiaDto);
        //Task<ListaNoticiaDto> CreateListaNoticiaAsync(CrearListaNoticiaDto input);
        //Task<ListaNoticiaDto> UpdateListaNoticiaAsync(int id, CrearListaNoticiaDto input);
        //Task<ListaNoticiaDto> DeleteListaNoticiaAsync(int id);
    }
}
