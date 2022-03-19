using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using REGISZOOPPORT.Entidad;
using REGISZOOPPORT.AccesoDatos;
using System.Data;
using System.Threading.Tasks;

namespace REGISZOOPPORT.Negocio
{
    public class HabitadEspecieNegocio
    {
        public static DataTable Listar()
        {
            HabitadEspecieDatos objHabitadEspecie = new HabitadEspecieDatos();
            return objHabitadEspecie.Listar();
        }
        public static DataTable Buscar(string Busqueda)
        {
            HabitadEspecieDatos objHabitadEspecie = new HabitadEspecieDatos();
            return objHabitadEspecie.Buscar(Busqueda);
        }
        public static string Insertar(int IdActividad, string Nombre, int CantidadAnimales , string Bioma)
        {
            HabitadEspecieDatos objHabitadEspecie = new HabitadEspecieDatos();
            string Verificar = objHabitadEspecie.Verificar(Nombre);
            if (Verificar.Equals("1"))
            {
                return "El HabitadEspecie o Area ya existe en la BD";
            }
            else
            {
                //Instanciar la clase de la capa Entidad
                HabitadEspecie objHabitadEspecieE = new HabitadEspecie();
                objHabitadEspecieE.IdActividad = IdActividad;
                objHabitadEspecieE.Nombre = Nombre;
                objHabitadEspecieE.CantidadAnimales = CantidadAnimales;
                objHabitadEspecieE.Bioma = Bioma;
            
                return objHabitadEspecie.Insertar(objHabitadEspecieE);
            }
        }

        public static string Actualizar(int IdHabitatEspecie,int IdActividad, string Nombre, int CantidadAnimales, string Bioma)
        {

            HabitadEspecieDatos objHabitadEspecie = new HabitadEspecieDatos();
            string Verificar = objHabitadEspecie.Verificar(Nombre);
            if (Verificar.Equals("1"))
            {
                return "El HabitadEspecie o Area ya existe en la BD";
            }
            else
            {
                //Instanciar la clase de la capa Entidad
                HabitadEspecie objHabitadEspecieE = new HabitadEspecie();
                objHabitadEspecieE.IdHabitatEspecie = IdHabitatEspecie;
                objHabitadEspecieE.IdActividad = IdActividad;
                objHabitadEspecieE.Nombre = Nombre;
                objHabitadEspecieE.CantidadAnimales = CantidadAnimales;
                objHabitadEspecieE.Bioma = Bioma;
                return objHabitadEspecie.Actualizar(objHabitadEspecieE);
            }

        }

        public static string Eliminar(int Id_HabitadEspecie)
        {
            HabitadEspecieDatos objAlimentacion = new HabitadEspecieDatos();
            return objAlimentacion.Eliminar(Id_HabitadEspecie);
        }

    }
}
