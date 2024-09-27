using Domain.Model.Model.Author.QueryModel;
using Framework.Response;
using MediatR;

namespace Domain.Model.Model.Author.Query;

public class GetAuthorBooksByAuthorId(Guid id) : IRequest<ServiceResponse<IEnumerable<AuthorBookQueryModel>>>
{
    public Guid Id { get; set; } = id;
}