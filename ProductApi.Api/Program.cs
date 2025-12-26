using ProductApi.Infrastructure.DependencyInjection;
using ProductApi.Application.DependencyInjection;
using ProductApi.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


//builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Add dependency injection
builder.Services.AddApplicationServicesInjection();
builder.Services.AddInfrastructureServicesInjection(
    builder.Configuration.GetConnectionString("DefaultConnection")!);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseCors("FrontendPolicy");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

