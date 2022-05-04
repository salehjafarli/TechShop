using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Results
{
    public class ErrorResult<T> : Result<T>
    {
        public override T Data { get; } = default;
        public override List<string> Errors { get; } = new List<string>();
        public override ResultType ResultType { get; } = ResultType.InternalError;
    }
}
