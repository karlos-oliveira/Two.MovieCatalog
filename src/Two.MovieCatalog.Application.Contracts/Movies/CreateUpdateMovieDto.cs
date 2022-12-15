using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Two.MovieCatalog.Movies
{
    public class CreateUpdateMovieDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public string Synopsis { get; set; }

        [Required]
        public Genre Genre { get; set; } = Genre.Undefined;

        [Required]
        [DataType(DataType.Date)] 
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        [Required]
        public float Price { get; set; }
    }
}