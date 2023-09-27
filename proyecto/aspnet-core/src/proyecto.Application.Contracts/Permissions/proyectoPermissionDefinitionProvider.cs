using proyecto.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace proyecto.Permissions;

public class proyectoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(proyectoPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(proyectoPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<proyectoResource>(name);
    }
}
