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

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [ForeignKey("Genre")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        [Display(Name = "Release date")]
        public DateTime? ReleaseDate { get; set; }
        
        [Required]
        [Display(Name = "Date added")]
        public DateTime? DateAdded { get; set; }
        
        [Required]
        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }  
    
    }
}