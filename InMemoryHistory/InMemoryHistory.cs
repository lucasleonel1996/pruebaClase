using InMemoryHistory.Models;
using System;
using System.Collections.Generic;

namespace InMemoryHistory
{
    public class InMemoryHistory : IInMemoryHistory
    {
        private List<OperationRecord> _operations;
        public List<OperationRecord> Operations => new List<OperationRecord>(_operations);

        public InMemoryHistory()
        {
            _operations = new List<OperationRecord>();
        }

        public void AddOperation(OperationRecord operation)
        {
            _operations.Add(operation);
        }

    }
}
