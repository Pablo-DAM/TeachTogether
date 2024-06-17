using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeachTogether.Models;
using TeachTogether.Security;
using AuthenticationManager = TeachTogether.Security.AuthenticationManager;

namespace TeachTogether.Controllers
{
    public class LoginController
    {
        private HttpClient client;
        public LoginController()
        {
            client = new HttpClient();
        }
        public async Task Login(string usuario, string password)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new { usuario, password }), Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            try
            {
                response = await client.PostAsync("http://localhost:4001/login", content);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var authData = JsonConvert.DeserializeObject<LoginData>(jsonResponse);
                    AuthenticationManager.SaveAuthenticationData(authData);
                }
                else
                {
                    
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    throw new Exception("Usuario o contraseña incorrectos. " + errorResponse);
                }
            }
            catch (HttpRequestException e)
            {
                
                throw new Exception("Error de conexión con la API: " + e.Message);
            }
        }
    }
}


