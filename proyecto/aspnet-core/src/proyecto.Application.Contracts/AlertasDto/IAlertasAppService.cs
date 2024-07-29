using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace proyecto.AlertasDto
{
    public interface IAlertasAppService : IApplicationService
    {
        public Task<AlertaDto> CreateAlertaAsync(CrearAlertaDto input, string textoBusqueda, int userId);
        public Task<AlertaDto> DeleteAlertaAsync(int id);
        public Task<AlertaDto> GetAlertaAsync();
        public Task<ICollection<AlertaDto>> GetAlertaAsync(int id);
        public Task<AlertaDto> UpdateAlertaAsync(int id, CrearAlertaDto input);
    }
}
