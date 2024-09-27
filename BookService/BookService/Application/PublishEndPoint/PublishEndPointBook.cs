using Domain.Model.Model.Book.QueryModel;
using MassTransit;

namespace Application.PublishEndPoint;

public class PublishEndPointBook(IPublishEndpoint publishEndpoint): IPublishEndPointBook
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public async Task PublishAfterCreate(BookQueryModel queryModel) => await _publishEndpoint.Publish(queryModel);

}