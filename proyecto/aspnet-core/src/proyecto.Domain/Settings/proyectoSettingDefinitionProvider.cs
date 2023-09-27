using Volo.Abp.Settings;

namespace proyecto.Settings;

public class proyectoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(proyectoSettings.MySetting1));
    }
}
