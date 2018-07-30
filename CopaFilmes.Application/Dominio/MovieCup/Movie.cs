using Newtonsoft.Json;
using System;

namespace CopaFilmes.Application.Dominio.MovieCup
{
    public class Movie
    { 
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "primaryTitle")]
        public string PrimaryTitle { get; set; }

        [JsonProperty(PropertyName = "year")]
        public Int16 Year { get; set; }

        [JsonProperty(PropertyName = "averageRating")]
        public decimal AverageRating { get; set; }

        [JsonIgnore]
        public bool Selected { get; set; }
    }
}
