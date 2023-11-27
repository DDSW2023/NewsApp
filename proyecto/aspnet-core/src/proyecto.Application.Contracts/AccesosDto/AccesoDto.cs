using System;
using System.Collections.Generic;
using proyecto.ErroresDto;
using Volo.Abp.Application.Dtos;

namespace proyecto.AccesosDto;
public class AccesoDto : EntityDto<int>
{
    public DateTime fecha { get; set; }
    public TimeSpan horaInicio { get; set; }
    public TimeSpan horaFin { get; set; }
    public IList<ErrorDto> Errores { get; set; }
    public int UsuarioId { get; set; }
}