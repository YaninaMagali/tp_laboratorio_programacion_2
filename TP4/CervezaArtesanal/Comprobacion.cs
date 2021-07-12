using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public static class Comprobacion
    {
        public static bool NoEsNull(this Object objeto)
        {
            return objeto != null;
        }
    }
}
