using System.Collections.Generic;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace NewsApp.News
{
    public interface INewsService
    {
        Task<ICollection<ArticuloDto>> GetNewsAsync(string query);
    }
=======
namespace proyecto.noticias;

public interface INoticiasService
{
    Task<ICollection<ArticuloDto>> GetNewsAsync(string query);

>>>>>>> 0a4434e97851e0decfdb5a6dcd0d967255475149
}