using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Noticias
{
    public interface INoticiasAppService
    {
        Task<ICollection<NoticiaDto>> Search(string query);
    }
}
