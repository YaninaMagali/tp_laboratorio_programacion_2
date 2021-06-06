using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CervezaArtesanal
{
    public class Error
    {
        public Exception ex;
        public DateTime date;

        public Error(Exception ex)
        { this.ex = ex; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(ex.ToString());
            //Archivo.GuardarTexto(pathErrorLog, sb.ToString());
            return sb.ToString();

        }
    }
}
