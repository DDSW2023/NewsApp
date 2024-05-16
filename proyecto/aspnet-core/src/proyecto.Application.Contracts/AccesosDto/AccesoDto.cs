using System;
using System.Collections.Generic;
using proyecto.ErroresDto;
using Volo.Abp.Application.Dtos;

namespace proyecto.AccesosDto;
public class AccesoDto : EntityDto<int>
{
    public DateTime fecha { get; set; }
    public float tiempoAcceso { get; set; }
    public int UsuarioId { get; set; }
}


public class MonitoreoResponseDto : EntityDto<int>
{
    public float tiempoPromedio { get; set; }
    public int cantidadAccesos { get; set; }
    public List<AccesoDto> Accesos { get; set; }
}