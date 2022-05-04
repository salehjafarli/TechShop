using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Results
{
    public class SuccessResult<T> : Result<T>
    {
        private readonly T _data = default;
        public SuccessResult(T data)
        {
            this._data = data;
        }
        public override ResultType ResultType { get; } = ResultType.Ok;
        public override T Data { get { return _data; } }
        public override List<string> Errors { get; } = new List<string>();
    }
}
