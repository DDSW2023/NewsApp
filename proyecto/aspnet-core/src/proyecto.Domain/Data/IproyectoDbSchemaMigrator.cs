using System.Threading.Tasks;

namespace proyecto.Data;

public interface IproyectoDbSchemaMigrator
{
    Task MigrateAsync();
}
