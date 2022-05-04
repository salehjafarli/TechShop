using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Results
{
    public enum ResultType
    {
        Ok,
        Invalid,
        Unauthorized,
        NotFound,
        PermissionDenied,
        Unexpected,
        InternalError
    }
}
