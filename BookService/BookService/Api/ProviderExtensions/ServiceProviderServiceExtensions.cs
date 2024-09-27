using System.Reflection;
using Framework.Common;
using Framework.Extensions;
using Framework.TransientService;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Persistence.EF;
using Persistence.EF.Repository.Book;

namespace API.ProviderExtensions;

public static class ServiceProviderServiceExtensions
{
    public static void InjectScope(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssembliesOf(typeof(BookCommandRepository))
            .AddClasses(classes => classes.AssignableTo<ITransientService>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }

    public static void DatabaseContext(this IServiceCollection services, string connection)
    {
        services.AddDbContextFactory<DatabaseContext>(x =>
            x.UseSqlServer(connection));
    }

    public static void UpgradeDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        db.Database.Migrate();
    }

    public static void AddMassTransit(this WebApplicationBuilder app)
    {
        app.Services.AddMassTransit(configure =>
        {
            var brokerConfig = app.Configuration.GetSection(BrokerSettingOptions.SectionName).Get<BrokerSettingOptions>();

            brokerConfig?.ThrowIfNull(new ArgumentNullException(nameof(BrokerOptions)));

            configure.AddConsumers(Assembly.GetExecutingAssembly());
            configure.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(brokerConfig!.Host, hostConfigure =>
                {
                    hostConfigure.Username(brokerConfig!.Username);
                    hostConfigure.Password(brokerConfig.Password);
                });

                cfg.ConfigureEndpoints(context);
            });
        });
    }
}