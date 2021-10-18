using System;
using System.Collections.Generic;
using System.Text;

namespace InMemoryHistory.Models
{
    public class OperationRecord
    {
        public string Operation { get; set; }
        public List<double> Factors { get; set; }
        public double Result { get; set; }

        public override bool Equals(object obj)
        {
            var otroObj = (OperationRecord) obj;
            return otroObj.Operation == Operation && otroObj.Result == Result;
        }
    }
}
