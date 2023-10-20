using Volo.Abp.Application.Dtos;

namespace proyecto.ListaNoticiaItemsDto;

public class ListaNoticiaItemDto : EntityDto<int>
{
    public int ListaNoticiaId { get; set; }
    public int NoticiaId { get; set; }
}