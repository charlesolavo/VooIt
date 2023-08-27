using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VooIt.Domain.Exceptions;
using VooIt.Domain.Models;

namespace VooIt.Api.Filters
{
    public class GlobalExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            context.ExceptionHandled = true;

            var logDescription = $"{context.HttpContext.Request.Protocol} {context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";

            _logger.LogError(context.Exception, logDescription);
             if (context.Exception is DomainException
                  || context.Exception is InvalidOperationException
                  || context.Exception is ArgumentException
                  || context.Exception is NullReferenceException)
            {
                _logger.LogError(context.Exception.Message, $"{context.Exception}");

                context.Result = new JsonResult(new ErrorResponse(context.Exception.Message))
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            else if (context.Exception is DomainNotFoundException domainNotFoundException)
            {
                _logger.LogError(domainNotFoundException.Message, $"{context.Exception}");

                context.Result = new JsonResult(new ErrorResponse(domainNotFoundException.Message))
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                var error = $"{context.Exception}";

                _logger.LogError(error, error);

                context.Result = new JsonResult(new ErrorResponse(error))
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
