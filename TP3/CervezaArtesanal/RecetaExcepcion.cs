using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    class RecetaExcepcion : Exception
    {
        public RecetaExcepcion(string mensaje) : base(mensaje)
        {

        }
        public RecetaExcepcion(string mensaje, Exception ex) : base(mensaje, ex)
        {

        }
    }
}
