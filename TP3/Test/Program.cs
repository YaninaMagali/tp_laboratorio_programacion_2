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
            if (FabricaBebidas.Cocinar(1, "IPA", 5))
            { Console.WriteLine("Empezo A Cocinar "); }
            else { Console.WriteLine("NO COCINA"); }


            if (new RecetaCerveza(1, ETipoCerveza.IPA, 2) != null)
            {
                Console.WriteLine("Pudo crear receta");
            }

            if (FabricaBebidas.ValidarStockIngrediente(EIngredientes.Agua, 100))
            {
                Console.WriteLine("Hay stock ingredientes ");
            }


            List<Cerveza> listaBirra = new List<Cerveza>();
            CervezaIPA ipa = new CervezaIPA(new RecetaCerveza(1, ETipoCerveza.IPA, 1));
            CervezaKolsh kolsh = new CervezaKolsh(new RecetaCerveza(2, ETipoCerveza.Kolsh, 1));
            listaBirra.Add(ipa);
            listaBirra.Add(kolsh);


            Console.WriteLine("Las cervezas preparadas son: ");
            foreach (Cerveza c in listaBirra)
            {
                Console.WriteLine(c.ToString());
            }

            Console.ReadLine();

        }
    }
}
