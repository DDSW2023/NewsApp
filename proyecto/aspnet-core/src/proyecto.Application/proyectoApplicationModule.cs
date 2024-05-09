using Microsoft.Extensions.DependencyInjection;
using NewsApp.News;
using proyecto.Alertas;
using proyecto.AlertasDto;
using proyecto.noticias;
using proyecto.Notificacion1;
using proyecto.NotificacionesApp;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace proyecto;

[DependsOn(
    typeof(proyectoDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(proyectoApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class proyectoApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<proyectoApplicationModule>();
        });
        
        context.Services.AddTransient<INoticiasService, NoticiasApiService>();

    }
}
