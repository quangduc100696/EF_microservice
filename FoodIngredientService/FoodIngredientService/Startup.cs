using DataModel;
using Infrastructure.Swagger;
using Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Core.Event;
using Infrastructure.Core.MessageBroken;
using Serilog;
using Infrastructure.Logging;

namespace FoodIngredientService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = LoggingExtentions.AddLogging(Configuration);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DbContextData>(options => options.UseSqlServer(Configuration.GetConnectionString(ConnectionStringKeys.App)));

            services.AddSwagger(Configuration).AddCore(typeof(Startup), typeof(DbContextData)).AddRabbitMQ(Configuration);

            // CoreService.ConfigureServiceDB(ref services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // app.UseHttpsRedirection();

            app.UseSubcriberAllEvent();

            app.UseSwagger(Configuration);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
