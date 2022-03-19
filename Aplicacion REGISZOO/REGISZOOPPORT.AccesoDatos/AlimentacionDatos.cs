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
    public class AlimentacionDatos
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
                SqlCommand comando = new SqlCommand("SP_Alimentacion_LISTAR", sqlCnx);
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
                SqlCommand comando = new SqlCommand("SP_Alimentacion_LISTAR_BUSCAR", sqlCnx);
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
        public string Insertar(Alimentacion objAlimentacion)
        {
            string Rpta = "";
            SqlConnection sqlCnx = new SqlConnection();

            try
            {
                sqlCnx = ClsConexion.getInstancia().EstablecerConexion();
                SqlCommand comando = new SqlCommand("SP_Alimentacion_INSERTAR", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pnombre", SqlDbType.VarChar).Value = objAlimentacion.Nombre;
                comando.Parameters.Add("@pclasificacion_alimentaria", SqlDbType.VarChar).Value = objAlimentacion.ClasificacionAlimentaria;
                comando.Parameters.Add("@pdescripcion", SqlDbType.Text).Value = objAlimentacion.Descripcion;
                comando.Parameters.Add("@pcantidad_diaria", SqlDbType.VarChar).Value = objAlimentacion.CantidadDiaria;
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
        public string Actualizar(Alimentacion objAlimentacion)
        {
            string Rpta = "";
            SqlConnection sqlCnx = new SqlConnection();

            try
            {
                sqlCnx = ClsConexion.getInstancia().EstablecerConexion();
                SqlCommand comando = new SqlCommand("SP_Alimentacion_ACTUALIZAR", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pid_alimentacion", SqlDbType.Int).Value = objAlimentacion.IdAlimentacion;
                comando.Parameters.Add("@pnombre", SqlDbType.VarChar).Value = objAlimentacion.Nombre;
                comando.Parameters.Add("@pclasificacion_alimentaria", SqlDbType.VarChar).Value = objAlimentacion.ClasificacionAlimentaria;
                comando.Parameters.Add("@pdescripcion", SqlDbType.Text).Value = objAlimentacion.Descripcion;
                comando.Parameters.Add("@pcantidad_diaria", SqlDbType.VarChar).Value = objAlimentacion.CantidadDiaria;
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
                SqlCommand comando = new SqlCommand("SP_Alimentacion_ELIMINAR", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pid_alimentacion", SqlDbType.Int).Value = Id;
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
                SqlCommand comando = new SqlCommand("SP_Alimentacion_VERIFICAR", sqlCnx);
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
