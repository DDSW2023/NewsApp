using System.Collections.Generic;
using proyecto.TemaNoticiasDto;
using Volo.Abp.Application.Dtos;

namespace proyecto.Temas;

public class TemaDto : EntityDto<int>
{
    public string nombre { get; set; }
    public string descripcion { get; set; }
    public IList<TemaNoticiaDto> TemaNoticias { get; set; }
}