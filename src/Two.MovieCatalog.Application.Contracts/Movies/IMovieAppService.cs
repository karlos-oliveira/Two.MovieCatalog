using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Two.MovieCatalog.Movies
{
    public interface IMovieAppService :
        ICrudAppService<MovieDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateMovieDto> 
    {

    }
}
