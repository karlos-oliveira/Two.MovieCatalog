using Two.MovieCatalog.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Two.MovieCatalog.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MovieCatalogEntityFrameworkCoreModule),
    typeof(MovieCatalogApplicationContractsModule)
    )]
public class MovieCatalogDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
