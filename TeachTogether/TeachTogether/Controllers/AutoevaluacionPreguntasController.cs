using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeachTogether.Models.AutoevaluacionModels;
using TeachTogether.Security;
using Newtonsoft.Json;
using TeachTogether.Models;
using System.Windows.Forms;
namespace TeachTogether.Controllers
{
    public class AutoevaluacionPreguntasController
    {
        private HttpClient client;
        public AutoevaluacionPreguntasController() 
        {
            client= new HttpClient();
            string token = AuthenticationManager.GetToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<AutoevaluacionPreguntasModel>> getAutoevaluaciones()
        {
            HttpResponseMessage response =await client.GetAsync("http://localhost:4001/pregunta");
            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
               List<AutoevaluacionPreguntasModel>lista= JsonConvert.DeserializeObject<List<AutoevaluacionPreguntasModel>>(json);
                return lista;
            }
            else
            {
                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {response.StatusCode} - {errorResponse}");
            }
           
        }
        public async Task postPregunta(HttpContent content)
        {
            HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:4001/pregunta",content);
            if( responseMessage.IsSuccessStatusCode )
            {
                MessageBox.Show("Pregunta añadadida a la autoevaluación","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            else
            {
                string errorResponse = await responseMessage.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {responseMessage.StatusCode} - {errorResponse}");
            }
        }
        public async Task deletePregunta(int idPregunta)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync("http://localhost:4001/pregunta/"+idPregunta);
            if (responseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("Pregunta eliminada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string errorResponse = await responseMessage.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {responseMessage.StatusCode} - {errorResponse}");
            }
        }
        public async Task putPregunta(HttpContent content)
        {
            HttpResponseMessage response = await client.PutAsync("http://localhost:4001/pregunta", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cambios efectuados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {response.StatusCode} - {errorResponse}");
            }
        }
    }
}
