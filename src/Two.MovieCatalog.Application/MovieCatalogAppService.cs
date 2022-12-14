using System;
using System.Collections.Generic;
using System.Text;
using Two.MovieCatalog.Localization;
using Volo.Abp.Application.Services;

namespace Two.MovieCatalog;

/* Inherit your application services from this class.
 */
public abstract class MovieCatalogAppService : ApplicationService
{
    protected MovieCatalogAppService()
    {
        LocalizationResource = typeof(MovieCatalogResource);
    }
}
