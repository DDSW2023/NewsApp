using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.AlertasDto
{
    public interface IAlertasAppService : IApplicationService
    {
        Task<ICollection<AlertaDto>> GetAlertaAsync(int id);
        Task<AlertaDto> GetAlertaAsync();
        Task<AlertaDto> CreateAlertaAsync(CrearAlertaDto input);
        Task<AlertaDto> UpdateAlertaAsync(int id, CrearAlertaDto input);
        Task<AlertaDto> DeleteAlertaAsync(int id);

    }
}
