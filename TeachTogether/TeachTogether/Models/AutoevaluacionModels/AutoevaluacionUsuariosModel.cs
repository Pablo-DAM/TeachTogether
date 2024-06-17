using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachTogether.Models.AutoevaluacionModels
{
    public class AutoevaluacionUsuariosModel
    {
        public int idAutoevaluacion { get; set; }
        public int idAlumno { get; set; }
        public Autoevaluacion autoevaluacion { get; set; }
        public Alumno alumno { get; set; }
        public string fecha_realizacion { get; set; }
    }
}
public class Alumno
{
    public int idUsuario { get; set; }
    public string usuario { get; set; }
    public string rol { get; set; }
    public string password { get; set; }
}

public class Autoevaluacion
{
    public int idAutoevaluacion { get; set; }
    public string titulo { get; set; }
    public IdProfesorCreador idProfesorCreador { get; set; }
}

/*public class IdProfesorCreador
{
    public int idUsuario { get; set; }
    public string usuario { get; set; }
    public string rol { get; set; }
    public string password { get; set; }
}*/