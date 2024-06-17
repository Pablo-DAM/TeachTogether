using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachTogether.Models.AutoevaluacionModels
{
    public class AutoevaluacionPreguntasModel
    {
        public int idPregunta { get; set; }
        public IdAutoevaluacion idAutoevaluacion { get; set; }
        public string enunciadoPregunta { get; set; }
    }
}
public class IdAutoevaluacion
{
    public int idAutoevaluacion { get; set; }
    public string titulo { get; set; }
    public IdProfesorCreador idProfesorCreador { get; set; }
}
//IdProfesorCreador está en otro namespace

