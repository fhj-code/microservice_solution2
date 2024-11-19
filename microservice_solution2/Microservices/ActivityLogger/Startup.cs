using System.Net.Http;
using microservice_solution2;
using microservice_solution2.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shed.CoreKit.WebApi;

namespace ActivityLogger
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCorrelationToken();
            services.AddCors();
            services.AddTransient<IActivityLogger, ActivityLogger>();
            services.AddTransient<HttpClient>();
            services.AddWebApiEndpoints(new WebApiEndpoint<ICart>(new System.Uri("http://localhost:5002")));
            services.AddHostedService<Scheduler>();
            services.AddLogging(builder => builder.AddConsole());
            services.AddRequestLogging();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCorrelationToken();
            app.UseRequestLogging("get");
            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseWebApiEndpoint<IActivityLogger>();
        }
    }
}
