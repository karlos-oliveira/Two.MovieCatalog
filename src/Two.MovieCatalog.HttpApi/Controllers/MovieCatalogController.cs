using Two.MovieCatalog.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Two.MovieCatalog.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MovieCatalogController : AbpControllerBase
{
    protected MovieCatalogController()
    {
        LocalizationResource = typeof(MovieCatalogResource);
    }
}
