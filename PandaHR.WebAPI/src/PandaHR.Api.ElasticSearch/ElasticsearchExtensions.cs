using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Elasticsearch.Net;
using PandaHR.Api.DAL.Models.Entities;

namespace PandaHR.Api.ElasticSearch
{
    public static class ElasticsearchExtensions
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
                .DefaultIndex(defaultIndex)
                .DefaultMappingFor<CV>(m => m
                    .Ignore(cv => cv.IsDeleted));
            
            var client = new ElasticClient(settings);

            //var createIndexResponse = client.Indices.Create(defaultIndex, c => c
            //    .Map<CV>(m => m.AutoMap())
            //);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
