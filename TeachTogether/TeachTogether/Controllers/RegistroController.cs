using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachTogether.Models;

namespace TeachTogether.Controllers
{
    public class RegistroController
    {
        HttpClient cliente;

        public RegistroController()
        {
            cliente = new HttpClient();
        }

        public async Task<UsuarioModel> registrarse(HttpContent content)
        {
            HttpResponseMessage respuesta = await cliente.PostAsync("http://localhost:4001/registro", content);

        
            if (respuesta.IsSuccessStatusCode)
            {
                MessageBox.Show("Registrado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Leer el contenido de la respuesta como una cadena JSON
                string responseBody = await respuesta.Content.ReadAsStringAsync();

                // Deserializar la cadena JSON a un objeto UsuarioModel
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(responseBody);
                return usuario;
            }
            else
            {
                MessageBox.Show("Ese usuario ya está en uso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
    }
}
