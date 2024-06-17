using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachTogether.Models.AutoevaluacionModels
{
    public class AutoevaluacionPreguntasPUT
    {
        public int id_autoevaluacion {  get; set; }
        public string enunciado_pregunta { get; set; }
        public int id_pregunta { get; set; }
    }
}
