using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Inz.HealthCheck
{
    internal class HealthCheck
    {
        WebApplication app;

        public HealthCheck(string[] args) 
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.UseUrls("http://0.0.0.0:5000");
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
                    .AllowCredentials()); // allow credentials


            app.UseAuthorization();

            app.MapControllers();


        }
        public async Task Run()
        {
            await app.RunAsync();
        }
    }
}
