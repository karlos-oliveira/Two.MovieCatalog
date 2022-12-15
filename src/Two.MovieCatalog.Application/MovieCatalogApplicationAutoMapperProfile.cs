using AutoMapper;
using Two.MovieCatalog.Movies;

namespace Two.MovieCatalog;

public class MovieCatalogApplicationAutoMapperProfile : Profile
{
    public MovieCatalogApplicationAutoMapperProfile()
    {
        CreateMap<Movie, MovieDto>();
        CreateMap<CreateUpdateMovieDto, Movie>();
    }
}
