using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachTogether.Models;
using TeachTogether.Models.UsuarioModels;
using TeachTogether.Security;
namespace TeachTogether.Controllers
{
    public class UsuarioController
    {
        private HttpClient _httpClient;

        public UsuarioController()
        {
            _httpClient = new HttpClient();
            string token = AuthenticationManager.GetToken();
            
        }
        private void ConfigureAuthorizationHeader()
        {
            var token = AuthenticationManager.GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }
        public async Task<List<UsuarioModel>> GetUsuarios()
        {
            ConfigureAuthorizationHeader();

            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:4001/usuario");
            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                List<UsuarioModel> listaUsuarios = JsonConvert.DeserializeObject<List<UsuarioModel>>(responseJson);
                return listaUsuarios;
            }
            else
            {
              
                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {response.StatusCode} - {errorResponse}");
            }
        }
        public async Task<HttpResponseMessage> changePassword(HttpContent content)
        {
            ConfigureAuthorizationHeader();

            HttpResponseMessage responseMessage = await _httpClient.PutAsync("http://localhost:4001/usuario",content);
            responseMessage.EnsureSuccessStatusCode();
            if (responseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("Cambio de contraseña realizado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return responseMessage;
            }
            else
            {
               
                string errorResponse = await responseMessage.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {responseMessage.StatusCode} - {errorResponse}");
            }
        }
        public async Task<UsuarioModel> getUsuario()
        {
            ConfigureAuthorizationHeader();
            int idUsuario=AuthenticationManager.GetUserId();
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("http://localhost:4001/usuario/" + idUsuario);
            responseMessage.EnsureSuccessStatusCode();
            if(responseMessage.IsSuccessStatusCode)
            {
                string responseJson = await responseMessage.Content.ReadAsStringAsync();
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(responseJson);
                return usuario; 
            }
            else
            {
          
                string errorResponse = await responseMessage.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {responseMessage.StatusCode} - {errorResponse}");
            }
        }
        public async Task<UsuarioModel> getUsuarioById(int id)
        {
            ConfigureAuthorizationHeader();
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("http://localhost:4001/usuario/" + id);
            responseMessage.EnsureSuccessStatusCode();
            if (responseMessage.IsSuccessStatusCode)
            {
                string responseJson = await responseMessage.Content.ReadAsStringAsync();
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(responseJson);
                return usuario; 
            }
            else
            {
               
                string errorResponse = await responseMessage.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {responseMessage.StatusCode} - {errorResponse}");
            }
        }
        public async Task<List<UsuarioPerfilModel>> getPerfilByUsuario(string usuario)
        {
            ConfigureAuthorizationHeader();
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("http://localhost:4001/usuario/usuarioPerfil/" + usuario);
            responseMessage.EnsureSuccessStatusCode();
            if (responseMessage.IsSuccessStatusCode)
            {
                string responseJson = await responseMessage.Content.ReadAsStringAsync();
                List<UsuarioPerfilModel> usuarioPerfilModel= JsonConvert.DeserializeObject <List<UsuarioPerfilModel>>(responseJson);
                return usuarioPerfilModel; 
            }
            else
            {
                
                string errorResponse = await responseMessage.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {responseMessage.StatusCode} - {errorResponse}");
            }
        }
        public async Task<int>getIDbyUsuario(String usuario)
        {
            ConfigureAuthorizationHeader();
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("http://localhost:4001/usuario/usuario/" + usuario);
            if (responseMessage.IsSuccessStatusCode)
            {
                string responseJson = await responseMessage.Content.ReadAsStringAsync();
                int id = Convert.ToInt32(responseJson);
                return id;
            }
            else
            {
                MessageBox.Show("Error enviando la solicitud.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return -1;
            }
        }
        public async Task<List<UsuarioPerfilByIdModuloModel>> GetUsuariosPerfilesByIdModulo(int idModulo)
        {
            ConfigureAuthorizationHeader();
            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:4001/usuario/usuPerfil/"+idModulo);
            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                List<UsuarioPerfilByIdModuloModel> listaUsuarios = JsonConvert.DeserializeObject<List<UsuarioPerfilByIdModuloModel>>(responseJson);
                return listaUsuarios; 
            }
            else
            {
               
                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {response.StatusCode} - {errorResponse}");
            }
        }
    }

  }
