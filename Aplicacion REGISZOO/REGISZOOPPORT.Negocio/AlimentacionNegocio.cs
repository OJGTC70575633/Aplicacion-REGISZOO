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
    public class AlimentacionNegocio
    {
        public static DataTable Listar()
        {
            AlimentacionDatos objAlimentacion = new AlimentacionDatos();
            return objAlimentacion.Listar();
        }
        public static DataTable Buscar(string Busqueda)
        {
            AlimentacionDatos objAlimentacion = new AlimentacionDatos();
            return objAlimentacion.Buscar(Busqueda);
        }
        public static string Insertar(string Nombre, string ClasificacionAlimentaria, string Descripcion, string CantidadDiaria)
        {
            AlimentacionDatos objAlimentacion = new AlimentacionDatos();
            string Verificar = objAlimentacion.Verificar(Nombre);
            if (Verificar.Equals("1"))
            {
                return "La Alimentacion ya existe en la BD";
            }
            else
            {
                //Instanciar la clase de la capa Entidad
                Alimentacion objAlimentacionE = new Alimentacion();
                objAlimentacionE.Nombre = Nombre;
                objAlimentacionE.ClasificacionAlimentaria = ClasificacionAlimentaria;
                objAlimentacionE.Descripcion = Descripcion;
                objAlimentacionE.CantidadDiaria = CantidadDiaria;


                return objAlimentacion.Insertar(objAlimentacionE);
            }
        }

        public static string Actualizar(int IdAlimentacion, string Nombre, string ClasificacionAlimentaria, string Descripcion, string CantidadDiaria)
        {

            AlimentacionDatos objAlimentacion = new AlimentacionDatos();
            string Verificar = objAlimentacion.Verificar(Nombre);
            if (Verificar.Equals("1"))
            {
                return "La Alimentacion ya existe en la BD";
            }
            else
            {
                //Instanciar la clase de la capa Entidad
                Alimentacion objAlimentacionE = new Alimentacion();
                objAlimentacionE.IdAlimentacion = IdAlimentacion;
                objAlimentacionE.Nombre = Nombre;
                objAlimentacionE.ClasificacionAlimentaria = ClasificacionAlimentaria;
                objAlimentacionE.Descripcion = Descripcion;
                objAlimentacionE.CantidadDiaria = CantidadDiaria;
                return objAlimentacion.Actualizar(objAlimentacionE);
            }

        }

        public static string Eliminar(int Id_Alimentacion)
        {
            AlimentacionDatos objAlimentacion = new AlimentacionDatos();
            return objAlimentacion.Eliminar(Id_Alimentacion);
        }

       

    }
}
