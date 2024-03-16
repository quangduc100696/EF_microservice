using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.MessageBroken
{
    public static class RabbitMQExtendtions
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services, IConfiguration Configuration) { 
        
            var options = new RabbitMQOptions();

            Configuration.GetSection(nameof(MessageBrokersOptions)).Bind(options);

            services.Configure<RabbitMQOptions>(Configuration.GetSection(nameof(MessageBrokersOptions)));

            services.AddSingleton<IEventListener, RabbitMQListener>();

            return services;

        }
    }
}
