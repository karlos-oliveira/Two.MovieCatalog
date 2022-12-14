using Volo.Abp.Modularity;

namespace Two.MovieCatalog;

[DependsOn(
    typeof(MovieCatalogApplicationModule),
    typeof(MovieCatalogDomainTestModule)
    )]
public class MovieCatalogApplicationTestModule : AbpModule
{

}
