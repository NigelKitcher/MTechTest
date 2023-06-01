using AcmeInsurance.Claims.Domain.Extensions;
using AcmeInsurance.Claims.Repository;
using AcmeInsurance.Claims.Repository.Seed;
using Microsoft.EntityFrameworkCore;

namespace AcmeInsurance.Claims
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddClaimsServices();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AcmeDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "StubDatabase"));

            var app = builder.Build();

            var options = new DbContextOptionsBuilder<AcmeDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var srv = new AcmeDbContext(options);
            var seeder = new Seeder(srv);
            seeder.Initialise();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}