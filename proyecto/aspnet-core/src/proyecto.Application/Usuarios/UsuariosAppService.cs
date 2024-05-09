using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using proyecto.UsuariosDto;

namespace proyecto.Usuarios;

public class UsuariosAppService : proyectoAppService, IUsuariosAppService
{

    private readonly IRepository<Usuario, int> _repository;

    public UsuariosAppService(IRepository<Usuario, int> repository)
    {
        _repository = repository;
    }

    public async Task<UsuarioDto> CreateUsuarioAsync(CrearUsuarioDto input)
    {
        var usuario = new Usuario
        {
            nombre = input.nombre,
            apellido = input.apellido,
            mail = input.mail,
        };
        await _repository.InsertAsync(usuario);
        return ObjectMapper.Map<Usuario, UsuarioDto>(usuario);
    }

    public async Task<UsuarioDto> GetUserIdByName(string user)
    {
        var users = await _repository.GetListAsync();

        var encontrado = false;

        var usuario = new UsuarioDto();
        
        foreach (var u in users)
        {
            if (u.nombre == user)
            {
                var usuarioEncontrado = new UsuarioDto
                {
                    Id = u.Id,
                    mail = u.mail,
                    nombre = u.nombre
                };

                return usuarioEncontrado;

            }
        }

        return usuario;
    }

    public async Task<UsuarioDto> UpdateUsuarioAsync(int id, CrearUsuarioDto input)
    {
        var usuario = await _repository.GetAsync(id);
        usuario.nombre = input.nombre;
        usuario.apellido = input.apellido;
        usuario.mail = input.mail;
        await _repository.UpdateAsync(usuario);
        return ObjectMapper.Map<Usuario, UsuarioDto>(usuario);
    }

    //get para cada una de las listas (son 3)
    public async Task<ICollection<UsuarioDto>> GetUsuarioAccesosAsync()
    {
        var queryUsuarios = await _repository.WithDetailsAsync(x => x.Accesos);
        var usuarios = await AsyncExecuter.ToListAsync(queryUsuarios);
        return ObjectMapper.Map<ICollection<Usuario>, ICollection<UsuarioDto>>(usuarios);
    }

    public async Task<ICollection<UsuarioDto>> GetUsuarioBusquedasAsync()
    {
        var queryUsuarios = await _repository.WithDetailsAsync(x => x.Busquedas);
        var usuarios = await AsyncExecuter.ToListAsync(queryUsuarios);
        return ObjectMapper.Map<ICollection<Usuario>, ICollection<UsuarioDto>>(usuarios);
    }

    public async Task<ICollection<UsuarioDto>> GetUsuarioNotificacionesAsync()
    {
        var queryUsuarios = await _repository.WithDetailsAsync(x => x.Notificaciones);
        var usuarios = await AsyncExecuter.ToListAsync(queryUsuarios);
        return ObjectMapper.Map<ICollection<Usuario>, ICollection<UsuarioDto>>(usuarios);
    }

    //get para que devuelva sólo un id (son 3)
    public async Task<UsuarioDto> GetUsuarioAccesoAsync(int id)
    {
        var queryUsuarios = await _repository.WithDetailsAsync(x => x.Accesos);
        var filtroUsuario = queryUsuarios.Where(x => x.Id == id);
        var usuario = await AsyncExecuter.FirstOrDefaultAsync(filtroUsuario);
        return ObjectMapper.Map<Usuario, UsuarioDto>(usuario);
    }

    public async Task<UsuarioDto> GetUsuarioBusquedaAsync(int id)
    {
        var queryUsuarios = await _repository.WithDetailsAsync(x => x.Busquedas);
        var filtroUsuario = queryUsuarios.Where(x => x.Id == id);
        var usuario = await AsyncExecuter.FirstOrDefaultAsync(filtroUsuario);
        return ObjectMapper.Map<Usuario, UsuarioDto>(usuario);
    }
    public async Task<UsuarioDto> GetUsuarioNotificacionAsync(int id)
    {
        var queryUsuarios = await _repository.WithDetailsAsync(x => x.Notificaciones);
        var filtroUsuario = queryUsuarios.Where(x => x.Id == id);
        var usuario = await AsyncExecuter.FirstOrDefaultAsync(filtroUsuario);
        return ObjectMapper.Map<Usuario, UsuarioDto>(usuario);
    }

    public async Task<UsuarioDto> DeleteUsuarioAsync(int id)
    {
        var queryUsuarios = await _repository.WithDetailsAsync(x=> x.Accesos, y => y.Busquedas, z => z.Notificaciones);
        var filtroUsuarios = queryUsuarios.Where(x => x.Id == id);
        var usuario = await AsyncExecuter.FirstOrDefaultAsync(filtroUsuarios);
        await _repository.DeleteAsync(id);
        return ObjectMapper.Map<Usuario, UsuarioDto>(usuario);
    }
}