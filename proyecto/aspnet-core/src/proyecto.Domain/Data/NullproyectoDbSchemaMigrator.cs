using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace proyecto.Data;

/* This is used if database provider does't define
 * IproyectoDbSchemaMigrator implementation.
 */
public class NullproyectoDbSchemaMigrator : IproyectoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
