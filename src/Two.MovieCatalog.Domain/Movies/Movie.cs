using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Two.MovieCatalog.Movies
{
    public class Movie : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public string Synopsis { get; set; }

        public Genre Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public float Price { get; set; }
    }
}
