using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero():this(0)
        {
        }
        
        public Numero(double numero)
        {
            this.numero = numero;
        }
        
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        private static double ValidarNumero(string strNumero)
        {
            double numero = 0;
            bool resultadoParse;

            if (resultadoParse = double.TryParse(strNumero, out numero) == false)
            {
                numero = 0;
            }

            return numero;
        }
        
        private static bool EsBinario(string binario)
        {
            bool esBinario = true;

            foreach (Char c in binario)
            {
                if (c != '0' && c != '1')
                {
                    esBinario = false;
                    break;
                }
            }

            return esBinario;
        }
        
        public static string DecimalBinario(double numero)
        {
            string binario  = null;
            string binarioAux = null;
            double resto;
            int i;
                
            while (numero > 0)
            {
                resto = (int)numero % 2;
                binarioAux = binarioAux + resto.ToString();
                numero = numero / 2;
                numero = Math.Truncate(numero);
            }
            int tam = binarioAux.Length;
            for (i = tam; i > 0; i--)
            {
                binario = binario + binarioAux[i-1];
            }

            return binario;
        }
        
        public static string DecimalBinario(string numero)
        {
            string binario = null;
            double auxValidacion;

            if (double.TryParse(numero, out auxValidacion))
            {
                binario = DecimalBinario(auxValidacion);
            }
            else
            {
                binario = "Valor inválido";
            }

            return binario;
        }
        
        public static string BinarioDecimal(string binario)
        {
            double aux;
            double numDecimal = 0;
            string strNumDecimal;
            int potencia = binario.Length-1;
            int tam = binario.Length;
            int i;

            if(EsBinario(binario))
            {
                for (i = 0; i < tam; i++)
                {
                    aux = double.Parse(binario[i].ToString());
                    numDecimal = numDecimal + (aux * Math.Pow(2, potencia));
                    potencia--;
                }

                strNumDecimal = numDecimal.ToString();

            }
            else
            {
                strNumDecimal = "Valor invalido";
            }

            return strNumDecimal;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;

            if(n2.numero == 0)
            {
                resultado = Double.MinValue;
            }
            else
            {
                resultado = n1.numero / n2.numero;
            }
            return resultado;
        }

    }
}
