using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CervezaArtesanal;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            if (FabricaBebidas.Cocinar(ETipoCerveza.IPA, 5))
                { Console.WriteLine("Empezo A Cocinar " ); }
            else { Console.WriteLine("NO COCINA"); }
            Console.ReadLine();
        }
    }
}
