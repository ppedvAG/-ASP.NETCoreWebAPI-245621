
using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Services;

namespace RentACarODataApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("Default");
            // Add services to the container.

            builder.Services.AddTransient<IVehicleServiceAsync, VehicleServiceAsync>();
            builder.Services.AddTransient<IOrderServiceAsync, OrderService>();
            builder.Services.AddSqlServer<VehicleDbContext>(connectionString);
            builder.Services.AddControllers()
                .AddODataConfiguration();

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
