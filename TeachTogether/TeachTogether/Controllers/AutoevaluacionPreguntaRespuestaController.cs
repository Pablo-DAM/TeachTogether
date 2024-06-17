using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeachTogether.Models.AutoevaluacionModels;
using TeachTogether.Security;
namespace TeachTogether.Controllers
{
    public class AutoevaluacionPreguntaRespuestaController
    {
        private HttpClient cliente;

        public AutoevaluacionPreguntaRespuestaController()
        {
            cliente = new HttpClient();
            string token = AuthenticationManager.GetToken();
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<List<AutoevaluacionPreguntaRespuestaModel>> getAllRespuestas()
        {
            HttpResponseMessage response = await cliente.GetAsync("http://localhost:4001/respuestaAutoevaluacion");

            if(response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                List<AutoevaluacionPreguntaRespuestaModel> deserializacion =JsonConvert.DeserializeObject<List<AutoevaluacionPreguntaRespuestaModel>>(responseJson);
                   return deserializacion;
            }
            else
            {
                throw new Exception("Error conectado con la API");
            }
        }
    }
}
