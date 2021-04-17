using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

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
