using System.Collections.Generic;
using System.Threading.Tasks;


namespace proyecto.noticias;

public interface INoticiasService
{
    Task<ICollection<ArticuloDto>> GetNewsAsync(string query);


}