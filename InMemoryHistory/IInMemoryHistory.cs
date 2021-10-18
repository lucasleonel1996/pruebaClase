using InMemoryHistory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InMemoryHistory
{
    public interface IInMemoryHistory
    {
        public List<OperationRecord> Operations { get; }

        public void AddOperation(OperationRecord operation);
    }
}
