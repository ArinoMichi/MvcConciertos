using MvcConciertos.Models;
using System.Net.Http.Headers;

namespace MvcConciertos.Services
{
    public class ServiceApiConciertos
    {
        private KeysModel keys;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceApiConciertos(KeysModel keysModel)
        {
            this.keys = keysModel;
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(header);
                HttpResponseMessage response = await client.GetAsync(this.keys.Api + request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }
        public async Task<List<Evento>> GetEventosAsync()
        {
            string request = "api/Conciertos/GetEventos";
            List<Evento> data = await CallApiAsync<List<Evento>>(request);
            return data;
        }
    }
}
