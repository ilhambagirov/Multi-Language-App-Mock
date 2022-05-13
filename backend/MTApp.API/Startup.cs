using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MTApp.API.Infrastructor;
using MTApp.API.Models.Data;
using MTApp.API.Modules.NewsModule;
using System;
using System.Linq;

namespace MTApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(cfg =>
            {
                cfg.UseNpgsql(Configuration.GetConnectionString("cString"));
            });
            var asmbls = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("MTApp")).ToArray();
            services.AddMediatR(asmbls);
            services.AddMediatR(typeof(NewsListQuery));
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddCors(cfg =>
            {
                cfg.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("http://localhost:3000");
                });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MTApp.API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Seed().GetAwaiter().GetResult();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MTApp.API v1"));
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
