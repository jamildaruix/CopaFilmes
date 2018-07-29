using System;
using CopaFilmes.Application.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void GroupStage()
        {
            this._moveCup.GroupStage(_urlApi);
        }
    }
}
