using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shed.CoreKit.WebApi;
using System.Net.Http;

namespace microservice_solution2.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCorrelationToken();
            //services.AddControllers();
            services.AddTransient<HttpClient>();
            services.AddWebApiEndpoints(
                new WebApiEndpoint<ICatalog>(new System.Uri("http://localhost:5001")),
                new WebApiEndpoint<ICart>(new System.Uri("http://localhost:5002")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                //  when root calls, the start page will be returned
                if(string.IsNullOrEmpty(context.Request.Path.Value.Trim('/')))
                {
                    context.Request.Path = "/index.html";
                }

                await next();
            });
            app.UseStaticFiles();
            app.UseWebApiRedirect("api/products", new WebApiEndpoint<ICatalog>(new System.Uri("http://localhost:5001")));
            app.UseWebApiRedirect("api/orders", new WebApiEndpoint<ICart>(new System.Uri("http://localhost:5002")));
            app.UseWebApiRedirect("api/logs", new WebApiEndpoint<IActivityLogger>(new System.Uri("http://localhost:5003")));

            //app.UseCorrelationToken();
            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "webapi",
            //        pattern: "api/{controller}/{action}");
            //});

        }

    }
}
