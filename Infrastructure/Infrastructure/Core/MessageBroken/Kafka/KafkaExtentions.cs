using Infrastructure.Core.Event;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.MessageBroken.Kafka
{
    public static class KafkaExtentions
    {
        public static IServiceCollection AddKafka(this IServiceCollection services, IConfiguration Configuration)
        {
            var options = new KafkaOptions();
            Configuration.GetSection(nameof(MessageBrokersOptions)).Bind(options);
            services.Configure<KafkaOptions>(Configuration.GetSection(nameof(MessageBrokersOptions)));

            services.AddSingleton<IEventListener, KafkaListener>();

            return services;
        }

        public static IApplicationBuilder UseKafkaSubscribe<T>(this IApplicationBuilder app) where T : IEvent
        {
            app.ApplicationServices.GetRequiredService<IEventListener>().Subscribe<T>();

            return app;
        }
    }
}
