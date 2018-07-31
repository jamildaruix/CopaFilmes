using Newtonsoft.Json;

namespace CopaFilmes.Application.Dominio.MovieCup
{
    public class PhaseClassified
    {
        [JsonProperty(PropertyName = "teamOne")]
        public string TeamOne { get; set; }

        [JsonProperty(PropertyName = "teamTwo")]
        public string TeamTwo { get; set; }

        [JsonProperty(PropertyName = "averageRatingOne")]
        public decimal AverageRatingOne { get; set; }

        [JsonProperty(PropertyName = "averageRatingTwo")]
        public decimal AverageRatingTwo { get; set; }

        [JsonProperty(PropertyName = "phaseType")]
        public string PhaseType { get; set; }

        [JsonProperty(PropertyName = "positionPhaseType")]
        public int PositionPhaseType { get; set; }
    }
}
