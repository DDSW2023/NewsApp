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
    public async Task<UsuarioDto> UpdateUsuarioAsync(int id, CrearUsuarioDto input)
    {
        var usuario = await _repository.GetAsync(id);
        usuario.nombre = input.nombre;
        usuario.apellido = input.apellido;
        usuario.mail = input.mail;
        await _repository.UpdateAsync(usuario);
        return ObjectMapper.Map<Usuario, UsuarioDto>(usuario);
    }

    public async Task<ICollection<UsuarioDto>> GetUsuarioAsync()
    {
        var queryUsuarios = await _repository.WithDetailsAsync(x => x.Accesos);
        /* REVISAR Y CORREGIR
        var queryUsuarios = await _repository.WithDetailsAsync(x => x.Busquedas);
        var queryUsuarios = await _repository.WithDetailsAsync(x => x.Notificaciones);
        */
        var usuarios = await AsyncExecuter.ToListAsync(queryUsuarios);
        return ObjectMapper.Map<ICollection<Usuario>, ICollection<UsuarioDto>>(usuarios);
    }

    public async Task<UsuarioDto> GetUsuarioAsync(int id)
    {
        var queryUsuarios = await _repository.WithDetailsAsync(x => x.Accesos);
        /* REVISAR Y CORREGIR
        var queryUsuarios = await _repository.WithDetailsAsync(x => x.Busquedas);
        var queryUsuarios = await _repository.WithDetailsAsync(x => x.Notificaciones);
        */
        var filtroUsuario = queryUsuarios.Where(x => x.Id == id);
        var usuario = await AsyncExecuter.FirstOrDefaultAsync(filtroUsuario);
        return ObjectMapper.Map<Usuario, UsuarioDto>(usuario);
    }

    public async Task<UsuarioDto> DeleteUsuarioAsync(int id)
    {
        var queryUsuarios = await _repository.WithDetailsAsync(x => x.Accesos);
        /* REVISAR Y CORREGIR
        var queryUsuarios = await _repository.WithDetailsAsync(x => x.Busquedas);
        var queryUsuarios = await _repository.WithDetailsAsync(x => x.Notificaciones);
        */
        var filtroUsuarios = queryUsuarios.Where(x => x.Id == id);
        var usuario = await AsyncExecuter.FirstOrDefaultAsync(filtroUsuarios);
        await _repository.DeleteAsync(id);
        return ObjectMapper.Map<Usuario, UsuarioDto>(usuario);
    }
}