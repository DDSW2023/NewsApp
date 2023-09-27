using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace proyecto;

[Dependency(ReplaceServices = true)]
public class proyectoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "proyecto";
}
