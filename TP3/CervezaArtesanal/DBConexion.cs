using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace CervezaArtesanal
{
    public class DBConexion
    {
        private SqlConnection conexion;

        /// <summary>
        /// Constructor sin parametros. Crea una instancia de conexion a la base de datos con datos default
        /// </summary>
        public DBConexion()
        {
            this.conexion = new SqlConnection();
            conexion.ConnectionString = "Data Source=.; Initial Catalog=Cerveceria; Integrated Security=True";
        }

        /// <summary>
        /// Sobrecarga del constructor. Recibe la info para conectarse a la base de datos
        /// </summary>
        /// <param name="nombreServer">Nombre del servidor al que se quiere conectar</param>
        /// <param name="nombreBase">Nombre de la base a la que se quiere conectar</param>
        /// <param name="integratedSecurity"></param>
        public DBConexion(string nombreServer, string nombreBase, bool integratedSecurity)
            :this ()
        {
            conexion.ConnectionString = $"Data Source={nombreServer}; initialCatalog={nombreBase}; Integrated Security={integratedSecurity}.ToString()";
        }

        /// <summary>
        /// Propiedad de solo lectura para obtener la conexion
        /// </summary>
        public SqlConnection Conexion 
        {
            get { return this.conexion; }
        }

        /// <summary>
        /// Abre una conexion a la base si no existe una abierta
        /// </summary>
        /// <returns>Devuelve true si se pudo conectar, false en caso contrario</returns>
        public bool AbrirConexion()
        {
            bool conexionEstaAbierta = false;

            if (//this.conexion == null &&
                this.conexion.State == ConnectionState.Closed)
            {
                this.conexion.Open();
                conexionEstaAbierta = true;
            }
            return conexionEstaAbierta;
        }

        /// <summary>
        /// Cierra la conexion a la base de datos si es que se encuentra abierta
        /// </summary>
        /// <returns>Devuelve true si se pudo cerrar la conexion, false en caso contrario</returns>
        public bool CerrarConexion()
        {
            bool pudoCerrar = false;
            if (this.conexion.State != ConnectionState.Closed)
            {
                this.conexion.Close();
                pudoCerrar = true;
            }

            return pudoCerrar;
        }

    }
}
