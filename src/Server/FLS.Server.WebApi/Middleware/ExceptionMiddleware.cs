using FLS.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FLS.Server.WebApi.Middleware
{
    /// <summary>
    /// Exception middleware for logging global exceptions within server.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHttpContextAccessor _httpAccessor;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHttpContextAccessor httpAccessor)
        {
            _next = next;
            _logger = logger;
            _httpAccessor = httpAccessor;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                _httpAccessor.HttpContext = httpContext;
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, $"General server exception: {exception.Message}");

            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (exception is EntityNotFoundException) code = HttpStatusCode.NotFound;
            else if (exception is UnauthorizedAccessException) code = HttpStatusCode.Unauthorized;
            //else if (exception is BadRequestException) code = HttpStatusCode.BadRequest;

            var result = JsonConvert.SerializeObject(new { exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
