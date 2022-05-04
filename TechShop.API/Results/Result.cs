using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Results
{
    public abstract class Result<T>
    {
        public abstract ResultType ResultType { get; }
        public abstract T Data { get; }
        public abstract List<string> Errors { get;  }

    }
}
