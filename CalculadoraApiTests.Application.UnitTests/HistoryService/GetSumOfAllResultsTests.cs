using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using InMemoryHistory.Models;
using System.Linq;
using System;

namespace CalculadoraApiTests.Application.UnitTests.CalculatorService
{
    public class GetSumOfAllResultsTests
    {
        [Fact(DisplayName = "TestardoSuccess")]
        public void GetSumOfAllResults_ValidRequest_Success()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<Application.HistoryService.HistoryService>>();
            var historyMock = new Mock<InMemoryHistory.IInMemoryHistory>();

            historyMock.Setup(x => x.Operations).Returns(new List<OperationRecord>
            {
                new OperationRecord
                {
                    Factors = new List<double> {2,1},
                    Operation = "Sumarda",
                    Result = 3
                },
                new OperationRecord
                {
                    Factors = new List<double> {5,3},
                    Operation = "Sumadoblarda",
                    Result = 16
                },
            });

            double expectedResult = 19;

            // Act
            var service = new Application.HistoryService.HistoryService(loggerMock.Object, historyMock.Object);
            var result = service.GetSumOfAllResults();

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
