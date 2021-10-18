using System;
using Xunit;
using Moq;
using CalculadoraApiTests.Application;
using Microsoft.Extensions.Logging;

namespace CalculadoraApiTests.testardos
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<CalculatorService>>();
            var calculatorMock = new Mock<Calculadora.ICalculadora>();

            int numA = 2, numB = 3;

            calculatorMock.Setup(x => x.Suma(numA, numB)).Returns(5);

            var service = new CalculatorService(loggerMock.Object, calculatorMock.Object);

            // Act
            var result = service.DobleSuma(numA, numB);

            // Assert
            Assert.Equal(10, result);
        }
    }
}
