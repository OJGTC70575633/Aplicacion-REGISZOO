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
    public class ActividadNegocio
    {
        public static DataTable Listar()
        {
            ActividadDatos objActividad= new ActividadDatos();
            return objActividad.Listar();
        }
        public static DataTable Buscar(string Busqueda)
        {
            ActividadDatos objActividad = new ActividadDatos();
            return objActividad.Buscar(Busqueda);
        }
        public static string Insertar(int IdUsuario,  string Nombre, string Descripcion)
        {
            ActividadDatos objActividad = new ActividadDatos();
            string Verificar = objActividad.Verificar(Nombre);
            if (Verificar.Equals("1"))
            {
                return "La Actividad ya existe en la BD";
            }
            else
            {
                //Instanciar la clase de la capa Entidad
                Actividad objActividadE = new Actividad();
                objActividadE.IdUsuario = IdUsuario;
                objActividadE.Nombre = Nombre;
                objActividadE.Descripcion = Descripcion;
                

                return objActividad.Insertar(objActividadE);
            }
        }

        public static string Actualizar(int IdActividad, int IdUsuario, string Nombre, string Descripcion)
        {

            ActividadDatos objActividad = new ActividadDatos();
            string Verificar = objActividad.Verificar(Nombre);
            if (Verificar.Equals("1"))
            {
                return "La Actividad ya existe en la BD";
            }
            else
            {
                //Instanciar la clase de la capa Entidad
                Actividad objActividadE = new Actividad();
                objActividadE.IdActividad = IdActividad;
                objActividadE.IdUsuario = IdUsuario;
                objActividadE.Nombre = Nombre;
                objActividadE.Descripcion = Descripcion;

                return objActividad.Actualizar(objActividadE);
            }

        }

        public static string Eliminar(int Id_Actividad)
        {
            ActividadDatos objActividad = new ActividadDatos();
            return objActividad.Eliminar(Id_Actividad);
        }

    }
}
