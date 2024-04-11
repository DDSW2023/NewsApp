using proyecto.AlertasDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyecto.Alertas
{
    public interface IAlertasAppService
    {
        Task<AlertaDto> CreateAlertaAsync(CrearAlertaDto input, string textoBusqueda);
        Task<AlertaDto> DeleteAlertaAsync(int id);
        Task<AlertaDto> GetAlertaAsync();
        Task<ICollection<AlertaDto>> GetAlertaAsync(int id);
        Task<AlertaDto> UpdateAlertaAsync(int id, CrearAlertaDto input);
    }
}