using System.Threading.Tasks;
using PandaHR.Api.Common.Contracts;
using PandaHR.Api.DAL.DTOs.CV;
using PandaHR.Api.DAL;
using Nest;

namespace PandaHR.Api.ElasticSearch
{
    public class ElasticSearchDataInitializer : IElasticSearchDataInitializer
    {
        private readonly IElasticClient _elasticClient;
        private readonly IUnitOfWork _uow;

        public ElasticSearchDataInitializer(IUnitOfWork uow, IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
            _uow = uow;
        }

        public void Reindex()
        {
            ReindexCV();
        }

        private void ReindexCV()
        {
            _elasticClient.DeleteByQueryAsync<CVforSearchDTO>(q => q.MatchAll());

            var allCVs = _uow.CVs.GetCVs();

            foreach (var cv in allCVs)
            {
                _elasticClient.IndexDocument(cv);
            }
        }
    }
}
