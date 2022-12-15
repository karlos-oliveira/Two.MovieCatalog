using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace Two.MovieCatalog.Movies
{
    public class MovieAppService_Tests: MovieCatalogApplicationTestBase
    {
        private readonly IMovieAppService _movieAppService;

        public MovieAppService_Tests()
        {
            _movieAppService = GetRequiredService<IMovieAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Movies()
        {
            //Act
            var result = await _movieAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
            );

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.Name.StartsWith("Movie_"));
        }

        [Fact]
        public async Task Should_Create_A_Valid_Movie()
        {
            //Act
            var result = await _movieAppService.CreateAsync(
                new CreateUpdateMovieDto
                {
                    Name = "New test movie",
                    Price = 10,
                    ReleaseDate = DateTime.Now,
                    Genre = Genre.ScienceFiction,
                    Synopsis = "Synopsis of the movie"
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("New test movie");
        }

        [Fact]
        public async Task Should_Not_Create_A_Movie_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _movieAppService.CreateAsync(
                    new CreateUpdateMovieDto
                    {
                        Name = "",
                        Price = 10,
                        ReleaseDate = DateTime.Now,
                        Genre = Genre.ScienceFiction,
                        Synopsis = "Synopsis of the movie"
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
        }
    }
}
