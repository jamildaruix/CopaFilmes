using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmes.Application.Service
{
    public interface IConfiguration
    {
        string AppSettingsConfiguration(int index);
        string AppSettingsConfiguration(string key);
    }
}
