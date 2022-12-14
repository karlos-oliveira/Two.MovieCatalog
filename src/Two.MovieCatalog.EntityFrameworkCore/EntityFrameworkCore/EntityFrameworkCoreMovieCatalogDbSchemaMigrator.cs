using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Two.MovieCatalog.Data;
using Volo.Abp.DependencyInjection;

namespace Two.MovieCatalog.EntityFrameworkCore;

public class EntityFrameworkCoreMovieCatalogDbSchemaMigrator
    : IMovieCatalogDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMovieCatalogDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the MovieCatalogDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MovieCatalogDbContext>()
            .Database
            .MigrateAsync();
    }
}
