﻿using Evently.Common.Application.Caching;
using Evently.Common.Application.Clock;
using Evently.Common.Application.Data;
using Evently.Common.Infrastructure.Caching;
using Evently.Common.Infrastructure.Interceptors;
using Evently.Modules.Events.Infrastructure.Clock;
using Evently.Modules.Events.Infrastructure.Data;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using StackExchange.Redis;

namespace Evently.Common.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string dbConnectionString, string redisConnectionString)
    {
        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(dbConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

        services.TryAddSingleton<PublishDomainEventsInterceptor>();

        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        try
        {
            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
            services.TryAddSingleton(connectionMultiplexer);

            services.AddStackExchangeRedisCache(options =>
            {
                options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer);
            });
        }
        catch
        {
            services.AddDistributedMemoryCache(); //falback if Redis container not up and running
        }

        services.TryAddSingleton<ICacheService, CacheService>();

        return services;
    }
}
