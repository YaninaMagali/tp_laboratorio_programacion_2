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

        /// <summary>
        /// Constructor. Invoca a una de las sobrecargas del propio constructor
        /// </summary>
        public Numero():this(0)
        {
        }

        /// <summary>
        /// Sobrecarga del constructor. Asigna valor al atributo numero
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// /// Sobrecarga del constructor. Asigna valor al atributo numero, llamando a la property que hace la validacion si es numero
        /// </summary>
        /// <param name="strNumero">Recibe el valor a asignar al atributo numero</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Asigna valor al atributo numero, pasando previamente por la validacion
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Valida si el string recibido esta compuesto unicamente por numeros
        /// </summary>
        /// <param name="strNumero">Recibe un string a evaluar</param>
        /// <returns>Si la cadena esta compuesta solo por numeros devuelve su equivalente 
        /// en  tipo double,  sino 0</returns>
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
        
        /// <summary>
        /// Valida si el string recibido esta compuesto unicamente por 0 y 1
        /// </summary>
        /// <param name="binario">Recibe un string</param>
        /// <returns>Devuelve true si es binario, caso contrario devuelve false</returns>
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
        
        /// <summary>
        /// COnvierte el numero recibido a binario
        /// </summary>
        /// <param name="numero">Recibe el numero a convertir</param>
        /// <returns>Devuelve el numero en binario</returns>
        public static string DecimalBinario(double numero)
        {
            string binario  = null;
            string binarioAux = null;
            double resto;
            int i;

            if(numero == 0)
            {
                binario = "0";
            }
            else
            {
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
                    binario = binario + binarioAux[i - 1];
                }
            }


            return binario;
        }
        
        /// <summary>
        /// Convierte la parte entera de un numero decimal a binario
        /// </summary>
        /// <param name="numero">Si lo recibido es un numero lo convierte a binario, caso contrario devuelve un mensaje</param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            string binario = null;
            double auxValidacion;

            if (double.TryParse(numero, out auxValidacion) && auxValidacion >= 0)
            {
                binario = DecimalBinario(auxValidacion);
            }
            else
            {
                binario = "Valor inválido";
            }

            return binario;
        }
        
        /// <summary>
        /// Recibe un string. Si se trata de una cadena compuesta por 0 y 1 la convierte a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Si lo puede convertir, devuelve el numero convertido a decimal, caso contrario devuelve un mensaje de error </returns>
        public static string BinarioDecimal(string binario)
        {
            double aux;
            double numDecimal = 0;
            string strNumDecimal;
            int potencia = binario.Length-1;
            int tam = binario.Length;
            int i;

            if(EsBinario(binario) )
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
        
        /// <summary>
        /// Sobrecarga del operador suma
        /// </summary>
        /// <param name="n1">Recibe un dato de tipo Numero</param>
        /// <param name="n2">Recibe un dato de tipo Numero</param>
        /// <returns>Opera con el atributo numero del tipo Numero y devuelve el resultado</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        
        /// <summary>
        /// Sobrecarga del operador resta
        /// </summary>
        /// <param name="n1">Recibe un dato de tipo Numero</param>
        /// <param name="n2">Recibe un dato de tipo Numero</param>
        /// <returns>Opera con el atributo numero del tipo Numero y devuelve el resultado</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        
        /// <summary>
        /// Sobrecarga del operador producto
        /// </summary>
        /// <param name="n1">Recibe un dato de tipo Numero</param>
        /// <param name="n2">Recibe un dato de tipo Numero</param>
        /// <returns>Opera con el atributo numero del tipo Numero y devuelve el resultado</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador division
        /// </summary>
        /// <param name="n1">Recibe un dato de tipo Numero</param>
        /// <param name="n2">Recibe un dato de tipo Numero</param>
        /// <returns>Opera con el atributo numero del tipo Numero y devuelve el resultado</returns>
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
