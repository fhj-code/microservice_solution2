using microservice_solution2.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shed.CoreKit.WebApi;
using System.Net.Http;

namespace microservice_solution2.ItemCart
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCorrelationToken();
            services.AddCors();
            services.AddTransient<ICart, ItemCart>();
            services.AddTransient<HttpClient>();
            services.AddWebApiEndpoints(new WebApiEndpoint<ICatalog>(new System.Uri("http://localhost:5001")));
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
            app.UseRequestLogging("getevents");
            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseWebApiEndpoint<ICart>();
        }
    }
}
