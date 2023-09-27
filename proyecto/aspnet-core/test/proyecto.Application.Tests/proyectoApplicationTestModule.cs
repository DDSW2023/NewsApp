using Volo.Abp.Modularity;

namespace proyecto;

[DependsOn(
    typeof(proyectoApplicationModule),
    typeof(proyectoDomainTestModule)
    )]
public class proyectoApplicationTestModule : AbpModule
{

}
