using LetreroVuelos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LetreroVuelos.Services
{
    public class VueloServices
    {

        HttpClient client;
        public VueloServices()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://skyisllandaerolinea.sistemas19.com/")
            };
        }

        public event Action<Vuelo>? evvuelo;

        public async Task<List<Vuelo>> GetVuelo( )
        {
            List<Vuelo>? list = null;
            var response = await client.GetAsync("api/Aerolinea");
            if (response.IsSuccessStatusCode)
            {
                var Json = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<Vuelo>?>(Json);
            }
            if (list !=null)
            {
                return list;
            }
            else
            {
                return new List<Vuelo>();
            }
        }
    }
}
