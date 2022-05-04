using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(List<string> errors)
        {
            Errors = errors;
        }
        public List<string> Errors { get; }

        public void Log(ILogger logger)
        {
            string logMessage = "Validation exception was thrown. Warnings:";
            foreach (var item in Errors)
            {
                logMessage += "\n" + item;
            }
            logger.Information(logMessage);
        }
    }
}
