using Microsoft.EntityFrameworkCore;
using IPMEDTH.Domain.Core.Repositories;
using IPMEDTH.Domain.Infrastructure.Data;
using IPMEDTH.Domain.Infrastructure.Repositories;
using IPMEDTH.Backend.Middlewares;

namespace IPMEDTH.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add the environment variables
            builder.Configuration
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables("");
            string connectionString = builder.Configuration.GetConnectionString("ipmedth") ?? "";



            #region Database & Database DI
            builder.Services.AddDbContext<Context>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
                ServiceLifetime.Transient
            );
            builder.Services.AddScoped<IScoreRepository, ScoreRepository>();

            #endregion


            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // Configure the HTTP request pipeline.
            var app = builder.Build();

            #region Middlewares
            app.UseMiddleware<ExceptionMiddleware>();
            #endregion

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.MapControllers();
            app.Run();
        }
    }
}