using System;
using Volo.Abp.Application.Dtos;

namespace Two.MovieCatalog.Movies
{
    public class MovieDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Synopsis { get; set; }

        public Genre Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public float Price { get; set; }
    }
}
