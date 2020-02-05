using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Elasticsearch.Net;

namespace PandaHR.Api.ElasticSearch
{
    public static class ElasticSearchExtensions
    {
        public static void AddElasticsearch(
            this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["elasticsearch:url"];
            var defaultIndex = configuration["elasticsearch:index"];
            var username = configuration["elasticsearch:username"];
            var password = configuration["elasticsearch:password"];

            var pool = new SingleNodeConnectionPool(new Uri(url));
            var settings = new ConnectionSettings(pool)
                .BasicAuthentication(username, password)
                .DisableDirectStreaming()
                .DefaultIndex(defaultIndex);
            
            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
            
        }
    }
}
