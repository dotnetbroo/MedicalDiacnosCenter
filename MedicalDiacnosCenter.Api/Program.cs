using MedicalDiacnosCenter.Api.Extensions;
using MedicalDiacnosCenter.Data.DbContexts;
using MedicalDiacnosCenter.Service.Helpers;
using MedicalDiacnosCenter.Service.Meppers;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;

namespace MedicalDiacnosCenter.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddCustomServices();
            builder.Services.AddAutoMapper(typeof(MapperProfile));

            // logger
            var logger = new LoggerConfiguration()
              .ReadFrom.Configuration(builder.Configuration)
              .Enrich.FromLogContext()
              .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            var app = builder.Build();


            EnvironmentHelper.WebRootPath = Path.GetFullPath("wwwroot");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}