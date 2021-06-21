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
        /// Consulta ingredientes y cantidad necesaria por litro de acuerdo al tipo de cerveza recibido
        /// </summary>
        /// <param name="tipoCerveza">Tipo de cerveza cuyos ingredientes y cantidades se quieren cosnsultar</param>
        /// <returns>Devuelve un diccionario con los ingredientes y cantidad necesaria por litro</returns>
        public Dictionary<EIngredientes, float> ConsultarRecetasPorTipoCerveza(ETipoCerveza tipoCerveza)
        {
            Dictionary<EIngredientes, float> ingredientesNecesarios = new Dictionary<EIngredientes, float>();

            comando.CommandText = "SELECT Ingredientes.nombreIngrediente, IngredientesPorReceta.cantidadNecesaria " +
                "FROM Recetas " +
                "INNER JOIN IngredientesPorReceta on IngredientesPorReceta.idReceta = Recetas.idReceta " +
                "INNER JOIN Ingredientes ON Ingredientes.idIngrediente = IngredientesPorReceta.IdIngrediente " +
                "WHERE Recetas.nombreReceta = @tipo ";

            comando.Parameters.AddWithValue("@tipo", tipoCerveza.ToString());

            try
            {
                this.conexion.AbrirConexion();
                SqlDataReader reader = this.comando.ExecuteReader();
                while (reader.Read())
                {
                    float cantidadNecesaria;
                    float.TryParse(reader["cantidadNecesaria"].ToString(), out cantidadNecesaria);
                    EIngredientes ingrediente;
                    Enum.TryParse<EIngredientes>(reader["nombreIngrediente"].ToString(), out ingrediente);

                    ingredientesNecesarios.Add(ingrediente, cantidadNecesaria);
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
            return ingredientesNecesarios;
        }
    }
}
