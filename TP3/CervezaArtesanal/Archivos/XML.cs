using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CervezaArtesanal
{
    public class XML<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda el objeto recibido por parametro en la ruta especificada
        /// </summary>
        /// <param name="path">ruta del archivo</param>
        /// <param name="dato">objeto a serializar</param>
        public void Guardar(string path, T dato)
        {
            using (XmlTextWriter escritor = new XmlTextWriter(path, Encoding.UTF8))
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                serializador.Serialize(escritor, dato);
            }
        }
    }
}
