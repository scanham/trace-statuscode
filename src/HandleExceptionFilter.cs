using System.Net;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace trace_statuscode
{
    public class HandleExceptionFilter : ExceptionFilterAttribute
    {
        public HandleExceptionFilter()
        {
        
        }

        public override void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(context.Exception.Message) { StatusCode = Int32.Parse(context.Exception.Message) };          
        }
    }
}