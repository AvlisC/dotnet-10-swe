using System.Net;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using ProductApi.Domain;

namespace ProductApi.Api.Middlewares;

public sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Unhandled exception");

            await HandleExceptionAsync(context, exception);
        }
    }

    private static Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        var (statusCode, message) = exception switch
        {
            DomainException => (
                HttpStatusCode.BadRequest,
                exception.Message
            ),

            DbUpdateException => (
                HttpStatusCode.InternalServerError,
                "Erro ao persistir dados"
            ),

            KeyNotFoundException => (
                HttpStatusCode.NotFound,
                "Produto não encontrado"
            ),

            _ => (
                HttpStatusCode.InternalServerError,
                "Erro interno no servidor"
            )
        };

        var response = new ErrorResponse(
            (int)statusCode,
            message
        );

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(
            JsonSerializer.Serialize(response));
    }
}
