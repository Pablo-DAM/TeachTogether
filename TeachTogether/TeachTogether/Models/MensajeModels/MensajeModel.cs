using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachTogether.Models
{
    public class MensajeModel
    {
        public int idMensaje { get; set; }
        public IdCreador idCreador { get; set; }
        public string texto { get; set; }
        public DateTime fechaCreaccion { get; set; }
        public IdReceptor idReceptor { get; set; }
    }
    public class IdCreador
    {
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public string rol { get; set; }
        public string password { get; set; }
    }

    public class IdReceptor
    {
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public string rol { get; set; }
        public string password { get; set; }
    }



}

