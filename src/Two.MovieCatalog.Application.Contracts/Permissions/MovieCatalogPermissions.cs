namespace Two.MovieCatalog.Permissions;

public static class MovieCatalogPermissions
{
    public const string GroupName = "MovieCatalog";
    public static class Movies
    {
        public const string Default = GroupName + ".Movies";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
