using Two.MovieCatalog.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Two.MovieCatalog;

[DependsOn(
    typeof(MovieCatalogEntityFrameworkCoreTestModule)
    )]
public class MovieCatalogDomainTestModule : AbpModule
{

}
