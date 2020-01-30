using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
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

            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex(defaultIndex)
                .DefaultMappingFor<CV>(m => m
                    .Ignore(cv => cv.IsDeleted)
                    .PropertyName(p => p.Summary, "summary")
                );

            
            var client = new ElasticClient(settings);
            //var createIndexResponse = client.Indices.Create("Vacancyindex", c => c
            //    .Map<CV>(m => m.AutoMap())
            //);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
