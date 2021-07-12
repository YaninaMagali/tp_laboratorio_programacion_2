using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CervezaArtesanal.DAO
{
    public class RecetaDAO
    {
        public SqlCommand comando;
        public DBConexion conexion;

        /// <summary>
        /// Constructor: instancia un comando y una conexion a la base de datos
        /// </summary>
        public RecetaDAO()
        {
            this.comando = new SqlCommand();
            this.conexion = new DBConexion();
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.Connection = conexion.Conexion;
        }

      
        /// <summary>
        /// Consulta las recetas cargadas en la base
        /// </summary>
        /// <returns>Devuelve un diccionario con los id y nombres de las recetas</returns>
        public Dictionary<string, int> ConsultarRecetas()
        {
            Dictionary<string, int> recetas = new Dictionary<string, int>();
            comando.CommandText = "SELECT * FROM Recetas";

            try
            {
                this.conexion.AbrirConexion();
                SqlDataReader reader = this.comando.ExecuteReader();
                while (reader.Read())
                {
                    int idReceta;
                    int.TryParse(reader["idReceta"].ToString(), out idReceta);
                    string tipoCerveza = (reader["nombreReceta"].ToString());
                    recetas.Add(tipoCerveza, idReceta);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.CerrarConexion();
                comando.Parameters.Clear();
            }
            return recetas;
        }
    }
}
