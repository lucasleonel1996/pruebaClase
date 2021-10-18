using InMemoryHistory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraApiTests.Application.HistoryService
{
    public interface IHistoryService
    {
        public List<OperationRecord> GetHistory();
        public double GetSumOfAllResults();
    }
}
