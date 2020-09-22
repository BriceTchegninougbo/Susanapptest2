using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CRUD.Models;

namespace CRUD.ViewModel
{
    public class MovieViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        [Display(Name = "Number in Stock")]
        public int? NumberInStock { get; set; }

        public MovieViewModel()
        {
            Id = 0;
        }

        public MovieViewModel(Movie movie)
        {
            Name = movie.Name;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
        }
    }
}