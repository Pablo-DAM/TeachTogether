using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachTogether.Models
{
    public class PerfilModel
    {
        public int idPerfil { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string fechaNacimiento { get; set; }
        public IdUsuario idUsuario { get; set; }
    }
    public class IdUsuario
    {
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public string rol { get; set; }
        public string password { get; set; }
    }


}

