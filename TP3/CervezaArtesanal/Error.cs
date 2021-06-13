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

        /// <summary>
        /// Constructor que recibe una excepcion
        /// </summary>
        /// <param name="ex">excepcion recibida</param>
        public Error(Exception ex)
        { this.ex = ex; }

        /// <summary>
        /// Devuelve en formato string una excepcion con la fecha y hora en la que fue lanzada
        /// </summary>
        /// <returns>string una excepcion con la fecha y hora en la que fue lanzada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(ex.ToString());
            return sb.ToString();

        }
    }
}
