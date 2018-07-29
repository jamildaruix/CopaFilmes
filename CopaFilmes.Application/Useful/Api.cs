using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmes.Application.Useful
{
    internal class Api<T> : IApi<T>
    {
        public IEnumerable<T> GetList(string url)
        {
            List<T> retorno = new List<T>();

            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(new Uri(url)).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    retorno = JsonConvert.DeserializeObject<List<T>>(responseString);
                }
                else
                {
                    retorno = null;
                }
            }

            return retorno;
        }
    }
}
