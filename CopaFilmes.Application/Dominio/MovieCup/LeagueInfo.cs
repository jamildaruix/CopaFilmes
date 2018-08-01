using Newtonsoft.Json;
using System.Collections.Generic;

namespace CopaFilmes.Application.Dominio.MovieCup
{
    public class LeagueInfo
    {
        public LeagueInfo()
        {
            this.Champions = new List<KeyValuePair<int, string>>(3);
            this.PhaseGroups = new List<PhaseGroup>(16);
            this.QuarterFinalsGroups = new List<PhaseClassified>(4);
            this.SemiFinalGroups = new List<PhaseClassified>(2);
            this.FinalGroups = new List<PhaseClassified>(2);
        }

        [JsonProperty(PropertyName = "champions")]
        public IList<KeyValuePair<int, string>> Champions { get; set; }

        [JsonProperty(PropertyName = "phaseGroups")]
        public IList<PhaseGroup> PhaseGroups { get; set; }

        [JsonProperty(PropertyName = "quarterFinalsGroups")]
        public IList<PhaseClassified> QuarterFinalsGroups { get; set; }

        [JsonProperty(PropertyName = "semiFinalGroups")]
        public IList<PhaseClassified> SemiFinalGroups { get; set; }

        [JsonProperty(PropertyName = "finalGroups")]
        public IList<PhaseClassified> FinalGroups { get; set; }

        [JsonIgnore]
        public string JsonLeague { get; set; }
    }
}
