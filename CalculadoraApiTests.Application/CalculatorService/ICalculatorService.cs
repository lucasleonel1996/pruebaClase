namespace CalculadoraApiTests.Application
{
    public interface ICalculatorService
    {
        public double Suma(double numA, double numB);
        public double? DobleSuma(double? numA, double? numB);
    }
}
