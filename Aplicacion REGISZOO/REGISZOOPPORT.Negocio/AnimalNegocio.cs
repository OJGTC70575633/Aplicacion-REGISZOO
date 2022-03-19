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
    public class AnimalNegocio
    {
        public static DataTable Listar()
        {
            AnimalDatos objAnimal = new AnimalDatos();
            return objAnimal.Listar();
        }
        public static DataTable Buscar(string Busqueda)
        {
            AnimalDatos objAnimal = new AnimalDatos();
            return objAnimal.Buscar(Busqueda);
        }
        public static string Insertar(int IdEspecie, string Nombre, string Sexo, string FechaObtencion, string LugarOrigen, string ENPrestamo)
        {
            AnimalDatos objAnimal = new AnimalDatos();
            string Verificar = objAnimal.Verificar(Nombre);
            if (Verificar.Equals("1"))
            {
                return "El Animal ya existe en la BD";
            }
            else
            {
                //Instanciar la clase de la capa Entidad
                Animal objAnimalE = new Animal();
                objAnimalE.IdEspecie = IdEspecie;
                objAnimalE.Nombre = Nombre;
                objAnimalE.Sexo = Sexo;
                objAnimalE.FechaObtencion = FechaObtencion;
                objAnimalE.LugarOrigen = LugarOrigen;
                objAnimalE.ENPrestamo = ENPrestamo;

             
                return objAnimal.Insertar(objAnimalE);
            }
        }

        public static string Actualizar(int IdAnimal,int IdEspecie, string Nombre, string Sexo, string FechaObtencion, string LugarOrigen, string ENPrestamo)
        {

            AnimalDatos objAnimal = new AnimalDatos();
            string Verificar = objAnimal.Verificar(Nombre);
            if (Verificar.Equals("1"))
            {
                return "El Animal ya existe en la BD";
            }
            else
            {
                //Instanciar la clase de la capa Entidad
                Animal objAnimalE = new Animal();
                objAnimalE.IdAnimal = IdAnimal;
                objAnimalE.IdEspecie = IdEspecie;
                objAnimalE.Nombre = Nombre;
                objAnimalE.Sexo = Sexo;
                objAnimalE.FechaObtencion = FechaObtencion;
                objAnimalE.LugarOrigen = LugarOrigen;
                objAnimalE.ENPrestamo = ENPrestamo;

                return objAnimal.Actualizar(objAnimalE);
            }

        }

        public static string Eliminar(int Id_Animal)
        {
            AnimalDatos objAnimal = new AnimalDatos();
            return objAnimal.Eliminar(Id_Animal);
        }

    }
}
