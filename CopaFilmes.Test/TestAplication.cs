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

        [TestMethod]
        public void MoviAll()
        {
            var listMovie = this._movieCup.MovieAll(_urlApi);
            Assert.IsNotNull(listMovie, "Não possui dados na lista");
        }

        [TestMethod]
        public void EliminationPhase()
        {
            var listMovie = this._movieCup.MovieAll(_urlApi).Take(16).ToList();
            var listEliminationPhase = this._movieCup.Championship(listMovie);
        }
    }
}
