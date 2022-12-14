using Two.MovieCatalog.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Two.MovieCatalog.Permissions;

public class MovieCatalogPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MovieCatalogPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MovieCatalogPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MovieCatalogResource>(name);
    }
}
