using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Otus.Microservices.Homework01.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices( IServiceCollection services )
        {
            services.AddControllers();

            services.Configure<RouteOptions>( options => options.LowercaseUrls = true );

            services.AddHealthChecks();

            services.AddSwaggerGen( c =>
             {
                 c.SwaggerDoc( "v1", new OpenApiInfo { Title = "Otus.Microservices.Homework01.WebApi", Version = "v1" } );
             } );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI( c => c.SwaggerEndpoint( "/swagger/v1/swagger.json", "Otus.Microservices.Homework01.WebApi v1" ) );
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                } );

            app.UseHealthChecks(
                "/health2",
                new HealthCheckOptions
                {
                    AllowCachingResponses = false,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                } );
        }
    }
}
