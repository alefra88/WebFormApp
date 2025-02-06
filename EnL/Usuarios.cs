using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{

    public class Usuarios
    {
        public Usuarios()
        {
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
