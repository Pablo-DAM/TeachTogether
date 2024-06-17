using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeachTogether.Models;
using TeachTogether.Security;
using Newtonsoft.Json;
using System.Windows.Forms;
using TeachTogether.Models.UsuarioModels;
using TeachTogether.Models.AutoevaluacionModels;
namespace TeachTogether.Controllers
{

    public class AutoevaluacionesController
    {
        private HttpClient cliente;

        public AutoevaluacionesController()
        {
            cliente = new HttpClient();
            string token = AuthenticationManager.GetToken();
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<AutoevaluacionesModel>> getAutoevaluacionesByIdProf(int idProfesor)
        {
            HttpResponseMessage response = await cliente.GetAsync("http://localhost:4001/autoevaluacion/byProfId/" + idProfesor);

            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                List<AutoevaluacionesModel> listaAutos = JsonConvert.DeserializeObject<List<AutoevaluacionesModel>>(responseJson);
                return listaAutos;
            }
            else
            {

                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {response.StatusCode} - {errorResponse}");
            }
        }
        public async Task postAutoevaluacion(HttpContent content)
        {
            HttpResponseMessage response = await cliente.PostAsync("http://localhost:4001/autoevaluacion", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Autoevaluación creada satisfactoriamente.","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                throw new Exception($"Error en la solicitud API");
            }
        }
        public async Task putAutoevaluacion(HttpContent content)
        {
            HttpResponseMessage response = await cliente.PutAsync("http://localhost:4001/autoevaluacion", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Autoevaluación modificada satisfactoriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                throw new Exception($"Error en la solicitud API");
            }
        }
        public async Task deleteAutoevaluacion(int id)
        {
            HttpResponseMessage response = await cliente.DeleteAsync("http://localhost:4001/autoevaluacion/"+id);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Autoevaluación eliminada satisfactoriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                throw new Exception($"Error en la solicitud API");
            }

        }
        public async Task<List<AutoevaluacionesModel>> getAutoevaluacionByID(int idAuto)
        {
            HttpResponseMessage response = await cliente.GetAsync("http://localhost:4001/autoevaluacion/" + idAuto);

            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                List<AutoevaluacionesModel> listaAutos = JsonConvert.DeserializeObject<List<AutoevaluacionesModel>>(responseJson);
                return listaAutos;
            }
            else
            {

                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {response.StatusCode} - {errorResponse}");
            }
        }
        public async Task<List<UsuarioPerfilModuloModel>>getUsuarioPerfilModuloByIdAutoevaluacion(int idAuto)
        {
            HttpResponseMessage response = await cliente.GetAsync("http://localhost:4001/autoevaluacion/moduloByAutoevaluacionId/" + idAuto);
            if(response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                List<UsuarioPerfilModuloModel> lista = JsonConvert.DeserializeObject<List<UsuarioPerfilModuloModel>>(responseJson);
                return lista;
            }
            else
            {

                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {response.StatusCode} - {errorResponse}");
            }
        }
        public async Task<List<IdUsuarioSinModuloModel>> getUsuariosSinAuto(int idAu)
        {
            HttpResponseMessage response = await cliente.GetAsync("http://localhost:4001/autoevaluacion/idUsuario/" + idAu);
            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                List<IdUsuarioSinModuloModel> lista = JsonConvert.DeserializeObject<List<IdUsuarioSinModuloModel>>(responseJson);
                return lista;
            }
            else
            {

                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {response.StatusCode} - {errorResponse}");
            }
        }
    }
}

