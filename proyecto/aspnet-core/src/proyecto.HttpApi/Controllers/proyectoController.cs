using proyecto.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace proyecto.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class proyectoController : AbpControllerBase
{
    protected proyectoController()
    {
        LocalizationResource = typeof(proyectoResource);
    }
}
