using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace proyecto.Noticias
{
    public class NoticiasAppService : proyectoAppService, INoticiasAppService
    {
        private readonly INoticiasService _noticiasService;

        public NoticiasAppService(INoticiasService noticiasService)
        {
            _noticiasService = noticiasService;
        }

        public Task<ICollection<NoticiaDto>> Search(string query)
        {
            throw new NotImplementedException();
        }
    }
}
