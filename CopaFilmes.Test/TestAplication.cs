using System;
using CopaFilmes.Application.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CopaFilmes.Test
{
    [TestClass]
    public class TestAplication : StartupBasic
    {
        [TestMethod]
        public void Configuration()
        {
            var linha = this._configuration.AppSettingsConfiguration("ApiCopaFilmes");
        }
    }
}
