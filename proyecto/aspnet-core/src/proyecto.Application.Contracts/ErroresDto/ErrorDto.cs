using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace proyecto.ErroresDto;
public class ErrorDto : EntityDto<int>
{
    public string descripcion { get; set; }
    /*
    public int AccesoId { get; set; }
    public Acceso Acceso { get; set; }
    */
}
