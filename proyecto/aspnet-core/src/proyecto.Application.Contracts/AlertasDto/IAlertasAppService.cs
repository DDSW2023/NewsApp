using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.AlertasDto
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
