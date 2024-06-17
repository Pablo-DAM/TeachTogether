using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachTogether.Models.UsuarioModels
{
    public class UsuarioPerfilByIdModuloModel
    {
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public object fecha_nacimiento { get; set; }
    }
}
