using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate double DelegadoCalcular(int numUno, int numDos, string operacion);


    public class Calculadora
    {
        public static DelegadoCalcular del=Calcular;

        private static double Calcular(int x,int y,string operacion)
        {
            switch (operacion)
            {
                case "+":
                    return Calculadora.Sumar(x, y);
                    
                case "-":
                    return Calculadora.Restar(x, y);
                   
                case "/":
                    return Calculadora.Dividir(x, y);
                
                case "*":
                    return Calculadora.Multiplicar(x, y);
          
                default:
                    return 0;
            }

        }


        private static double Sumar(int a,int b)
        {
            return a + b;
        }
        private static double Restar(int a,int b)
        {
            return a - b;
        }
        private static double Multiplicar(int a,int b)
        {
            return a * b;
        }
        private static double Dividir(int a,int b)
        {
            return a / b;
        }
    }
}
