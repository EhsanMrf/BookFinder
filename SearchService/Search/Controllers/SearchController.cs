using Domain.Model.Model.Book.QueryModel;
using Elastic.Clients.Elasticsearch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController(ElasticsearchClient client) : ControllerBase
    {
        [HttpGet]
        public async Task<Results<Ok<IReadOnlyCollection<BookQueryModel>>, NotFound>> SearchItems(string qr)
        {
            var response = await client.SearchAsync<BookQueryModel>(s => s
                .Index("book-item-index")
                .From(0)
                .Size(10)
                .Query(q =>
                    q.Fuzzy(t => t.Field(x => x.Title).Value(qr)))
            );

            if (response.IsValidResponse)
                return TypedResults.Ok(response.Documents);

            return TypedResults.NotFound();

        }
    }
}
