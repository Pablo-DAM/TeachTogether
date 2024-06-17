using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachTogether.Models
{
    public class ModuloPUT
    {
        public string nombre { get; set; }
        public string horario { get; set; }
        public int horas { get; set; }
        public string codigo { get; set; }
        public string dias { get; set; }
        public int id_profesor { get; set; }
        public int id_modulo { get; set; }
    }
}
