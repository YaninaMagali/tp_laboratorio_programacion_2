using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public class LitrosAPrepararExcepcion : Exception
    {
        public LitrosAPrepararExcepcion(string mensaje) : base(mensaje)
        {

        }
        public LitrosAPrepararExcepcion(string mensaje, Exception ex) : base(mensaje, ex)
        {

        }
    }
}
