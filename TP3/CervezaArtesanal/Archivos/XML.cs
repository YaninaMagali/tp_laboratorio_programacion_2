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
        public void Guardar(string path, T dato)
        {
            using (XmlTextWriter escritor = new XmlTextWriter(path, Encoding.UTF8))
            {
                XmlSerializer serializador = new XmlSerializer(typeof(T));
                serializador.Serialize(escritor, dato);
            }
        }

        public void WriteObject(string path, T dato)
        {
           
            FileStream writer = new FileStream(path, FileMode.Create);
            DataContractSerializer ser =
                new DataContractSerializer(typeof(T));
            ser.WriteObject(writer, dato);
            writer.Close();
        }

    }
}
