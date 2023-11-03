using proyecto.AlertasDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Alertas
{
    public class AlertasAppService : proyectoAppService, IAlertasAppService
    {
        public Task<AlertaDto> CreateAlertaAsync(CrearAlertaDto input)
        {
            throw new NotImplementedException();
        }

        public Task<AlertaDto> DeleteAlertaAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AlertaDto>> GetAlertaAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AlertaDto> UpdateAlertaAsync(int id, CrearAlertaDto input)
        {
            throw new NotImplementedException();
        }

        Task<AlertaDto> IAlertasAppService.GetAlertaAsync()
        {
            throw new NotImplementedException();
        }
    }
}
