using System;
using System.Collections.Generic;
using System.Text;
//using proyecto.NotificacionesDto;
using Volo.Abp.Application.Dtos;

namespace proyecto.AlertasDto
{
    public class AlertaDto:EntityDto<int>
    {
        public DateTime fecha { get; set; }
        public String descripcion { get; set; }
        //public ICollection<NotificacionDto> Notificaciones { get; set; }
        public int ListaNoticiaId { get; set; }
    }
}
