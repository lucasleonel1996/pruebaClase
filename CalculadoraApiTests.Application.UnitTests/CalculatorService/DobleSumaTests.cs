using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using CalculadoraApiTests.Application;
using System.Collections.Generic;
using InMemoryHistory.Models;

namespace CalculadoraApiTests.Application.UnitTests.CalculatorService
{
    public class DobleSumaTests
    {
        [Fact(DisplayName = "TestardoSuccess")]
        public void DobleSuma_ValidNumbers_Success()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<Application.CalculatorService>>();
            var calculatorMock = new Mock<Calculadora.ICalculadora>();
            var historyMock = new Mock<InMemoryHistory.IInMemoryHistory>();

            double a = 4314, b = 1, expectedCalculatorResult = 4315;
            calculatorMock.Setup(x => x.Suma(a, b)).Returns(expectedCalculatorResult);
            double expectedResult = expectedCalculatorResult * 2;

            // Act
            var service = new Application.CalculatorService(loggerMock.Object, calculatorMock.Object, historyMock.Object);
            var result = service.DobleSuma(a, b);

            // Assert
            Assert.Equal(expectedResult, result);
            calculatorMock.Verify(x => x.Suma(a, b), Times.Once);
            historyMock.Verify(x => x.AddOperation(It.IsAny<OperationRecord>()), Times.Once);
        }
        
        [Fact(DisplayName = "TestardoFailed")]
        public void DobleSuma_GivenNullValue_ShouldFail()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<Application.CalculatorService>>();
            var calculatorMock = new Mock<Calculadora.ICalculadora>();
            var historyMock = new Mock<InMemoryHistory.IInMemoryHistory>();

            double? a = 4314, b = null;
            double c = 0;
            
            // Act
            var service = new Application.CalculatorService(loggerMock.Object, calculatorMock.Object, historyMock.Object);
            var result = service.DobleSuma(a, b);

            // Assert
            Assert.Null(result);
            calculatorMock.Verify(x => x.Suma(a.Value, c), Times.Never);
        }

    }
}
