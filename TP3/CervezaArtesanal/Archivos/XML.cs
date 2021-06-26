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

        /// <summary>
        /// Deserializa xml que recupera del path recibido como param
        /// </summary>
        /// <param name="path">ruta del archivo a deserializar</param>
        /// <returns>Devuelve un objeto de tipo generico deserializado </returns>
        public T Leer(string path)
        {
            T dato;

            using (XmlTextReader lector = new XmlTextReader(path))
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));

                dato = (T)serializador.Deserialize(lector);
            }

            return dato;
                
        }

    }
}
