using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace proyecto.AccesosDto;

public class CrearAccesoDto : EntityDto<int>
{

    [Required]
    public DateTime fecha { get; set; }

    [Required]
    public TimeSpan horaInicio { get; set; }

    [Required]
    public TimeSpan horaFin { get; set; }

    /*
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    */
}
