
using Infrastructure.Core.Command;
using Infrastructure.Core.Event;
using Infrastructure.Core.Query;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Core
{
    public static class CoreExtendtions
    {
        public static IServiceCollection AddCore(this IServiceCollection services, params Type[] types)
        {
            var assemblies = types.Select(type => type.GetTypeInfo().Assembly);

            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<IEventBus, EventBus>();

            foreach (var assembly in assemblies)
            {
                services.AddMediatR(assembly);
            }

            return services;
        }
    }
}
