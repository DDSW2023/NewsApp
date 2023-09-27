using proyecto.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace proyecto;

[DependsOn(
    typeof(proyectoEntityFrameworkCoreTestModule)
    )]
public class proyectoDomainTestModule : AbpModule
{

}
