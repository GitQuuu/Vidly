using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public string H2Tag {
            get
            {
                if (Id != 0)
                {
                    return "Edit movie";

                }

                return "New Movie";
            } 
        }
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter movie name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        [ForeignKey("Genre")]
        public int? GenreId { get; set; }

        [Required(ErrorMessage = "Please enter release date")]
        [Display(Name = "Release date")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Number must be in between 1-20")]
        [Display(Name = "Number in stock")]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        { 
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}