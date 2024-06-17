using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachTogether.Models;
using TeachTogether.Security;
namespace TeachTogether.Controllers
{
    public class PerfilesController
    {
        private HttpClient cliente;

        public PerfilesController()
        {
            cliente = new HttpClient();
            string token = AuthenticationManager.GetToken();
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<PerfilModel> getPerfil()
        {


            int id = AuthenticationManager.GetUserId();
            HttpResponseMessage respuesta =
                  await cliente.GetAsync("http://localhost:4001/perfil/usuario/" + id);
            respuesta.EnsureSuccessStatusCode();
            if (respuesta.IsSuccessStatusCode)
            {
                string jsonString = await respuesta.Content.ReadAsStringAsync();
                PerfilModel perfil = JsonConvert.DeserializeObject<PerfilModel>(jsonString);

                return perfil;
            }
            else
            {
                // Mejora del manejo de errores incluyendo más detalles del error
                string errorResponse = await respuesta.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {respuesta.StatusCode} - {errorResponse}");
            }
        }
        public async Task updatePerfil(HttpContent content)
        {
            int id = AuthenticationManager.GetUserId();


            HttpResponseMessage respuesta =
                  await cliente.PutAsync("http://localhost:4001/perfil", content);
           
            if (respuesta.IsSuccessStatusCode)
            {
                MessageBox.Show("Cambios Realizados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                
                string errorResponse = await respuesta.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {respuesta.StatusCode} - {errorResponse}");
            }
        }
        //Registro de perfil al crear un usuario nuevo
        public async Task registrarPerfil(HttpContent content)
        {
            HttpResponseMessage respuesta = await cliente.PostAsync("http://localhost:4001/perfil", content);
            

        }
        public async Task<PerfilModel> getPerfilById(int id)
        {
           
            HttpResponseMessage respuesta =
                  await cliente.GetAsync("http://localhost:4001/perfil/usuario/" + id);
            respuesta.EnsureSuccessStatusCode();
            if (respuesta.IsSuccessStatusCode)
            {
                string jsonString = await respuesta.Content.ReadAsStringAsync();
                PerfilModel perfil = JsonConvert.DeserializeObject<PerfilModel>(jsonString);

                return perfil;
            }
            else
            {
                // Mejora del manejo de errores incluyendo más detalles del error
                string errorResponse = await respuesta.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {respuesta.StatusCode} - {errorResponse}");
            }
        }
    }
}
