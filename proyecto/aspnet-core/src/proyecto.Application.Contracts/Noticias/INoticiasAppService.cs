using proyecto.noticias;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Noticias;

public interface INoticiasAppService
{
    Task<ICollection<ArticuloDto>> Search(string query, int userId);

    public Task<NoticiaDto> CreateNoticia(CrearNoticiasDto noticia);

    public Task<NoticiaDto> GetNoticia(int noticiaId);

    public Task< IQueryable<NoticiaDto>> GetNoticias();

}