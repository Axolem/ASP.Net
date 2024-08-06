using Asp.Versioning;
using Microsoft.OpenApi.Models;

namespace uniapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            _ = builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            _ = builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            _ = builder.Services.AddEndpointsApiExplorer();
            _ = builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "v1", Version = "v1" });
            });

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                _ = app.UseSwagger();
                _ = app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }

            _ = app.UseHttpsRedirection();

            _ = app.UseAuthorization();


            _ = app.MapControllers();

            app.Run();
        }
    }
}
