using Domain.Model.Model.Book.QueryModel;
using Framework.Response;
using MediatR;

namespace Domain.Model.Model.Book.Query;

public class GetBookByIdQuery(Guid id) : IRequest<ServiceResponse<BookQueryModel?>>
{
    public Guid Id { get; set; } = id;
}