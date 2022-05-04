using TechShop.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult FromResult<T>(this ControllerBase controller, Result<T> result)
        {
            switch (result.ResultType)
            {
                case ResultType.Ok:
                    return controller.Ok(result);
                case ResultType.NotFound:
                    return controller.NotFound(result);
                case ResultType.Invalid:
                    return controller.BadRequest(result);
                case ResultType.Unexpected:
                    return controller.BadRequest(result);
                case ResultType.Unauthorized:
                    return controller.Unauthorized();
                case ResultType.InternalError:
                    return controller.StatusCode(StatusCodes.Status500InternalServerError,result);
                default:
                    throw new Exception("An unhandled result has occurred as a result of a service call.");
            }
        }
    }
}
