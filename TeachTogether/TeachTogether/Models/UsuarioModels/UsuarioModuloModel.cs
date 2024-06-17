using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachTogether.Models
{
    public class UsuarioModuloModel
    {
        public IdAlumno id_alumno { get; set; }
        public IdModulo id_modulo { get; set; }
        public int idModulo { get; set; }
        public int idAlumno { get; set; }
    }
}
public class IdAlumno
{
    public int idUsuario { get; set; }
    public string usuario { get; set; }
    public string rol { get; set; }
    public string password { get; set; }
}



