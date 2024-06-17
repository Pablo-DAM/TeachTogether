using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeachTogether.Models;
using TeachTogether.Security;
using Newtonsoft.Json;
using AuthenticationManager = TeachTogether.Security.AuthenticationManager;
using System.Windows.Forms;
using TeachTogether.Models.ModuloModels;
namespace TeachTogether.Controllers
{
    public class ModulosController
    {
        HttpClient cliente;

        public ModulosController()
        {
            cliente = new HttpClient();
            string token = AuthenticationManager.GetToken();
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<List<ModulosModel>> getModulos()
        {
            
            HttpResponseMessage response= await cliente.GetAsync("http://localhost:4001/modulo");

            if(response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                List<ModulosModel> modulos = JsonConvert.DeserializeObject<List<ModulosModel>>(jsonString);

                return modulos;
            }
            else
            {
                
                string errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {response.StatusCode} - {errorResponse}");
            }
        }
        public  async Task<ModulosPOST>  postModulo(HttpContent content)
        {
            HttpResponseMessage response = await cliente.PostAsync("http://localhost:4001/modulo",content);
            if(response.IsSuccessStatusCode)
            {
              
                    MessageBox.Show("Módulo creado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    string responseBody = await response.Content.ReadAsStringAsync();

                    
                    ModulosPOST modulo = JsonConvert.DeserializeObject<ModulosPOST>(responseBody);
                    return modulo;
                }
                else
                {
                    MessageBox.Show("Error registrando el módulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
             }          
        }
        public async Task eliminarModulo(int id)
        {
            HttpResponseMessage response = await cliente.DeleteAsync("http://localhost:4001/modulo/"+id);
            if(response.IsSuccessStatusCode)
            {
                MessageBox.Show("Módulo eliminado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string responseBody = await response.Content.ReadAsStringAsync();
 
            }
            else
            {
                MessageBox.Show("Error eliminando el módulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
        }
        public async Task editarModulo(HttpContent content)
        {
            HttpResponseMessage response = await cliente.PutAsync("http://localhost:4001/modulo",content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Módulo editado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string responseBody = await response.Content.ReadAsStringAsync();

            }
            else
            {
                MessageBox.Show("Error editando el módulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public async Task<List<AlumnosModulosModel>> getAlumnosYModulosByAutoevaluacionID(int idAuto)
        {
            HttpResponseMessage response = await cliente.GetAsync("http://localhost:4001/modulo/alumnosModulos/"+ idAuto);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<AlumnosModulosModel> lista = JsonConvert.DeserializeObject<List<AlumnosModulosModel>>(responseBody);
                return lista;
            }
            else
            {
                throw new Exception("Error");
            }
        }

        public async Task<List<ModulosModel>> getModulosByAutoevaluacionID(int idAuto)
        {
            HttpResponseMessage response = await cliente.GetAsync("http://localhost:4001/modulo/auto/" + idAuto);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<ModulosModel> lista = JsonConvert.DeserializeObject<List<ModulosModel>>(responseBody);
                return lista;
            }
            else
            {
                throw new Exception("Error");
            }
        }
    }
}
