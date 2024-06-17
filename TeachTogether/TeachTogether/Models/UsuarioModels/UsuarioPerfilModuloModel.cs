using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachTogether.Models.UsuarioModels
{
    public class UsuarioPerfilModuloModel
    {
        public string usuario { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public object fechaNacimiento { get; set; }
        public int idAutoevaluacion { get; set; }
        public int idUsuario { get; set; }
    }
}
