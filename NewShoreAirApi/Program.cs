using Application.Modules.Flights.Contracts;
using Application.Modules.Flights.UseCases;
using Adapters.Providers.NewShoreAir;
using Adapters.Providers.Logger.Provider;
using Application.Shared.Logger.ProviderContracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ILoggerProviderContract, LoggerProvider>();
builder.Services.AddTransient<IFlightProvier, FlightProvider>();
builder.Services.AddTransient<IGetFlightRutesUseCase, GetFlightRoutesUseCase>();
builder.Services.AddTransient<IGetJourneyByRuteUseCase, GetJourneyByRouteUseCase>();

string[] allowedOrigins = builder.Configuration["AppConfig:ALLOWEDORIGINS"].Split('|');

builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(builder =>
    {
        builder
       .AllowAnyMethod()
       .AllowAnyHeader()
       .AllowCredentials()
       .WithOrigins(allowedOrigins);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())    
{
    app.UseSwagger();
    app.UseSwaggerUI();



}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
