using cp.Web.Application.Interface;
using cp.Web.Application.Services;
using cp.Web.Persistence.DbClient;
using cp.Web.Persistence.Repository;
using cp.Web.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CosmosClientFactory>();

builder.Services.AddTransient<IPersonSubmissionRepository, PersonSubmissionRepository>();
builder.Services.AddTransient<IProgramConfigsRepository, ProgramConfigsRepository>();

builder.Services.AddTransient<IProgramConfigServices, ProgramConfigsServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
ProgramConfigEndpoints.MapEndpoints(app);

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
