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
    public class EspecieNegocio
    {
        public static DataTable Listar()
        {
            EspecieDatos objEspecie = new EspecieDatos();
            return objEspecie.Listar();
        }
        public static DataTable Buscar(string Busqueda)
        {
            EspecieDatos objEspecie = new EspecieDatos();
            return objEspecie.Buscar(Busqueda);
        }
        public static string Insertar(int IdAlimentacion, int IdHabitatEspecie, string NombreComun, string NombreCientifico, 
            string Estado, string Categoria, string TiempoGestacion, string TiempoExhibicion, string TiempoContencion, string EN_Extincion)
        {
            EspecieDatos objEspecie = new EspecieDatos();
            string Verificar = objEspecie.Verificar(NombreCientifico);
            if (Verificar.Equals("1"))
            {
                return "La Especie ya existe en la BD";
            }
            else
            {
                //Instanciar la clase de la capa Entidad
                Especie objEspecieE = new Especie();
                objEspecieE.IdAlimentacion = IdAlimentacion;
                objEspecieE.IdHabitatEspecie = IdHabitatEspecie;
                objEspecieE.NombreComun = NombreComun;
                objEspecieE.NombreCientifico = NombreCientifico;
                objEspecieE.Estado = Estado;
                objEspecieE.Categoria = Categoria;
                objEspecieE.TiempoGestacion = TiempoGestacion;
                objEspecieE.TiempoExhibicion = TiempoExhibicion;
                objEspecieE.TiempoContencion = TiempoContencion;
                objEspecieE.EN_Extincion = EN_Extincion;

                return objEspecie.Insertar(objEspecieE);
            }
        }

        public static string Actualizar(int IdEspecie, int IdAlimentacion, int IdHabitatEspecie, string NombreComun, string NombreCientifico, 
            string Estado, string Categoria, string TiempoGestacion, string TiempoExhibicion, string TiempoContencion, string EN_Extincion)
        {

            EspecieDatos objEspecie = new EspecieDatos();
            string Verificar = objEspecie.Verificar(NombreCientifico);
            if (Verificar.Equals("1"))
            {
                return "La Especie ya existe en la BD";
            }
            else
            {
                //Instanciar la clase de la capa Entidad
                Especie objEspecieE = new Especie();
                objEspecieE.IdEspecie = IdEspecie;
                objEspecieE.IdAlimentacion = IdAlimentacion;
                objEspecieE.IdHabitatEspecie = IdHabitatEspecie;
                objEspecieE.NombreComun = NombreComun;
                objEspecieE.NombreCientifico = NombreCientifico;
                objEspecieE.Estado = Estado;
                objEspecieE.Categoria = Categoria;
                objEspecieE.TiempoGestacion = TiempoGestacion;
                objEspecieE.TiempoExhibicion = TiempoExhibicion;
                objEspecieE.TiempoContencion = TiempoContencion;
                objEspecieE.EN_Extincion = EN_Extincion;
                return objEspecie.Actualizar(objEspecieE);
            }

        }

        public static string Eliminar(int Id_Especie)
        {
            EspecieDatos objEspecie = new EspecieDatos();
            return objEspecie.Eliminar(Id_Especie);
        }



    }
}
