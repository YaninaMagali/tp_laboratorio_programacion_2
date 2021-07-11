using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal.DAO
{
    public class BotellaDAO
    {
        public SqlCommand comando;
        public DBConexion conexion;

        public BotellaDAO()
        {
            this.comando = new SqlCommand();
            this.conexion = new DBConexion();
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.Connection = conexion.Conexion;
        }

        public List<Botella> ConsultarBotellasDisponibles()
        {
            List<Botella> botellas = new List<Botella>();
            comando.CommandText = "SELECT * FROM Botellas WHERE estaDisponible = 1;";

            try
            {
                this.conexion.AbrirConexion();
                SqlDataReader reader = this.comando.ExecuteReader();
                while (reader.Read())
                {
                    int idBotella;
                    int.TryParse(reader["idBotella"].ToString(), out idBotella);    

                    float capacidadLitros;
                    float.TryParse(reader["capacidadLitros"].ToString(), out capacidadLitros);

                    botellas.Add(new Botella(idBotella, capacidadLitros)); ;
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
            return botellas;
        }



        public void ActualizarDisponibilidadBotella(Botella botella)
        {
            comando.CommandText = "UPDATE Botellas SET estaDisponible = @estaDisponible, idReceta = NULL " +
                "WHERE idBotella = @idBotella;";

            try
            {
                this.conexion.AbrirConexion();
                comando.Parameters.AddWithValue("@estaDisponible", 0);
                //comando.Parameters.AddWithValue("@idReceta", ETipoCerveza.IPA);
                comando.Parameters.AddWithValue("@idBotella", botella.Id);
                this.comando.ExecuteNonQuery();
                comando.Parameters.Clear();
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
        }



    }
}
