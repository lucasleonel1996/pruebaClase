using InMemoryHistory;
using InMemoryHistory.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CalculadoraApiTests.Application.HistoryService
{
    public class HistoryService : IHistoryService
    {
        private readonly ILogger<HistoryService> _logger;
        private readonly IInMemoryHistory _history;

        public HistoryService(ILogger<HistoryService> logger, IInMemoryHistory history)
        {
            _logger = logger;
            _history = history;
        }
        public List<OperationRecord> GetHistory()
        {
            _logger.LogInformation("GetHistory");
            return _history.Operations;
        }

        public double GetSumOfAllResults()
        {
            _logger.LogInformation("GetSumOfAllResults");

            return _history.Operations.Select(x => x.Result).Sum();
        }
    }
}
