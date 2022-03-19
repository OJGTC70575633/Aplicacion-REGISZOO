using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REGISZOOPPORT.Entidad
{
    public class Especie
    {
        public int IdEspecie { get; set; }
        public int IdAlimentacion { get; set; }
        public int IdHabitatEspecie { get; set; }
        public string NombreComun { get; set; }
        public string NombreCientifico { get; set; }
        public int CantidadAnimales { get; set; }

        public string Estado { get; set; }
        public string Categoria { get; set; }
        public string TiempoGestacion { get; set; }
        public string TiempoExhibicion { get; set; }
        public string TiempoContencion { get; set; }
        public string EN_Extincion { get; set; }
    


    }
}
