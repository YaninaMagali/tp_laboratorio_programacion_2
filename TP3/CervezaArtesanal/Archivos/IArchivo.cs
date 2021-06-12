using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    interface IArchivo<T>
    {
        void Guardar(string path, T dato);

    }
}
