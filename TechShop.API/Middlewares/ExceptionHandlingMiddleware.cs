
using TechShop.Exceptions;
using TechShop.Extensions;
using TechShop.Results;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Middlewares
{
    internal sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        public ILogger Logger { get; }

        public ExceptionHandlingMiddleware(ILogger logger)
        {
            Logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {       
            try
            {
                await next(context);
            }
            catch (ValidationException e)
            {
                e.Log(Logger);
                await context.Request.LogRequest(Logger);
                await HandleValidationExceptionAsync(context, e);
            }
        }

        private static async Task HandleValidationExceptionAsync(HttpContext httpContext, ValidationException exception)
        {
            var responseObj = new InvalidResult<object>();
            responseObj.Errors.AddRange(exception.Errors);
            httpContext.Response.ContentType = "application/json";
            string response = JsonConvert.SerializeObject(responseObj);
            await httpContext.Response.WriteAsync(response);
        }
        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var response = new
            {
                detail = exception.Message,
            };
            httpContext.Response.ContentType = "application/json";
        }
    }
}
