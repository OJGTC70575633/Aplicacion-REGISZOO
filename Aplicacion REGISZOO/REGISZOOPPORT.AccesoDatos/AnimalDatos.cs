using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REGISZOOPPORT.Entidad;

namespace REGISZOOPPORT.AccesoDatos
{
    public class AnimalDatos
    {
        //crear Metodos
        //Metodo Listar

        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlCnx = new SqlConnection();

            try
            {
                sqlCnx = ClsConexion.getInstancia().EstablecerConexion();
                SqlCommand comando = new SqlCommand("SP_Animal_LISTAR", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                sqlCnx.Open();
                Resultado = comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCnx.State == ConnectionState.Open)
                {
                    sqlCnx.Close();
                }
            }
        }

        //Metodo Buscar

        public DataTable Buscar(string Busqueda)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlCnx = new SqlConnection();

            try
            {
                sqlCnx = ClsConexion.getInstancia().EstablecerConexion();
                SqlCommand comando = new SqlCommand("SP_Animal_LISTAR_BUSCAR", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pbusqueda", SqlDbType.VarChar).Value = Busqueda;
                sqlCnx.Open();
                Resultado = comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCnx.State == ConnectionState.Open)
                {
                    sqlCnx.Close();
                }
            }
        }

        //Metodo Insertar
        public string Insertar(Animal objAnimal)
        {
            string Rpta = "";
            SqlConnection sqlCnx = new SqlConnection();

            try
            {
                sqlCnx = ClsConexion.getInstancia().EstablecerConexion();
                SqlCommand comando = new SqlCommand("SP_Animal_INSERTAR", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pid_especie", SqlDbType.Int).Value = objAnimal.IdEspecie;
                comando.Parameters.Add("@pnombre", SqlDbType.VarChar).Value = objAnimal.Nombre;
                comando.Parameters.Add("@psexo", SqlDbType.Char).Value = objAnimal.Sexo;
                comando.Parameters.Add("@pfecha_obtencion", SqlDbType.VarChar).Value = objAnimal.FechaObtencion;
                comando.Parameters.Add("@plugar_origen", SqlDbType.VarChar).Value = objAnimal.LugarOrigen;
                comando.Parameters.Add("@pen_prestamo", SqlDbType.Char).Value = objAnimal.ENPrestamo;
                sqlCnx.Open();
                Rpta = comando.ExecuteNonQuery() == 1 ? "OK registro insertado" : "No se pudo insertar el registro";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (sqlCnx.State == ConnectionState.Open)
                {
                    sqlCnx.Close();
                }
            }
            return Rpta;
        }

        //Metodo Actualizar
        public string Actualizar(Animal objAnimal)
        {
            string Rpta = "";
            SqlConnection sqlCnx = new SqlConnection();

            try
            {
                sqlCnx = ClsConexion.getInstancia().EstablecerConexion();
                SqlCommand comando = new SqlCommand("SP_Animal_ACTUALIZAR", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pid_animal", SqlDbType.Int).Value = objAnimal.IdAnimal;
                comando.Parameters.Add("@pid_especie", SqlDbType.Int).Value = objAnimal.IdEspecie;
                comando.Parameters.Add("@pnombre", SqlDbType.VarChar).Value = objAnimal.Nombre;
                comando.Parameters.Add("@psexo", SqlDbType.Char).Value = objAnimal.Sexo;
                comando.Parameters.Add("@pfecha_obtencion", SqlDbType.VarChar).Value = objAnimal.FechaObtencion;
                comando.Parameters.Add("@plugar_origen", SqlDbType.VarChar).Value = objAnimal.LugarOrigen;
                comando.Parameters.Add("@pen_prestamo", SqlDbType.Char).Value = objAnimal.ENPrestamo;
                sqlCnx.Open();
                Rpta = comando.ExecuteNonQuery() == 1 ? "OK registro Actualizado" : "No se pudo actualizar el registro";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (sqlCnx.State == ConnectionState.Open)
                {
                    sqlCnx.Close();
                }
            }
            return Rpta;
        }

        //Metodo Eliminar
        public string Eliminar(int Id)
        {
            string Rpta = "";
            SqlConnection sqlCnx = new SqlConnection();

            try
            {
                sqlCnx = ClsConexion.getInstancia().EstablecerConexion();
                SqlCommand comando = new SqlCommand("SP_Animal_ELIMINAR", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pid_animal", SqlDbType.Int).Value = Id;
                sqlCnx.Open();
                Rpta = comando.ExecuteNonQuery() == 1 ? "OK registro Eliminado" : "No se pudo Eliminar el registro";

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (sqlCnx.State == ConnectionState.Open)
                {
                    sqlCnx.Close();
                }
            }
            return Rpta;
        }

        //Metodo Verificar
        public string Verificar(string valor)
        {
            string Rpta = "";
            SqlConnection sqlCnx = new SqlConnection();

            try
            {
                sqlCnx = ClsConexion.getInstancia().EstablecerConexion();
                SqlCommand comando = new SqlCommand("SP_Animal_VERIFICAR", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pvalor", SqlDbType.VarChar).Value = valor;
                SqlParameter ParExiste = new SqlParameter();
                ParExiste.ParameterName = "@pexiste";
                ParExiste.SqlDbType = SqlDbType.Int;
                ParExiste.Direction = ParameterDirection.Output;
                comando.Parameters.Add(ParExiste);
                sqlCnx.Open();
                Rpta = Convert.ToString(ParExiste.Value);

            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (sqlCnx.State == ConnectionState.Open)
                {
                    sqlCnx.Close();
                }
            }
            return Rpta;
        }


    }
}
