using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachTogether.Models.AutoevaluacionModels
{
    public class AutoevaluacionPreguntaRespuestaModel
    {
        public int idRespuesta { get; set; }
        public string textoRespuesta { get; set; }
        public IdPregunta idPregunta { get; set; }
        public IdAlumno idAlumno { get; set; }
    }
}

/*public class IdAutoevaluacion
{
    public int idAutoevaluacion { get; set; }
    public string titulo { get; set; }
    public IdProfesorCreador idProfesorCreador { get; set; }
}*/

public class IdPregunta
{
    public int idPregunta { get; set; }
    public IdAutoevaluacion idAutoevaluacion { get; set; }
    public string enunciadoPregunta { get; set; }
}

/*public class IdProfesorCreador
{
    public int idUsuario { get; set; }
    public string usuario { get; set; }
    public string rol { get; set; }
    public string password { get; set; }
}*/