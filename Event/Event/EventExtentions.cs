
using Infrastructure.Core.MessageBroken;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Event
{
    public static class EventExtentions
    {
        public static IApplicationBuilder UseSubcriberAllEvent(this IApplicationBuilder app)
        {
            var types = typeof(EventExtentions).GetTypeInfo().Assembly.GetTypes()
               .Where(mytype => mytype.GetInterfaces().Contains(typeof(IEvent)));

            foreach (var type in types)
            {
                app.UseSubscribeEvent(type);
            }

            return app;
        }

        public static IApplicationBuilder UseSubscribeEvent<T>(this IApplicationBuilder app) where T : IEvent
        {
            app.ApplicationServices.GetRequiredService<IEventListener>().Subscribe<T>();

            return app;
        }

        public static IApplicationBuilder UseSubscribeEvent(this IApplicationBuilder app, Type type)
        {
            app.ApplicationServices.GetRequiredService<IEventListener>().Subscribe(type);

            return app;
        }
    }
}
