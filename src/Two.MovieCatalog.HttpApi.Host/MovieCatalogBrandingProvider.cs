﻿using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Two.MovieCatalog;

[Dependency(ReplaceServices = true)]
public class MovieCatalogBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MovieCatalog";
}
