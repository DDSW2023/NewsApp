using proyecto.noticias;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyecto.Noticias;

public interface INoticiasAppService
{
    Task<ICollection<ArticuloDto>> Search(string query);

    public Task<NoticiaDto> CreateNoticia(CrearNoticiasDto noticia);

    public Task<NoticiaDto> GetNoticia(int noticiaId);

}