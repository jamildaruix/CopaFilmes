using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CopaFilmes.Test
{
    [TestClass]
    public class TestAplication : StartupBasic
    {
        private string _urlApi;

        [TestInitialize]
        public void Init()
        {
            _urlApi = "https://copa-filmes.azurewebsites.net/api/filmes";
        }

        [TestMethod]
        public void Configuration()
        {
            var selectedLine = this._configuration.AppSettingsConfiguration("ApiCopaFilmes");
        }

        /// <summary>
        /// Método para consumir a API e retornar os 64 itens
        /// </summary>
        [TestMethod]
        public void MoviAll()
        {
            var listMovie = this._movieCup.MovieAll(_urlApi, 10);
            Assert.IsNotNull(listMovie, "Não possui dados na lista");
        }

        /// <summary>
        /// Método para efetuar o teste da copa filmes
        /// </summary>
        [TestMethod]
        public void EliminationPhase()
        {
            var listMovie = this._movieCup.MovieAll(_urlApi, 10).Take(16).ToList();
            var listEliminationPhase = this._movieCup.Championship(listMovie);
            Assert.IsNotNull(listEliminationPhase, "Não possui dados na lista");
        }

        /// <summary>
        /// Método para verificar se existe nota iguais
        /// </summary>
        [TestMethod]
        public void EliminationPhaseEqualsAverageRating()
        {
            var listMovie = this._movieCup.MovieAll(_urlApi, 10).ToList();

            foreach (var item in listMovie)
            {
                item.AverageRating = 5M;
            }
            
            var listEliminationPhase = this._movieCup.Championship(listMovie.Take(16).ToList());
            Assert.IsNotNull(listEliminationPhase, "Não possui dados na lista");
        }
    }
}
