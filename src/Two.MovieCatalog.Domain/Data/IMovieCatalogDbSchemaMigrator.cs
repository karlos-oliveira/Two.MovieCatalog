using System.Threading.Tasks;

namespace Two.MovieCatalog.Data;

public interface IMovieCatalogDbSchemaMigrator
{
    Task MigrateAsync();
}
