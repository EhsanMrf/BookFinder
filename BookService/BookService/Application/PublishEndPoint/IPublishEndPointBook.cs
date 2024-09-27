using Domain.Model.Model.Book.QueryModel;
using Framework.TransientService;

namespace Application.PublishEndPoint;

public interface IPublishEndPointBook:ITransientService
{
    Task PublishAfterCreate(BookQueryModel queryModel);
}