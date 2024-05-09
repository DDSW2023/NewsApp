using AutoMapper;
using proyecto.Alertas1;
using proyecto.ListaNoticiaItemsDto;
using proyecto.noticias;
using proyecto.Noticias;
using proyecto.TemaNoticiasDto;
using proyecto.Accesos;
using proyecto.AccesosDto;
using proyecto.Busquedas;
using proyecto.BusquedasDto;
using proyecto.Errores;
using proyecto.ErroresDto;
using proyecto.Notificaciones;
using proyecto.NotificacionesDto;
using proyecto.Usuarios;
using proyecto.UsuariosDto;
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

        //dtos Acceso
        CreateMap<Acceso, CrearAccesoDto>();
        CreateMap<Acceso, AccesoDto>();

        //dtos Busqueda
        CreateMap<Busqueda, CrearBusquedaDto>();
        CreateMap<Busqueda, BusquedaDto>();

        //dtos Error
        CreateMap<Error, CrearErrorDto>();
        CreateMap<Error, ErrorDto>();

        //dtos Notificacion
        CreateMap<Notificacion, CrearNotificacionDto>();
        CreateMap<Notificacion, NotificacionDto>();

        //dtos Usuario
        CreateMap<Usuario, CrearUsuarioDto>();
        CreateMap<Usuario, UsuarioDto>();

        //dtos Busqueda
        // CreateMap<Busqueda, BusquedaDto>();

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
