using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using REGISZOOPPORT.Entidad;

namespace REGISZOOPPORT.AccesoDatos
{
    public class EspecieDatos
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
                SqlCommand comando = new SqlCommand("SP_Especie_LISTAR", sqlCnx);
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
                SqlCommand comando = new SqlCommand("SP_Especie_LISTAR_BUSCAR", sqlCnx);
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
        public string Insertar(Especie objEspecie)
        {
            string Rpta = "";
            SqlConnection sqlCnx = new SqlConnection();

            try
            {
                sqlCnx = ClsConexion.getInstancia().EstablecerConexion();
                SqlCommand comando = new SqlCommand("SP_Especie_INSERTAR", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pid_alimentacion", SqlDbType.Int).Value = objEspecie.IdAlimentacion;
                comando.Parameters.Add("@pid_habitad_especie", SqlDbType.Int).Value = objEspecie.IdHabitatEspecie;
                comando.Parameters.Add("@pnombre_comun", SqlDbType.VarChar).Value = objEspecie.NombreComun;
                comando.Parameters.Add("@pnombre_cientifico", SqlDbType.VarChar).Value = objEspecie.NombreCientifico;
                comando.Parameters.Add("@pcantidad_animales", SqlDbType.Int).Value = objEspecie.CantidadAnimales;
                comando.Parameters.Add("@pestado", SqlDbType.Char).Value = objEspecie.Estado;
                comando.Parameters.Add("@pcategoria", SqlDbType.VarChar).Value = objEspecie.Categoria;
                comando.Parameters.Add("@ptiempo_gestacion", SqlDbType.VarChar).Value = objEspecie.TiempoGestacion;
                comando.Parameters.Add("@@ptiempo_exhibicion", SqlDbType.VarChar).Value = objEspecie.TiempoExhibicion;
                comando.Parameters.Add("@ptiempo_contencion", SqlDbType.VarChar).Value = objEspecie.TiempoContencion;
                comando.Parameters.Add("@pen_extincion", SqlDbType.Char).Value = objEspecie.EN_Extincion;
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
        public string Actualizar(Especie objEspecie)
        {
            string Rpta = "";
            SqlConnection sqlCnx = new SqlConnection();

            try
            {
                sqlCnx = ClsConexion.getInstancia().EstablecerConexion();
                SqlCommand comando = new SqlCommand("SP_Especie_ACTUALIZAR", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pid_habitad_especie", SqlDbType.Int).Value = objEspecie.IdEspecie;
                comando.Parameters.Add("@pid_alimentacion", SqlDbType.Int).Value = objEspecie.IdAlimentacion;
                comando.Parameters.Add("@pid_habitad_especie", SqlDbType.Int).Value = objEspecie.IdHabitatEspecie;
                comando.Parameters.Add("@pnombre_comun", SqlDbType.VarChar).Value = objEspecie.NombreComun;
                comando.Parameters.Add("@pnombre_cientifico", SqlDbType.VarChar).Value = objEspecie.NombreCientifico;
                comando.Parameters.Add("@pcantidad_animales", SqlDbType.Int).Value = objEspecie.CantidadAnimales;
                comando.Parameters.Add("@pestado", SqlDbType.Char).Value = objEspecie.Estado;
                comando.Parameters.Add("@pcategoria", SqlDbType.VarChar).Value = objEspecie.Categoria;
                comando.Parameters.Add("@ptiempo_gestacion", SqlDbType.VarChar).Value = objEspecie.TiempoGestacion;
                comando.Parameters.Add("@@ptiempo_exhibicion", SqlDbType.VarChar).Value = objEspecie.TiempoExhibicion;
                comando.Parameters.Add("@ptiempo_contencion", SqlDbType.VarChar).Value = objEspecie.TiempoContencion;
                comando.Parameters.Add("@pen_extincion", SqlDbType.Char).Value = objEspecie.EN_Extincion;
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
                SqlCommand comando = new SqlCommand("SP_Especie_ELIMINAR", sqlCnx);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@pid_especie", SqlDbType.Int).Value = Id;
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
                SqlCommand comando = new SqlCommand("SP_Especie_VERIFICAR", sqlCnx);
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
