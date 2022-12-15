using Two.MovieCatalog.Movies;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Two.MovieCatalog
{
    public class MovieCatalogDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Movie, Guid> _movieRepository;

        public MovieCatalogDataSeederContributor(IRepository<Movie, Guid> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _movieRepository.GetCountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    await _movieRepository.InsertAsync(GenerateMovie(), autoSave: true);
                }
            }
        }

        private static Movie GenerateMovie()
        {
            Random random= new();

            return new Movie()
            {
                Name = "Movie_" + Guid.NewGuid().ToString()[..8],
                Genre = (Genre)random.Next(Enum.GetNames(typeof(Genre)).Length),
                Price = (float)random.NextDouble() * 100,
                ReleaseDate = new DateTime(random.Next(1950, 2022), random.Next(1, 12), random.Next(1, 28)),
                Synopsis = "Movie_Synopsis_" + Guid.NewGuid().ToString(),
            };
        }
    }
}
