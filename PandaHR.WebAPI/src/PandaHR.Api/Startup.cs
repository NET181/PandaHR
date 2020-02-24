using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DependencyResolver;
using PandaHR.Api.Filters;

namespace PandaHR.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(
                opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                }
            );
            services.AddCors();
            services.AddMvc(option =>
                    {
                        option.EnableEndpointRouting = false;
                        option.Filters.Add(typeof(ApiExceptionFilter));
                    })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddFluentValidation(
                opt => opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                );

            services.AddOpenApiDocument(document =>
            {
                document.DocumentName = "v1";
            });
            services.RegisterDependencies(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDataInitializer dataInitializer)
        {
            if (env.IsDevelopment())
            {
                dataInitializer.Seed();
            }
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3(cfg =>
            {
                cfg.CustomStylesheetPath = "/css/swaggercustom.css";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
