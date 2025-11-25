
using BitcoinAPI.Interfaces;
using BitcoinAPI.Models;
using BitcoinAPI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BitcoinAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            Log.Logger = new LoggerConfiguration()
                          .MinimumLevel.Information()
                          .WriteTo.Console()
                          .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                          .CreateLogger();
            builder.Host.UseSerilog();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<ISavedData, SavedDataService>();
            builder.Services.AddScoped<ILiveData, LiveDataService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
