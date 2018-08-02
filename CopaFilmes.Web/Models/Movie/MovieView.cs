using System;
using System.ComponentModel.DataAnnotations;

namespace CopaFilmes.Web.Models.Movie
{
    public class MovieView
    {
        [Required]
        public string Id { get; set; }

        public string PrimaryTitle { get; set; }

        public string Year { get; set; }

        public string AverageRating { get; set; }
    }
}