using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachTogether.Models.AutoevaluacionModels;
using TeachTogether.Security;
namespace TeachTogether.Controllers
{
    public class AutoevaluacionUsuariosController
    {
        private HttpClient cliente;
        public AutoevaluacionUsuariosController()
        {
            cliente = new HttpClient();
            string token = AuthenticationManager.GetToken();
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<HashSet<AutoevaluacionUsuariosModel>> getAllAutoevalucionUsuarios()
        {
            HttpResponseMessage response = await cliente.GetAsync("http://localhost:4001/autoevaluacionUsuario");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                HashSet<AutoevaluacionUsuariosModel> lista = JsonConvert.DeserializeObject<HashSet<AutoevaluacionUsuariosModel>>(json);
                return lista;
            }
            else
            {
                throw new Exception("Error conectando con la API");
            }
        }
        public async Task<ResultadoOperacion> postAutoevaluacionUsuario(HttpContent content)
        {
            try
            {
                HttpResponseMessage response = await cliente.PostAsync("http://localhost:4001/autoevaluacionUsuario", content);
                if (response.IsSuccessStatusCode)
                {
                    return new ResultadoOperacion { Exitoso = true };
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return new ResultadoOperacion { Exitoso = false, MensajeError = "Error: La Autoevaluación ya ha sido enviada a ese alumno." };
                }
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion { Exitoso = false, MensajeError = "Error al realizar la solicitud: " + ex.Message };
            }
        }
    }
}
public class ResultadoOperacion
{
    public bool Exitoso { get; set; }
    public string MensajeError { get; set; }
}