using System;
using System.ComponentModel.DataAnnotations;

namespace CopaFilmes.Web.Models.Movie
{
    public class MovieView
    {
        [Required]
        public string Id { get; set; }

        public string PrimaryTitle { get; set; }

        public Int16 Year { get; set; }

        public decimal AverageRating { get; set; }
    }
}