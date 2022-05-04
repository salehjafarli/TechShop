using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Results
{
    public class InvalidResult<T> : Result<T>
    {
        public override ResultType ResultType { get; } = ResultType.Invalid;

        public override T Data { get; } = default;

        public override List<string> Errors { get; } = new List<string>();
    }
}
