using CopaFilmes.Application.Dominio.MovieCup;
using CopaFilmes.Application.EnumApplication;
using CopaFilmes.Application.Useful;
using System;
using System.Collections.Generic;
using System.Linq;

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
            this.PhaseElimination(pharse);
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
                        PhaseType = phaseType
                    });
                }
            } while (selectedList.Where(w => w.Selected == false).Any());

            return phaseGroup;
        }

        private IEnumerable<PhaseGroup> PhaseElimination(IList<PhaseGroup> selectedList, EnumPhaseType enumPhaseType = EnumPhaseType.QUARTAS_FINAIS)
        {
            //var selectGroupPhaseElimination = (from selected in selectedList
            //                              group selected by selected.PhaseType
            //                              into eGroup
            //                              select eGroup);

            //var groups = selectedList.ToLookup(p => p.PhaseType);

            //foreach (var item in groups)
            //{
            //    var novo = item.OrderByDescending(o => o.AverageRating).Take(takeStep);
            //}

            return null;
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
