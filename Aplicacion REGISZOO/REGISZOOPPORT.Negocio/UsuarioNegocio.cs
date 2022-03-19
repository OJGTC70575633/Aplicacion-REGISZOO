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
    public class UsuarioNegocio
    {
        public static DataTable Listar()
        {
            UsuarioDatos objUsuario = new UsuarioDatos();
            return objUsuario.Listar();
        }
        public static DataTable Buscar(string Busqueda)
        {
            UsuarioDatos objUsuario = new UsuarioDatos();
            return objUsuario.Buscar(Busqueda);
        }
        public static string Insertar(string NombreCompleto, string NombreUsuario ,string Clave, string Rol, string Estado, string Email)
        {
            UsuarioDatos objUsuario= new UsuarioDatos();
            string Verificar = objUsuario.Verificar(NombreCompleto);
            if (Verificar.Equals("1"))
            {
                return "El Usuario ya existe en la BD";
            }
            else
            {
                //Instanciar la clase de la capa Entidad
                Usuario objUsuarioE = new Usuario();
                objUsuarioE.NombreCompleto = NombreCompleto;
                objUsuarioE.NombreUsuario = NombreUsuario;
                objUsuarioE.Clave = Clave;
                objUsuarioE.Rol = Rol;
                objUsuarioE.Estado = Estado;
                objUsuarioE.Email = Email;
                //objUsuarioE.DNI = Dni;
                //objUsuarioE.Celular = Celular;
                //objUsuarioE.Email = Email;


                return objUsuario.Insertar(objUsuarioE);
            }
        }

        public static string Actualizar(int IdUsuario, string NombreCompleto, string NombreUsuario, string Clave, string Rol, string Estado, string Email)
        {

            UsuarioDatos objUsuario = new UsuarioDatos();
            string Verificar = objUsuario.Verificar(NombreCompleto);
            if (Verificar.Equals("1"))
            {
                return "El Usuario ya existe en la BD";
            }
            else
            {
                //Instanciar la clase de la capa Entidad
                Usuario objUsuarioE = new Usuario();
                objUsuarioE.IdUsuario = IdUsuario;
                objUsuarioE.NombreCompleto = NombreCompleto;
                objUsuarioE.NombreUsuario = NombreUsuario;
                objUsuarioE.Clave = Clave;
                objUsuarioE.Rol = Rol;
                objUsuarioE.Estado = Estado;
                objUsuarioE.Email = Email;
                //objUsuarioE.DNI = Dni;
                //objUsuarioE.Celular = Celular;


                return objUsuario.Actualizar(objUsuarioE);
            }

        }

        public static string Eliminar(int Id_Usuario)
        {
            UsuarioDatos objUsuario = new UsuarioDatos();
            return objUsuario.Eliminar(Id_Usuario);
        }

        public static string Activar(int Id_Usuario)
        {
            UsuarioDatos objUsuario = new UsuarioDatos();
            return objUsuario.Activar(Id_Usuario);
        }

        //Desactivar

        public static string Desactivar(int Id_Usuario)
        {
            UsuarioDatos objUsuario = new UsuarioDatos();
            return objUsuario.Desactivar(Id_Usuario);
        }



    }
}
