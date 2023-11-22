using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyecto.Noticias;

public interface INoticiasAppService
{
    Task<ICollection<ArticuloDto>> Search(string query);
}