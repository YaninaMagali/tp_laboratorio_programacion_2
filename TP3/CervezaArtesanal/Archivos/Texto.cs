using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public class Archivo<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda el string recibido como parametro en el path especificado por parametro. 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna true en caso de exito, false si no pudo guardar el archivo.</returns>
        public void Guardar(string path, T dato)
        {
            //bool pudoGuardar = true;
            StreamWriter escritor = new StreamWriter(path, true);

            using (escritor)
            {
                escritor.WriteLine(dato);

                //if (!File.Exists(path)) //si no existe, no se guardo nada = rip, retorno false.

            }
        }
    }
}
