using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using proyecto.Data;
using Volo.Abp.DependencyInjection;

namespace proyecto.EntityFrameworkCore;

public class EntityFrameworkCoreproyectoDbSchemaMigrator
    : IproyectoDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreproyectoDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the proyectoDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<proyectoDbContext>()
            .Database
            .MigrateAsync();
    }
}
