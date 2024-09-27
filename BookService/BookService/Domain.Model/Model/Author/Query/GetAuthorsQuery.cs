using Domain.Model.Model.Author.QueryModel;
using Framework.Response;
using MediatR;

namespace Domain.Model.Model.Author.Query;

public class GetAuthorsQuery:IRequest<ServiceResponse<IEnumerable<AuthorQueryModel>>>{}