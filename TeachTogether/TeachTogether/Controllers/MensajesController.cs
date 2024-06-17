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
namespace TeachTogether.Controllers
{
    
    public class MensajesController
    {
        private HttpClient cliente;
        public MensajesController()
        {

            cliente=new HttpClient();
            string token = AuthenticationManager.GetToken();
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        }

        public async Task<List<MensajeModel>> getMensajesRecibidos()
        {
        HttpResponseMessage respuesta=  await cliente.GetAsync("http://localhost:4001/mensaje");

            if (respuesta.IsSuccessStatusCode)
            {

                string responseJson = await respuesta.Content.ReadAsStringAsync();
                List<MensajeModel> listaMensajes = JsonConvert.DeserializeObject<List<MensajeModel>>(responseJson);

                List<MensajeModel>mensajesFiltrados=new List<MensajeModel>();
                foreach (MensajeModel mensajeModel in listaMensajes)
                {
                    if (mensajeModel.idReceptor.idUsuario == AuthenticationManager.GetUserId())                     
                    {
                        mensajesFiltrados.Add(mensajeModel);
                    }
                }
                return mensajesFiltrados; 
            }
            else
            {
                // Mejora del manejo de errores incluyendo más detalles del error
                string errorResponse = await respuesta.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {respuesta.StatusCode} - {errorResponse}");
            }
        }
        public async Task<List<MensajeModel>> getMensajesEnviados()
        {
            HttpResponseMessage respuesta = await cliente.GetAsync("http://localhost:4001/mensaje");

            if (respuesta.IsSuccessStatusCode)
            {

                string responseJson = await respuesta.Content.ReadAsStringAsync();
                List<MensajeModel> listaMensajes = JsonConvert.DeserializeObject<List<MensajeModel>>(responseJson);

                List<MensajeModel> mensajesFiltrados = new List<MensajeModel>();
                foreach (MensajeModel mensajeModel in listaMensajes)
                {
                    if (mensajeModel.idCreador.idUsuario == AuthenticationManager.GetUserId())
                    {
                        mensajesFiltrados.Add(mensajeModel);
                    }
                }
                return mensajesFiltrados;
            }
            else
            {
                // Mejora del manejo de errores incluyendo más detalles del error
                string errorResponse = await respuesta.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud API: {respuesta.StatusCode} - {errorResponse}");
            }
        }
        public async Task<MensajeModel> enviarMensaje(HttpContent content)
        {
            HttpResponseMessage responseMessage = await cliente.PostAsync("http://localhost:4001/mensaje",content);

           

            if(responseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("Mensaje enviado satisfactoriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string responseBody = await responseMessage.Content.ReadAsStringAsync();
                MensajeModel mensajeEnviado = JsonConvert.DeserializeObject<MensajeModel>(responseBody);
                return mensajeEnviado;
            }
            else
            {
                MessageBox.Show("Error al enviar el mensaje.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public async  Task eliminarMensaje(int idMensajeEliminar)
        {
            HttpResponseMessage responseMessage = await cliente.DeleteAsync("http://localhost:4001/mensaje/" + idMensajeEliminar);
            if( responseMessage.IsSuccessStatusCode )
            {
                MessageBox.Show("Mensaje eliminado.","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error inesperado","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

    }
  
}
