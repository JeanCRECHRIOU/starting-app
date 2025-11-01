namespace Api.ServicesInjection;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _env;

    public ErrorHandlingMiddleware(RequestDelegate next, IWebHostEnvironment env)
    {
        _next = next;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);  // Appel du middleware suivant
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        if (_env.IsDevelopment())
        {
            // Scénario pour développement : détails d'erreur
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return context.Response.WriteAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message,
                Details = exception.StackTrace
            }.ToString());
        }
        else
        {
            // Scénario en production : Message générique pour éviter la fuite d'information sensible
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return context.Response.WriteAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Une erreur interne est survenue. Veuillez réessayer plus tard."
            }.ToString());
        }
    }
}
