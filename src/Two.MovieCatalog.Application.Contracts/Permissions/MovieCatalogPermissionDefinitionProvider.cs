using Two.MovieCatalog.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Two.MovieCatalog.Permissions;

public class MovieCatalogPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var movieCatalogGroup = context.AddGroup(MovieCatalogPermissions.GroupName, L("Permission:MovieCatalog"));
        var moviesPermission = movieCatalogGroup.AddPermission(MovieCatalogPermissions.Movies.Default, L("Permission:Movies"));
        moviesPermission.AddChild(MovieCatalogPermissions.Movies.Create, L("Permission:Movies.Create"));
        moviesPermission.AddChild(MovieCatalogPermissions.Movies.Edit, L("Permission:Movies.Edit"));
        moviesPermission.AddChild(MovieCatalogPermissions.Movies.Delete, L("Permission:Movies.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MovieCatalogResource>(name);
    }
}
