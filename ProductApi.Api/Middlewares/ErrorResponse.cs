namespace ProductApi.Api.Middlewares;

public sealed record ErrorResponse(
    int StatusCode,
    string Message
);
