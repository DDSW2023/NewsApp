using proyecto.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace proyecto.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(proyectoEntityFrameworkCoreModule),
    typeof(proyectoApplicationContractsModule)
    )]
public class proyectoDbMigratorModule : AbpModule
{
}
