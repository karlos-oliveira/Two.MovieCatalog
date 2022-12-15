using Two.MovieCatalog.Permissions;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Two.MovieCatalog.Movies
{
    public class MovieAppService :
        CrudAppService<Movie,
            MovieDto,
            Guid, 
            PagedAndSortedResultRequestDto, 
            CreateUpdateMovieDto>, 
        IMovieAppService
    {
        public MovieAppService(IRepository<Movie, Guid> repository)
            : base(repository)
        {
            GetPolicyName = MovieCatalogPermissions.Movies.Default;
            GetListPolicyName = MovieCatalogPermissions.Movies.Default;
            CreatePolicyName = MovieCatalogPermissions.Movies.Create;
            UpdatePolicyName = MovieCatalogPermissions.Movies.Edit;
            DeletePolicyName = MovieCatalogPermissions.Movies.Delete;
        }
    }
}
