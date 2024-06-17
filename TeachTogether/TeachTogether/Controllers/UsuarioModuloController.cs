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
    public class UsuarioModuloController
    {
        private HttpClient cliente;
        public UsuarioModuloController()
        {
            cliente=new HttpClient();
            string token = AuthenticationManager.GetToken();
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<List<UsuarioModuloModel>> getAllUsuariosModulo()
        {
            HttpResponseMessage response =await cliente.GetAsync("http://localhost:4001/usuarioModulo");
            if(response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<UsuarioModuloModel> listaUsuariosModulos = JsonConvert.DeserializeObject<List<UsuarioModuloModel>>(jsonString);

                return listaUsuariosModulos;
            }
            else
            {

                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {response.StatusCode} - {errorResponse}");
            }
        }
        public async Task postAlumno(HttpContent content)
        {
            HttpResponseMessage response =await cliente.PostAsync("http://localhost:4001/usuarioModulo", content);
            if(!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Ese usuario ya está registrado en ese módulo","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Usuario registrado en el módulo satisfactoriamente","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        public async Task deleteAlumno(int idAlumno, int idModulo)
        {
            HttpResponseMessage response = await cliente.DeleteAsync("http://localhost:4001/usuarioModulo/"+ idAlumno+"/"+idModulo);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Ese usuario no está registrado en ese módulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Usuario eliminado en el módulo satisfactoriamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       
    }
}
    

