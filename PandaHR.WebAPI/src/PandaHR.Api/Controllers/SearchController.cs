using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PandaHR.Api.Services.Contracts;
using PandaHR.Api.DAL.DTOs.CV;
using Nest;

namespace PandaHR.Api.Controllers
{
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

        [Route("/search")]
        public async Task<IActionResult> Find(string query, int page = 1, int pageSize = 30)
        {
            var response = await _elasticClient.SearchAsync<CVforSearchDTO>(
                s => s.Query(q => q.QueryString(d => d.Query(query)))
                    .From((page - 1) * pageSize)
                    .Size(pageSize));

            if (!response.IsValid)
            {
                // We could handle errors here by checking response.OriginalException or response.ServerError properties
                return NotFound();
            }

            return Ok(response.Documents);
        }
    }
}