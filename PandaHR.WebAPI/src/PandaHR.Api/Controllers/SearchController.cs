using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.DAL.Models.Entities;
using Nest;

namespace PandaHR.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ICVService _CVService;
        private readonly IElasticClient _elasticClient;
      

        public SearchController(ICVService CVService, IElasticClient elasticClient)
        {
            _CVService = CVService;
            _elasticClient = elasticClient;
        }

        [Route("/search/reindex")]
        public async Task<IActionResult> ReIndex()
        {
            await _elasticClient.DeleteByQueryAsync<CV>(q => q.MatchAll());

            var allCVs = (await _CVService.GetAllAsync()).ToArray();

            foreach (var post in allCVs)
            {
                await _elasticClient.IndexDocumentAsync(post);
            }

            return Ok($"{allCVs.Length} CV(s) reindexed");
        }

        [Route("/search")]
        public async Task<IActionResult> Find(string query, int page = 1, int pageSize = 30)
        {
            var response = await _elasticClient.SearchAsync<CV>(
                s => s.Query(q => q.QueryString(d => d.Query(query)))
                    .From((page - 1) * pageSize)
                    .Size(pageSize));

            if (!response.IsValid)
            {
                // We could handle errors here by checking response.OriginalException or response.ServerError properties
                return NotFound();
            }

            //if (page > 1)
            //    ViewData["prev"] = GetSearchUrl(query, page - 1, pageSize);
            //if (response.IsValid && response.Total > page * pageSize)
            //    ViewData["next"] = GetSearchUrl(query, page + 1, pageSize);

            return Ok(response.Documents);
        }
    }
}