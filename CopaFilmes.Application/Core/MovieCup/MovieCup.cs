using CopaFilmes.Application.Dominio.MovieCup;
using CopaFilmes.Application.EnumApplication;
using CopaFilmes.Application.Useful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmes.Application.Core.MovieCup
{
    internal class MovieCup : IMovieCup
    {
        private readonly IApi<Movie> _api;

        public MovieCup(IApi<Movie> api)
        {
            this._api = api;
        }

        /// <summary>
        /// Monta todas as fases do campeotanto
        /// </summary>
        public IEnumerable<Movie> Championship(IList<Movie> selectedList)
        {
            var pharse = this.Phase(selectedList).ToList();
            var quarterFinals = this.QuarterFinals(pharse).ToList();
            var semiFinal = this.SemiFinal(quarterFinals).ToList();
            var final = this.Final(semiFinal).ToList();
            return null;
        }

        /// <summary>
        /// Retorna todos os filmes da API
        /// </summary>
        public IEnumerable<Movie> MovieAll(string urlApi)
        {
            return _api.GetList(urlApi);
        }

        /// <summary>
        /// Definie os Grupos
        /// </summary>
        private IEnumerable<PhaseGroup> Phase(IList<Movie> selectedList)
        {
            List<PhaseGroup> phaseGroup = new List<PhaseGroup>(16);
            int stepPhase = 0;

            do
            {
                int ranking = 0;
                var group = selectedList.Where(w => w.Selected == false).OrderBy(o => o.PrimaryTitle).Take(4);
                ++stepPhase;
                string phaseType = DescriptionPhaseType((EnumPhaseType)stepPhase);

                foreach (var item in group.OrderByDescending(o => o.AverageRating))
                {
                    item.Selected = true;
                    phaseGroup.Add(new PhaseGroup
                    {
                        AverageRating = item.AverageRating,
                        PrimaryTitle = item.PrimaryTitle,
                        PhaseType = phaseType,
                        Ranking = ++ranking
                    });
                }
            } while (selectedList.Where(w => w.Selected == false).Any());

            return phaseGroup;
        }

        /// <summary>
        /// Quartas de Finais
        /// </summary>
        private IEnumerable<PhaseClassified> QuarterFinals(IList<PhaseGroup> selectedList)
        {
            List<PhaseClassified> phaseClassifieds = new List<PhaseClassified>(4);

            var groupOneTeam = selectedList.Where(w => w.Ranking == 1).ToArray();
            var groupTwoTeam = selectedList.Where(w => w.Ranking == 2).ToArray();
            int oneTeam, twoTeam;

            for (int i = 0; i <= 1; i++)
            {
                oneTeam = (i == 0) ? 0 : 1;
                twoTeam = (i == 0) ? 1 : 0;
                phaseClassifieds.Add(this.StagePhase(groupOneTeam[oneTeam], groupTwoTeam[twoTeam], i));
            }

            for (int i = 2; i <= 3; i++)
            {
                oneTeam = (i == 2) ? 2 : 3;
                twoTeam = (i == 2) ? 3 : 2;
                phaseClassifieds.Add(this.StagePhase(groupOneTeam[oneTeam], groupTwoTeam[twoTeam], i));
            }

            return phaseClassifieds;
        }

        /// <summary>
        /// Montar as quartas de finais fases das qualificações
        /// </summary>
        private PhaseClassified StagePhase(PhaseGroup teamFirst, PhaseGroup teamSecond, int positionPhaseType)
        {
            PhaseClassified phaseClassified = new PhaseClassified();
            phaseClassified.TeamOne = teamFirst.PrimaryTitle;
            phaseClassified.AverageRatingOne = teamFirst.AverageRating;
            phaseClassified.TeamTwo = teamSecond.PrimaryTitle;
            phaseClassified.AverageRatingTwo = teamSecond.AverageRating;
            phaseClassified.PhaseType = DescriptionPhaseType(EnumPhaseType.QUARTAS_FINAIS);
            phaseClassified.PositionPhaseType = ++positionPhaseType;
            return phaseClassified;
        }

        /// <summary>
        /// Método para efetuar a semi final
        /// </summary>
        private IEnumerable<PhaseClassified> SemiFinal(IList<PhaseClassified> selectedList)
        {
            List<PhaseClassified> phaseClassifieds = new List<PhaseClassified>(2);
            PhaseClassified phaseClassified = new PhaseClassified();
            bool teamOne = true;

            for (int i = 0; i <= 1; i++)
            {
                var tupleTeamClassified = TeamClassified(selectedList[i]);
                if (teamOne)
                {
                    phaseClassified.TeamOne = tupleTeamClassified.Item1;
                    phaseClassified.AverageRatingOne = tupleTeamClassified.Item2;
                    phaseClassified.PhaseType = DescriptionPhaseType(EnumPhaseType.SEMIFINAL);
                    phaseClassified.PositionPhaseType = 1;
                    teamOne = false;
                }
                else
                {
                    phaseClassified.TeamTwo = tupleTeamClassified.Item1;
                    phaseClassified.AverageRatingTwo = tupleTeamClassified.Item2;
                }
            }

            teamOne = true;
            phaseClassifieds.Add(phaseClassified);
            phaseClassified = new PhaseClassified();

            for (int i = 2; i <= 3; i++)
            {
                var tupleTeamClassified = TeamClassified(selectedList[i]);
                if (teamOne)
                {
                    phaseClassified.TeamOne = tupleTeamClassified.Item1;
                    phaseClassified.AverageRatingOne = tupleTeamClassified.Item2;
                    phaseClassified.PhaseType = DescriptionPhaseType(EnumPhaseType.SEMIFINAL);
                    phaseClassified.PositionPhaseType = 2;
                    teamOne = false;
                }
                else
                {
                    phaseClassified.TeamTwo = tupleTeamClassified.Item1;
                    phaseClassified.AverageRatingTwo = tupleTeamClassified.Item2;
                }
            }

            phaseClassifieds.Add(phaseClassified);
            return phaseClassifieds;
        }

        /// <summary>
        /// Final devolve o campeao, o segundo lugar, o terceiro e o quarto lugar
        /// </summary>
        private IEnumerable<PhaseClassified> Final(IList<PhaseClassified> selectedList)
        {
            List<PhaseClassified> phaseClassifieds = new List<PhaseClassified>(2);
            PhaseClassified phaseClassified = new PhaseClassified();
            bool teamOne = true;

            for (int i = 0; i <= 1; i++)
            {
                var tupleTeamClassified = TeamClassified(selectedList[i]);
                if (teamOne)
                {
                    phaseClassified.TeamOne = tupleTeamClassified.Item1;
                    phaseClassified.AverageRatingOne = tupleTeamClassified.Item2;
                    phaseClassified.PhaseType = DescriptionPhaseType(EnumPhaseType.SEMIFINAL);
                    phaseClassified.PositionPhaseType = 1;
                    teamOne = false;
                }
                else
                {
                    phaseClassified.TeamTwo = tupleTeamClassified.Item1;
                    phaseClassified.AverageRatingTwo = tupleTeamClassified.Item2;
                }
            }

            teamOne = true;
            phaseClassifieds.Add(phaseClassified);
            phaseClassified = new PhaseClassified();

            for (int i = 2; i <= 3; i++)
            {
                var tupleTeamClassified = TeamClassified(selectedList[i]);
                if (teamOne)
                {
                    phaseClassified.TeamOne = tupleTeamClassified.Item1;
                    phaseClassified.AverageRatingOne = tupleTeamClassified.Item2;
                    phaseClassified.PhaseType = DescriptionPhaseType(EnumPhaseType.SEMIFINAL);
                    phaseClassified.PositionPhaseType = 2;
                    teamOne = false;
                }
                else
                {
                    phaseClassified.TeamTwo = tupleTeamClassified.Item1;
                    phaseClassified.AverageRatingTwo = tupleTeamClassified.Item2;
                }
            }

            phaseClassifieds.Add(phaseClassified);
            return phaseClassifieds;
        }


        /// <summary>
        /// Classificação dos times para SemiFinal
        /// </summary>
        private Tuple<string, decimal> TeamClassified(PhaseClassified classified)
        {
            Tuple<string, decimal> tupleClassified = null;
            int timeClassified = decimal.Compare(classified.AverageRatingOne, classified.AverageRatingTwo);

            switch (timeClassified)
            {
                case 1:
                    tupleClassified = new Tuple<string, decimal>(classified.TeamOne, classified.AverageRatingOne);
                    break;
                case 0:
                    List<string> nameFilmeOrder = new List<string>(2);
                    nameFilmeOrder.Add(classified.TeamOne);
                    nameFilmeOrder.Add(classified.TeamTwo);
                    nameFilmeOrder.Sort();
                    tupleClassified = new Tuple<string, decimal>(nameFilmeOrder[0] , classified.AverageRatingOne);
                    break;
                case -1:
                    tupleClassified = new Tuple<string, decimal>(classified.TeamTwo, classified.AverageRatingOne);
                    break;
            }

            return tupleClassified;
        }

        /// <summary>
        /// Método para definir o status que se encontra o campeonato
        /// </summary>
        private string DescriptionPhaseType(EnumPhaseType enumPhaseType)
        {
            string retorno = "";

            switch (enumPhaseType.GetHashCode())
            {
                case 1:
                    retorno = "Grupo A";
                    break;
                case 2:
                    retorno = "Grupo B";
                    break;
                case 3:
                    retorno = "Grupo C";
                    break;
                case 4:
                    retorno = "Grupo D";
                    break;
                case 5:
                    retorno = "Quartas Finais";
                    break;
                case 6:
                    retorno = "Semi Finais";
                    break;
                case 7:
                    retorno = "Terceiro Lugar";
                    break;
                case 8:
                    retorno = "Final";
                    break;
            }

            return retorno;
        }
    }
}
