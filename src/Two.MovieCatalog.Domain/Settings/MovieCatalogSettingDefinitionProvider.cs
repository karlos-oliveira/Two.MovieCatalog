using Volo.Abp.Settings;

namespace Two.MovieCatalog.Settings;

public class MovieCatalogSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MovieCatalogSettings.MySetting1));
    }
}
