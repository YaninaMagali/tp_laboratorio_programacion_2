using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public static class Archivo
    {
        /// <summary>
        /// Guarda el string recibido como parametro en el path especificado por parametro. 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="datos"></param>
        /// <returns>Retorna true en caso de exito, false si no pudo guardar el archivo.</returns>
        public static void GuardarTexto(string path, string datos)
        {
            //bool pudoGuardar = true;
            StreamWriter escritor = new StreamWriter(path);

            using (escritor)
            {
                escritor.WriteLine(datos);

                //if (!File.Exists(path)) //si no existe, no se guardo nada = rip, retorno false.

            }
        }
    }
}
