using Volo.Abp.Application.Dtos;

namespace proyecto.BusquedasDto;
public class BusquedaDto : EntityDto<int>
{
    public string parametro { get; set; }
    public int UsuarioId { get; set; }
}
