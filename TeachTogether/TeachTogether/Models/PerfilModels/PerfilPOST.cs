using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachTogether.Models
{
    public class PerfilPOST
    {
        public int id_usuario {  get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string fecha_nacimiento { get; set; }
    }
}
