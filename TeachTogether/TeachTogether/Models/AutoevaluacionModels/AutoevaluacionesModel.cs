using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachTogether.Models
{
    public class AutoevaluacionesModel
    {
        public int idAutoevaluacion { get; set; }
        public string titulo { get; set; }
        public IdModulo id_modulo { get; set; }
        public IdProfesorCreador idProfesorCreador { get; set; }
    }
}
public class IdModulo
{
    public int idModulo { get; set; }
    public string nombre { get; set; }
    public string horario { get; set; }
    public int horas { get; set; }
    public IdProfesor idProfesor { get; set; }
    public string codigo { get; set; }
    public string dias { get; set; }
}

public class IdProfesor
{
    public int idUsuario { get; set; }
    public string usuario { get; set; }
    public string rol { get; set; }
    public string password { get; set; }
}

public class IdProfesorCreador
{
    public int idUsuario { get; set; }
    public string usuario { get; set; }
    public string rol { get; set; }
    public string password { get; set; }
}