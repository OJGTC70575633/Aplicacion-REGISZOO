using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace REGISZOOPPORT.AccesoDatos
{
    class ClsConexion
    {
        private string BD;
        private string Server;
        private string User;
        private string Clave;
        private bool Autenticacion;
        private static ClsConexion cnx = null;

        private ClsConexion()
        {
            this.BD = "bdotrosistema";
            this.Server = "DESKTOP-V74ANB3";//nombre de pc //ip /LOCALHOST / Dominio
            this.User = "DESKTOP-V74ANB3";
            this.Clave = "";//Colocar la clave de ustedes
            this.Autenticacion = true;


        }

        public SqlConnection EstablecerConexion()
        {
            SqlConnection url = new SqlConnection();

            try
            {
                url.ConnectionString = "Server=" + this.Server + ";" +
                    "DataBase=" + this.BD + ";";

                if (this.Autenticacion) // Seguridad Integrada
                {
                    url.ConnectionString = url.ConnectionString + "Integrated Security = SSPI";
                }
                else
                { //Autentificacion SQL 
                    url.ConnectionString = url.ConnectionString + "User Id=" + this.User + ";" + "Password=" + this.Clave;
                }

            }

            catch (Exception ex)
            {
                url = null;
                throw ex;
            }
            return url;
        }

        public static ClsConexion getInstancia()
        {
            if (cnx == null)
            {
                cnx = new ClsConexion();
            }
            return cnx;
        }




    }


}
