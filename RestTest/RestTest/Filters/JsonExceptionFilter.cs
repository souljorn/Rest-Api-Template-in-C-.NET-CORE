using RestTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.AspNetCore.Hosting;

/*------------------------------------------------------------
                Middle Ware Filter for API Errors
Filers out Api errors and return a Json object with an explicit 
error and a stack trace
-------------------------------------------------------------*/
namespace RestTest.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _env;

        public JsonExceptionFilter(IHostingEnvironment env) 
        {
            _env = env;
        }

        //When an exception is hit it returns a status code with stack trace
        public void OnException(ExceptionContext context)
        {
            var error = new ApiError();

            if (_env.IsDevelopment())
            {
                error.Message = context.Exception.Message;
                error.Detail = context.Exception.StackTrace;
            }
            else 
            {
                error.Message = "A server error occured";
                error.Detail = context.Exception.Message;
            }
            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}
