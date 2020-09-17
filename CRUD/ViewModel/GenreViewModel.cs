using System.ComponentModel.DataAnnotations;
using CRUD.Models;

namespace CRUD.ViewModel
{
    public class GenreViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Label => Id != 0 ? "Edit Genre" : "Add Genre";

        public GenreViewModel()
        {
            Id = 0;
        }

        public GenreViewModel(Genre genre)
        {
            Id = genre.Id;
            Name = genre.Name;
        }
    }
}