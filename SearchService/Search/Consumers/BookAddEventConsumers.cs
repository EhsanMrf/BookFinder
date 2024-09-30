using Domain.Model.Model.Book.QueryModel;
using Elastic.Clients.Elasticsearch;
using MassTransit;

namespace Search.Consumers
{
    public class BookAddEventConsumers(ElasticsearchClient elasticsearchClient) : IConsumer<Domain.Model.Model.Book.QueryModel.BookQueryModel>
    {
        private readonly ElasticsearchClient _elasticsearchClient = elasticsearchClient;

        public async Task Consume(ConsumeContext<Domain.Model.Model.Book.QueryModel.BookQueryModel> context)
        {
            var message = context.Message;

            if (message is null) return;

            var itemIndex = new BookQueryModel
            {
                Title = message.Title,
                AuthorName = message.AuthorName,
                Id = message.Id,
                PublishYear = message.PublishYear
            };

            var result = await _elasticsearchClient.Indices.ExistsAsync("book-item-index");

            if (!result.Exists)
            {
                await _elasticsearchClient.Indices
                    .CreateAsync<BookQueryModel>(index: "book-item-index");
            }

            await _elasticsearchClient.IndexAsync(itemIndex, index: "book-item-index");
        }
    }
}