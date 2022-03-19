using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REGISZOOPPORT.Entidad
{
    public class HabitadEspecie
    {
        public int IdHabitatEspecie { get; set; }
        public int IdActividad { get; set; }
        public string Nombre { get; set; }
        public string Bioma { get; set; }
        public int CantidadAnimales { get; set; }


    }
}
