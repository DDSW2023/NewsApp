using System;
using System.Collections.Generic;
using System.Text;
using proyecto.Localization;
using Volo.Abp.Application.Services;

namespace proyecto;

/* Inherit your application services from this class.
 */
public abstract class proyectoAppService : ApplicationService
{
    protected proyectoAppService()
    {
        LocalizationResource = typeof(proyectoResource);
    }
}
