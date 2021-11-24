using System;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AmanahTask.API.Helpers
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            string result;

            //if (exception is ClinicException)
            //{
            //    code = (HttpStatusCode)600;
            //    result = JsonConvert.SerializeObject(new
            //    {
            //        message = exception.InnerException != null ? exception.InnerException.Message : exception.Message,
            //        methodName = new StackTrace(exception).GetFrame(0).GetMethod().Name,
            //        code = 600
            //    });

            //}
            if (exception is CustomException)
            {
                code = (HttpStatusCode)exception.HResult;
                result = JsonConvert.SerializeObject(new
                {
                    message = exception.InnerException != null ? exception.InnerException.Message : exception.Message,
                    methodName = new StackTrace(exception).GetFrame(0).GetMethod().Name,
                    code = code
                });

            }
            else
            {
                result = JsonConvert.SerializeObject(new
                {
                    message = exception.Message,
                    methodName = new StackTrace(exception).GetFrame(0).GetMethod().Name,
                    code = HttpStatusCode.InternalServerError
                });
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}