using Newtonsoft.Json;

namespace CopaFilmes.Application.Dominio.MovieCup
{
    public class PhaseGroup : Movie
    {
        [JsonProperty(PropertyName = "phaseType")]
        public string PhaseType { get; set; }

        [JsonProperty(PropertyName = "ranking")]
        public int Ranking { get; set; }
    }
}
