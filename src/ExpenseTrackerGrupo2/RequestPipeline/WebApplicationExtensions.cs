namespace ExpenseTrackerGrupo2.RequestPipeline;

using Microsoft.AspNetCore.Diagnostics;
using ExpenseTrackerGrupo2.Persistence.Database;

public static class WebApplicationExtensions
{
    public static WebApplication UseGlobalErrorHandling(this WebApplication app)
    {
        app.UseExceptionHandler("/error");

        app.Map("/error", (HttpContext httpContext) =>
        {
            var exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            return Results.Problem();
        });

        return app;
    }
}