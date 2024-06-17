using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachTogether.Models
{
    public class MensajePOST
    {
        public int id_creador { get; set; }
        public string texto { get; set; }
        public DateTime fecha_creaccion { get; set; }
        public int id_receptor { get; set; }
    }
}

