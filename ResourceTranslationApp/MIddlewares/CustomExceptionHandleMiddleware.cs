using System.Text.Json;
using Application.Exceptions;
using FluentValidation;

namespace ResourceTranslationApp.MIddlewares
{
    public class CustomExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
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

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //TODO to write via serilog
            var code = StatusCodes.Status500InternalServerError;
            var result = string.Empty;
            switch (ex)
            {
                case ValidationException validationException:
                    code = StatusCodes.Status400BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case EntityNotFoundException userNotFoundException:
                    code = StatusCodes.Status400BadRequest;
                    result = JsonSerializer.Serialize(new { error = ex.Message, stackTrace = ex.StackTrace });
                    break;
                default:
                    result = JsonSerializer.Serialize(new { error = ex.Message, stackTrace = ex.StackTrace });
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            return context.Response.WriteAsync(result);
        }
    }
}
