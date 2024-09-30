﻿using System.Reflection;
using MassTransit;
using Search.Infrastructure.Setting;

namespace Search.Infrastructure
{
    public static class BrokerDependencyInjection
    {
        public static void BrokerConfigure(this IHostApplicationBuilder builder)
        {
            builder.Services.AddMassTransit(configure =>
            {
                var brokerConfig = builder.Configuration.GetSection(BrokerOptions.SectionName)
                    .Get<BrokerOptions>();

                ArgumentNullException.ThrowIfNull(brokerConfig, nameof(BrokerOptions));

                configure.AddConsumers(Assembly.GetExecutingAssembly());

                configure.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(brokerConfig.Host, hostConfigure =>
                    {
                        hostConfigure.Username(brokerConfig.UserName);
                        hostConfigure.Password(brokerConfig.Password);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });
        }
    }
}
