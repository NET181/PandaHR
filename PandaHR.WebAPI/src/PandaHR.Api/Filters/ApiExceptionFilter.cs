using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using PandaHR.Api.Common.Exceptions.Enum;
using System;
using System.Net;
using Microsoft.Extensions.Logging;

namespace PandaHR.Api.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            HttpStatusCode? statusCode = ((context?.Exception as WebException)?.Response as HttpWebResponse)?.StatusCode
                   ?? getErrorCode(context.Exception.GetType());

            string errorMessage = context.Exception.Message;
            string customErrorMessage = "Error";
            string stackTrace = context.Exception.StackTrace;

            context.ExceptionHandled = true; 
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(
                new
                {
                    message = customErrorMessage,
                    isError = true,
                    errorMessage = errorMessage,
                    errorCode = statusCode,
                    model = string.Empty
                });

            #region Logging  
            
            _logger.LogError(context.Exception,"We caught an error");

            #endregion Logging

            response.ContentLength = result.Length;
            response.WriteAsync(result);
        }

        private HttpStatusCode getErrorCode(Type exceptionType)
        {
            ExceptionTypes tryParseResult;
            if (Enum.TryParse<ExceptionTypes>(exceptionType.Name, out tryParseResult))
            {
                switch (tryParseResult)
                {
                    case ExceptionTypes.NullReferenceException:
                        return HttpStatusCode.LengthRequired;

                    case ExceptionTypes.FileNotFoundException:
                    case ExceptionTypes.EntityNotFoundException: 
                        return HttpStatusCode.NotFound;

                    case ExceptionTypes.OverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case ExceptionTypes.OutOfMemoryException:
                        return HttpStatusCode.ExpectationFailed;

                    case ExceptionTypes.InvalidCastException:
                        return HttpStatusCode.PreconditionFailed;

                    case ExceptionTypes.ObjectDisposedException:
                        return HttpStatusCode.Gone;

                    case ExceptionTypes.UnauthorizedAccessException:
                        return HttpStatusCode.Unauthorized;

                    case ExceptionTypes.NotImplementedException:
                        return HttpStatusCode.NotImplemented;

                    case ExceptionTypes.NotSupportedException:
                        return HttpStatusCode.NotAcceptable;

                    case ExceptionTypes.InvalidOperationException:
                        return HttpStatusCode.MethodNotAllowed;

                    case ExceptionTypes.TimeoutException:
                        return HttpStatusCode.RequestTimeout;

                    case ExceptionTypes.ArgumentException:
                        return HttpStatusCode.BadRequest;

                    case ExceptionTypes.StackOverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case ExceptionTypes.FormatException:
                        return HttpStatusCode.UnsupportedMediaType;

                    case ExceptionTypes.IOException:
                        return HttpStatusCode.NotFound;

                    case ExceptionTypes.IndexOutOfRangeException:
                        return HttpStatusCode.ExpectationFailed;

                    default:
                        return HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
