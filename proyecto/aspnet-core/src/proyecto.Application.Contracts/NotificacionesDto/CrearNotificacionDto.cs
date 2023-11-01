using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace proyecto.NotificacionesDto;

public class CrearNotificacionDto : EntityDto<int>
{
    [Required]
    public DateTime fecha { get; set; }

    [Required]
    public string descripcion { get; set; }

    [Required]
    public string link { get; set; }
}
