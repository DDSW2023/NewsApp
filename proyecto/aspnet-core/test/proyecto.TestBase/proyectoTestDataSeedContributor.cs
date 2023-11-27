using proyecto.ListaNoticias;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace proyecto;
public class proyectoTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<ListaNoticia, int> _ListaNoticiasRepository;
    private readonly IdentityUserManager _identityUserManager;
    public proyectoTestDataSeedContributor(IRepository<ListaNoticia, int> listaNoticiaRepository, IdentityUserManager identityUserManager)
    {
        _ListaNoticiasRepository = listaNoticiaRepository;
        _identityUserManager = identityUserManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        // Add users        
        IdentityUser identityUser1 = new IdentityUser(Guid.Parse("2e701e62-0953-4dd3-910b-dc6cc93ccb0d"), "admin", "admin@abp.io");
        await _identityUserManager.CreateAsync(identityUser1, "1q2w3E*");
        // await _identityUserManager.AddToRoleAsync(identityUser1, "Admin");

        await _ListaNoticiasRepository.InsertAsync(new ListaNoticia { nombreLista = "Primer lista noticia", User = identityUser1 });
    }
}