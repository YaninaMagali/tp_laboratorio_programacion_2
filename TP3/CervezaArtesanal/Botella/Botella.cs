using CervezaArtesanal.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public class Botella
    {
        private int id;
        private float capacidadLitros;
        private bool estaDisponible;
        private ETipoCerveza tipoCerveza;

        public Botella()
        {
                
        }

        /// <summary>
        /// Constructor, recibe el id y la capacidad
        /// </summary>
        /// <param name="id"></param>
        /// <param name="capacidadLitros"></param>
        public Botella(int id, float capacidadLitros)
        {
            this.id = id;
            this.capacidadLitros = capacidadLitros;
            //this.estaDisponible = true;
        }

        /// <summary>
        /// Propiedad que retorna la capacidad de almacenamiento en litros de la botella
        /// </summary>
        public float CapacidadLitros
        {
            get { return this.capacidadLitros; }
        }

        /// <summary>
        /// Propiedad que devueve el id de la botella
        /// </summary>
        public int Id
        {
            get { return this.id; }
            //set { this.id = value; }
        }

        /// <summary>
        /// Propiedad que retorna si la botella esta disponible para usar
        /// </summary>
        public bool EstaDisponible
        {
            get { return this.estaDisponible; }
            //set { this.id = value; }
        }

        /// <summary>
        /// Actualiza rn base de datos el valor que indica si la botella ya no esta disponible. 
        /// Para esto, evalua los litros que se van a embotellar, y de acuerdo a eso, va actualizando la disponibilidad de la lista de botellas.
        /// </summary>
        /// <param name="botellas"></param>
        /// <param name="litros"></param>
        public static void ActualizarBotellasDisponibles(List<Botella> botellas, float litros)
        {
            float litrosRestantes = litros;

            foreach (Botella b in botellas)
            {
                if (litrosRestantes > 0)
                {
                    if(b.CapacidadLitros >= litrosRestantes)
                    {
                        litrosRestantes = 0;
                    }
                    else
                    {
                        litrosRestantes = litros - b.CapacidadLitros;
                    }
                    
                    BotellaDAO dao = new BotellaDAO();
                    dao.ActualizarDisponibilidadBotella(b);
                }
            }
        }

        /// <summary>
        /// Devuelve la capacidad total en litros de almacenamiento de todas las botellas disponibles
        /// </summary>
        /// <param name="botellasDisponibles"></param>
        /// <returns></returns>
        public static float CapacidadTotalBotellas(List<Botella> botellasDisponibles)
        {
            float capacidadTotalDisponible = 0;

            foreach (Botella b in botellasDisponibles)
            {
                capacidadTotalDisponible += b.CapacidadLitros;
            }

            return capacidadTotalDisponible;
        }



        



    }


}
