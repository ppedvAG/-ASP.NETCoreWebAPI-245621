
using BusinessModel.Contracts;
using BusinessModel.Services;
using System.Text.Json.Serialization;
using WebApiContrib.Core.Formatter.Csv;

namespace VehicleManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton<IVehicleService, VehicleService>();
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // Enum Serisalization fixen: Farbe soll als string statt int ausgegeben werden
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                })
                // Weitere Formatters hinzufuegen
                .AddXmlSerializerFormatters()
                .AddCsvSerializerFormatters();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
