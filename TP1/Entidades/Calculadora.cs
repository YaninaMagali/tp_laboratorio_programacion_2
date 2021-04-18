using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Recibe el operador y evalua si es valido
        /// </summary>
        /// <param name="operador">Recibe el operador a evaluar</param>
        /// <returns>Si es valido lo retorna como string, sino, retorna operador +</returns>
        private static string ValidarOperador(char operador)
        {
            if(operador != '+' &&
                operador != '-' &&
                operador != '/' &&
                operador != '*')
            {
                operador = '+';
            }

            return operador.ToString();
        }

        /// <summary>
        /// Recibe dos objetos de tipo numero y un operador para realizar la operacion correspondiente
        /// </summary>
        /// <param name="num1">Recibe un objeto de tipo numero</param>
        /// <param name="num2">Recibe un objeto de tipo numero</param>
        /// <param name="operador">Recibe el operador </param>
        /// <returns>Devuelve el resultado de la operacion entre los dos numeros</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultadoOperacion = 0;
            
            switch(operador)
                {
                case "+":
                    resultadoOperacion = num1 + num2;
                    break;
                case "-":
                    resultadoOperacion = num1 - num2;
                    break;
                case "/":
                    resultadoOperacion = num1 / num2;
                    break;
                case "*":
                    resultadoOperacion = num1 * num2;
                    break;
            }


            return resultadoOperacion;
        }
    }
}
