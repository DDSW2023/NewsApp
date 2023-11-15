using AutoMapper;
using proyecto.Alertas;
using proyecto.ListaNoticiaItems;
using proyecto.ListaNoticiaItemsDto;
using proyecto.noticias;
using proyecto.Noticias;
using proyecto.TemaNoticias;
using proyecto.TemaNoticiasDto;
using proyecto.AlertasDto;
using proyecto.ListaNoticiasDto;
using proyecto.Temas;
using proyecto.ListaNoticias;

namespace proyecto;

public class proyectoApplicationAutoMapperProfile : Profile
{
    public proyectoApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Noticia, NoticiaDto>();
        CreateMap<TemaNoticia, TemaNoticiaDto>();
        CreateMap<ListaNoticiaItem, ListaNoticiaItemDto>();
        
        // dtos temas
        CreateMap<Tema, CrearTemaDto>();
        CreateMap<Tema, TemaDto>();

        // dtos tema noticia
        CreateMap<TemaNoticia, TemaNoticiaDto>();

        //dtos alerta
        CreateMap<Alerta, CrearAlertaDto>();
        CreateMap<Alerta, AlertaDto>();

        //dtos ListaNoticia
        CreateMap<ListaNoticia, ListaNoticiaDto>();
        CreateMap<ListaNoticia, CrearListaNoticiaDto>();
    }
}
