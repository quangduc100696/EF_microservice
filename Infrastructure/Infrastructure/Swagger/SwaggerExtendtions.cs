using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Swagger
{
    public static class SwaggerExtendtions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new SwaggerOptions());
            });

            return services;
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IConfiguration Configuration)
        {
            var options = new SwaggerOptions();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{ options.Title} {options.VersionName}"));

            return app;
        }
    }
}
