using Calculadora;
using InMemoryHistory;
using InMemoryHistory.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CalculadoraApiTests.Application
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ILogger<CalculatorService> _logger;
        private readonly ICalculadora _calculadora;
        private readonly IInMemoryHistory _history;

        public CalculatorService(ILogger<CalculatorService> logger, ICalculadora calculadora, IInMemoryHistory history)
        {
            _logger = logger;
            _calculadora = calculadora;
            _history = history;
        }

        public double? DobleSuma(double? numA, double? numB)
        {
            _logger.LogInformation("DobleSuma");

            if (!numA.HasValue || !numB.HasValue)
            {
                return null;
            }
            var res = _calculadora.Suma(numA.Value, numB.Value) * 2;

            _history.AddOperation(new OperationRecord
            {
                Factors = new List<double>() { numA.Value, numB.Value },
                Operation = "DobleSuma",
                Result = res
            });

            return res;
        }

        public double Suma(double numA, double numB)
        {
            _logger.LogInformation("Suma");
            var res = _calculadora.Suma(numA, numB);

            _history.AddOperation(new OperationRecord
            {
                Factors = new List<double>() { numA, numB },
                Operation = "Suma",
                Result = res
            });

            return res;
        }
    }
}
