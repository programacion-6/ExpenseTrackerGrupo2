using ExpenseTrackerGrupo2.DependencyInjection;
using ExpenseTrackerGrupo2.RequestPipeline;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddServices()
    .AddPersistence(builder.Configuration)
    .AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseGlobalErrorHandling();
app.UseSwagger();
app.UseSwaggerUI(c => 
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Expense Tracker API V1");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();