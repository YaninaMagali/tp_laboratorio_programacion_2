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
        public Botella(int id, float capacidadLitros)
        {
            this.id = id;
            this.capacidadLitros = capacidadLitros;
            //this.estaDisponible = true;
        }

        public float CapacidadLitros
        {
            get { return this.capacidadLitros; }
        }

        public int Id
        {
            get { return this.id; }
            //set { this.id = value; }
        }

        public bool EstaDisponible
        {
            get { return this.estaDisponible; }
            //set { this.id = value; }
        }


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
