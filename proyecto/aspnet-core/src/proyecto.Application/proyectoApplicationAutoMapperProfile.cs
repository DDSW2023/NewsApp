using AutoMapper;
using proyecto.Alertas;
using proyecto.ListaNoticiaItemsDto;
using proyecto.noticias;
using proyecto.Noticias;
using proyecto.TemaNoticiasDto;
using proyecto.AlertasDto;
using proyecto.ListaNoticiasDto;
using proyecto.ListaNoticias;
using proyecto.Notificaciones;

namespace proyecto;

public class proyectoApplicationAutoMapperProfile : Profile
{
    public proyectoApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Noticia, NoticiaDto>();
        
        CreateMap<Noticia, ArticuloDto>();


        //dtos alerta
        CreateMap<Alerta, CrearAlertaDto>();
        CreateMap<Alerta, AlertaDto>();
        
        CreateMap<CrearNoticiasDto, Noticia>();
        
        //dtos ListaNoticia
        CreateMap<ListaNoticia, ListaNoticiaDto>();
        CreateMap<ListaNoticia, CrearListaNoticiaDto>();
        
        CreateMap<Notificacion, NotificacionesResponseDto>();
        CreateMap<Notificacion, NotificacionesRequestDto>();
    }
}
