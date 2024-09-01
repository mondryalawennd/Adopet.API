using Adopet.API;
using Adopet.API.Dados.Context;
using Adopet.API.Service;
using Adopet.API.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Options;
using Serilog;

var builder = WebApplication.CreateBuilder(args);// Criando uma aplicação Web.

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

//DI
builder.Services.AddControllers().AddNewtonsoftJson(options =>
   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddScoped<IEventoService, EventoService>()
                .AddDbContext<DataBaseContext>(opt => {
                    opt.UseInMemoryDatabase("AdopetDB");
                    opt.UseLoggerFactory(LoggerFactory.Create(builder =>
                    {
                        builder.AddSerilog();
                    }));
                });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var serviceProvider = builder.Services.BuildServiceProvider();
var eventoService = serviceProvider.GetService<IEventoService>();

var app = builder.Build();
eventoService.GenerateFakeDate();

app.UseSwagger();
app.UseSwaggerUI(
    c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoAPI V1");
        c.RoutePrefix = string.Empty;
    }
);

app.MapControllers();
app.Run();

