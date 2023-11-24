using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto;
using proyecto.noticias;
using static OpenIddict.Abstractions.OpenIddictConstants;
using Statuses = NewsAPI.Constants.Statuses;

namespace NewsApp.News
{
    public class NoticiasApiService : INoticiasService
    {
        public async Task<ICollection<ArticuloDto>> GetNewsAsync(string query)
        {
            ICollection<ArticuloDto> responseList = new List<ArticuloDto>();

            // init with your API key
            var newsApiClient = new NewsApiClient("32c81b11a55b44fd9b5b4e6e1ca5cdca");
            var articlesResponse = await newsApiClient.GetEverythingAsync(new EverythingRequest
            {
                Q = query,
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                // consultamos de un mes para atras ya que es lo que permite la api gratis
                From = DateTime.Now.AddMonths(-1)
            }) ;

            // se deberia lanzar una excepcion si la consulta a la api da error.
            if (articlesResponse.Status == Statuses.Ok)
            {
                articlesResponse.Articles.ForEach( t=> responseList.Add(new ArticuloDto {  Autor = t.Author, 
                    Titulo = t.Title,
                    Descripcion = t.Description,
                    Url = t.Url,
                    FechaPublicado = t.PublishedAt
                }));                                
            }

            // TODO: falta registrar los tiempos de acceso de la API
            return responseList;
        }
    }
}