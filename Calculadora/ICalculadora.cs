using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora
{
    public interface ICalculadora
    {
        public double Suma(double numA, double numB);
        public double Resta(double numA, double numB);
        public double Multiplicacion(double numA, double numB);
        public double? Division(double dividendo, double divisor);
        public double RaizCuadrada(double num);
        public double Potencia(double @base, double exponente);
    }
}
