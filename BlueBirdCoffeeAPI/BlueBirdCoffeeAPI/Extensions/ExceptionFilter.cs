using Data.AppException;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Globalization;
using System.Runtime.Serialization;

namespace BlueBirdCoffeeAPI.Extensions
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string message;
            if (context.Exception is AppException)
            {
                message = context.Exception.Message;
            }
            else
            {
                message = context.Exception.Message + "\n" + (context.Exception.InnerException != null ? context.Exception.InnerException.Message : "") + "\n ***Trace*** \n" + context.Exception.StackTrace;
            }
            context.Result = new BadRequestObjectResult(message) { };
        }
    }

}
