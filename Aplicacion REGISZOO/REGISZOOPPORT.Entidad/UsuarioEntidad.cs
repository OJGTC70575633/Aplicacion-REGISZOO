using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REGISZOOPPORT.Entidad
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
        public string Email { get; set; }



    }
}
