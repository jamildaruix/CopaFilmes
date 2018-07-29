using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmes.Application.Useful
{
    internal interface IApi<T>
    {
        IEnumerable<T> GetList(string url);
    }
}
