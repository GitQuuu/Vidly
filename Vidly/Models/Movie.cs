using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter movie name")]
        [StringLength(255)]
        public string Name { get; set; }


        [ForeignKey("Genre")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        [Required(ErrorMessage = "Please enter release date")]
        [Display(Name = "Release date")]
        public DateTime? ReleaseDate { get; set; }
        
        [Required(ErrorMessage = "Please enter date added")]
        [Display(Name = "Date added")]
        public DateTime? DateAdded { get; set; }
        
        [Required(ErrorMessage = "Number must be in between 1-20")]
        [Display(Name = "Number in stock")]
        [Range(1,20)]
        public int NumberInStock { get; set; }  
    
    }
}