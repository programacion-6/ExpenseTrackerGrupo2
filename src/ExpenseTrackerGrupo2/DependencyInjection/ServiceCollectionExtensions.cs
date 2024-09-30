namespace ExpenseTrackerGrupo2.DependencyInjection;

using ExpenseTrackerGrupo2.Persistence.Database;
using ExpenseTrackerGrupo2.DataAccess.Concretes;
using ExpenseTrackerGrupo2.Business.Services.Interfaces;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IIncomeServices, IncomeService>();
        services.AddScoped<IExpenseService, ExpenseService>();
        services.AddScoped<IBudgetService, BudgetService>();
        services.AddScoped<IGoalService, GoalService>();

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IIncomeRepository, IncomeRepository>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IBudgetRepository, BudgetRepository>();
        services.AddScoped<IGoalRepository, GoalRepository>();
        
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        
        if (string.IsNullOrEmpty(connectionString))
        {
        throw new ArgumentException("Connection string is not configured properly.");
        }

        services.AddScoped<IDbConnectionFactory>(_ => 
            new NpgsqlConnectionFactory(connectionString));

        return services;
    }

    public static IServiceCollection AddGlobalErrorHandling(this IServiceCollection services)
    {
        services.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Extensions["traceId"] = context.HttpContext.TraceIdentifier;
                context.ProblemDetails.Extensions["serviceVersion"] = "0.0.1";
                context.ProblemDetails.Extensions["exception"] = "";
            };
        });

        return services;
    }
}