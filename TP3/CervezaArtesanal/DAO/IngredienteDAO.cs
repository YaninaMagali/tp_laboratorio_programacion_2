using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal.DAO
{
    public class IngredienteDAO
    {
        public SqlCommand comando;
        public DBConexion conexion;

        public IngredienteDAO()
        {
            this.comando = new SqlCommand();
            this.conexion = new DBConexion();
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.Connection = conexion.Conexion;
        }

        /// <summary>
        /// Consulta stock ingredientes
        /// </summary>
        /// <returns>Devuelve una lista de ingredientes con su stock</returns>
        public List<Ingrediente> ConsultarStockIngredientes()
        {
            List<Ingrediente> ingredientes = new List<Ingrediente>();
            comando.CommandText = "SELECT * FROM Ingredientes;";

            try
            {
                this.conexion.AbrirConexion();
                SqlDataReader reader = this.comando.ExecuteReader();
                while (reader.Read())
                {
                    int idIngrediente;
                    int.TryParse(reader["idIngrediente"].ToString(), out idIngrediente);

                    EIngredientes nombreIngrediente;
                    Enum.TryParse<EIngredientes>(reader["nombreIngrediente"].ToString(), out nombreIngrediente);

                    float stock;
                    float.TryParse(reader["stockIngrediente"].ToString(), out stock);

                    ingredientes.Add(new Ingrediente(idIngrediente, nombreIngrediente, stock)); ;
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
            return ingredientes;
        }

        /// <summary>
        /// Consulta ingredientes y cantidad necesaria por litro de acuerdo al id del tipo de cerveza recibido
        /// </summary>
        /// <param name="idTipoCerveza">id del tipo de cerveza cuyos ingredientes y cantidades se quieren cosnsultar</param>
        /// <returns>Devuelve un diccionario con los ingredientes y cantidad necesaria por litro</returns>
        public Dictionary<EIngredientes, float> ConsultarIngredientesPorIdTipoCerveza(int idTipoCerveza)
        {
            Dictionary<EIngredientes, float> ingredientesNecesarios = new Dictionary<EIngredientes, float>();

            comando.CommandText = "SELECT Ingredientes.nombreIngrediente, IngredientesPorReceta.cantidadNecesaria " +
                "FROM Recetas " +
                "INNER JOIN IngredientesPorReceta on IngredientesPorReceta.idReceta = Recetas.idReceta " +
                "INNER JOIN Ingredientes ON Ingredientes.idIngrediente = IngredientesPorReceta.IdIngrediente " +
                "WHERE Recetas.idReceta = @id ";

            comando.Parameters.AddWithValue("@id", idTipoCerveza);

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


        public List<Ingrediente> ConsultarIngredientesPorIdTipoCerveza2(int idTipoCerveza)
        {
            List<Ingrediente> ingredientesNecesarios = new List<Ingrediente>();

            comando.CommandText = "SELECT Ingredientes.idIngrediente, Ingredientes.nombreIngrediente, IngredientesPorReceta.cantidadNecesaria " +
                "FROM Recetas " +
                "INNER JOIN IngredientesPorReceta on IngredientesPorReceta.idReceta = Recetas.idReceta " +
                "INNER JOIN Ingredientes ON Ingredientes.idIngrediente = IngredientesPorReceta.IdIngrediente " +
                "WHERE Recetas.idReceta = @id ";

            comando.Parameters.AddWithValue("@id", idTipoCerveza);

            try
            {
                this.conexion.AbrirConexion();
                SqlDataReader reader = this.comando.ExecuteReader();
                while (reader.Read())
                {

                    int idIngrediente;
                    int.TryParse(reader["idIngrediente"].ToString(), out idIngrediente);
                    float cantidadNecesaria;
                    float.TryParse(reader["cantidadNecesaria"].ToString(), out cantidadNecesaria);
                    EIngredientes ingrediente;
                    Enum.TryParse<EIngredientes>(reader["nombreIngrediente"].ToString(), out ingrediente);

                    ingredientesNecesarios.Add(new Ingrediente(idIngrediente, ingrediente, cantidadNecesaria));
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
