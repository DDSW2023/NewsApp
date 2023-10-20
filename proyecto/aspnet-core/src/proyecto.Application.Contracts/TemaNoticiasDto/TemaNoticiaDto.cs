using Volo.Abp.Application.Dtos;

namespace proyecto.TemaNoticiasDto;

public class TemaNoticiaDto : EntityDto<int>
{
    public int NoticiaId { get; set; }
    public int TemaId { get; set; }
}