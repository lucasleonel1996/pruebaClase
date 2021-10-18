using System;

namespace Calculadora
{
    public class Calculadora : ICalculadora
    {
        public double? Division(double dividendo, double divisor)
        {
            try
            {
                return dividendo / divisor;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public double Multiplicacion(double numA, double numB)
        {
            return numA * numB;
        }

        public double Potencia(double @base, double exponente)
        {
            return Math.Pow((double)@base, (double)exponente);
        }

        public double RaizCuadrada(double num)
        {
            return Math.Sqrt(num);
        }

        public double Resta(double numA, double numB)
        {
            return numA - numB;
        }

        public double Suma(double numA, double numB)
        {
            return numA + numB;
        }
    }
}
