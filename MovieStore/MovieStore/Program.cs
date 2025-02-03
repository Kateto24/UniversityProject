using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using FootballClubs.BL;
using FootballClubs.BL.Interfaces;
using FootballClubs.BL.Services;
using FootballClubs.MapsterConfig;
using FootballClubs.ServicesExtensions;
using FootballClubs.Validators;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace FootballClubs
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            var logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(theme:
                AnsiConsoleTheme.Code)
                .CreateLogger();

            builder.Logging.AddSerilog(logger);

            // Add services to the container.
            builder.Services
                .AddConfigurations(builder.Configuration)
                .RegisterDataLayer()
                .RegisterBusinessLayer();

            MapsterConfiguration.Configure();
            builder.Services.AddMapster();

            builder.Services.AddValidatorsFromAssemblyContaining<AddMovieRequestValidator>();
            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHealthChecks();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapHealthChecks("/healthz");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
